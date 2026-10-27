using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseDatos;
using Ionic.Zip;

namespace Proyecto_Antonio_Luis.Formularios
{
    /// <summary>
    /// Copias de seguridad y restauración.
    ///
    /// Copia:  base de datos (.bak) + carpeta C:\ByMartin (documentos, facturas,
    ///         histórico...), sin las copias anteriores ni la carpeta tmp,
    ///         en un ZIP en la carpeta de destino elegida.
    /// Restaurar: sustituye la base de datos (y opcionalmente los documentos)
    ///         por los de una copia. Antes hace una copia automática del estado actual.
    ///         Admite también los ZIP del formato antiguo.
    ///
    /// La carpeta de destino y el número de copias a conservar se guardan en
    /// C:\ByMartin\System\copias.ini (cada equipo tiene su configuración).
    /// </summary>
    public partial class Backup : Form
    {
        private const string CarpetaPrograma = @"C:\ByMartin";
        private const string CarpetaTemporal = @"C:\ByMartin\tmp";
        private const string FicheroConfig = @"C:\ByMartin\System\copias.ini";
        private const string DestinoPorDefecto = @"C:\ByMartin\Backup";
        private const string PrefijoCopia = "Backup_";
        private const string PrefijoSeguridad = "AntesDeRestaurar_";

        private enum Modo { Copia, Restaurar }

        /// <summary>Error con un mensaje ya preparado para el usuario.</summary>
        private class ErrorParaUsuario : Exception
        {
            public ErrorParaUsuario(string mensaje, Exception interna) : base(mensaje, interna) { }
        }

        /// <summary>Datos que se pasan al trabajo en segundo plano.</summary>
        private class Trabajo
        {
            public Modo Modo;
            public string Destino;
            public int Conservar;
            public string ZipRestaurar;
            public string EntradaBak;
            public bool RestaurarDocumentos;
        }

        private bool cargando = true;

        public Backup()
        {
            InitializeComponent();
            richTextBox1.Text =
                "Se copiará la base de datos y la carpeta C:\\ByMartin (documentos de los clientes, " +
                "facturas en PDF, histórico...) en un fichero ZIP.\n\n" +
                "Para que la copia sirva si el ordenador se estropea, guárdala en un disco externo, " +
                "un USB o una carpeta de OneDrive / Google Drive.";
        }

        // =====================================================================
        //  Configuración
        // =====================================================================

        private void Backup_Load(object sender, EventArgs e)
        {
            var config = LeerConfig();
            string destino;
            string conservar;
            textDestino.Text = config.TryGetValue("destino", out destino) && destino.Length > 0 ? destino : DestinoPorDefecto;
            int n;
            numericCopias.Value = config.TryGetValue("conservar", out conservar) && int.TryParse(conservar, out n)
                ? Math.Max(0, Math.Min(999, n))
                : 0;
            cargando = false;
        }

        private static Dictionary<string, string> LeerConfig()
        {
            var config = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                if (File.Exists(FicheroConfig))
                {
                    foreach (string linea in File.ReadAllLines(FicheroConfig, Encoding.UTF8))
                    {
                        int igual = linea.IndexOf('=');
                        if (igual > 0)
                        {
                            config[linea.Substring(0, igual).Trim()] = linea.Substring(igual + 1).Trim();
                        }
                    }
                }
            }
            catch
            {
                // Si no se puede leer, se usan los valores por defecto
            }
            return config;
        }

        private void GuardarConfig()
        {
            if (cargando) return;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FicheroConfig));
                File.WriteAllLines(FicheroConfig, new[]
                {
                    "destino=" + textDestino.Text,
                    "conservar=" + ((int)numericCopias.Value)
                }, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido guardar la configuración de las copias.\n\n" + ex.Message,
                    "Copias de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCarpeta_Click(object sender, EventArgs e)
        {
            using (var dialogo = new FolderBrowserDialog())
            {
                dialogo.Description = "Elige dónde guardar las copias de seguridad (mejor un disco externo, USB o carpeta de OneDrive/Google Drive).";
                dialogo.ShowNewFolderButton = true;
                if (Directory.Exists(textDestino.Text))
                {
                    dialogo.SelectedPath = textDestino.Text;
                }
                if (dialogo.ShowDialog(this) == DialogResult.OK)
                {
                    string motivo = DestinoNoValido(dialogo.SelectedPath);
                    if (motivo != null)
                    {
                        MessageBox.Show(motivo, "Copias de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    textDestino.Text = dialogo.SelectedPath;
                    GuardarConfig();
                }
            }
        }

        /// <summary>
        /// El destino no puede ser C:\ByMartin ni estar dentro de él (se copiaría a sí mismo),
        /// salvo la carpeta por defecto C:\ByMartin\Backup, que se excluye de la copia.
        /// </summary>
        private static string DestinoNoValido(string destino)
        {
            string d = Path.GetFullPath(destino).TrimEnd('\\') + "\\";
            string programa = Path.GetFullPath(CarpetaPrograma).TrimEnd('\\') + "\\";
            string porDefecto = Path.GetFullPath(DestinoPorDefecto).TrimEnd('\\') + "\\";
            if (d.StartsWith(programa, StringComparison.OrdinalIgnoreCase) &&
                !d.Equals(porDefecto, StringComparison.OrdinalIgnoreCase))
            {
                return "Elige una carpeta fuera de C:\\ByMartin (o la propia C:\\ByMartin\\Backup).\n" +
                       "Dentro de C:\\ByMartin la copia se copiaría a sí misma.";
            }
            return null;
        }

        /// <summary>Comprueba que se puede escribir en el destino (p. ej. que el USB está conectado).</summary>
        private bool DestinoDisponible()
        {
            string motivo = DestinoNoValido(textDestino.Text);
            if (motivo == null)
            {
                try
                {
                    Directory.CreateDirectory(textDestino.Text);
                    return true;
                }
                catch (Exception ex)
                {
                    motivo = "La carpeta de destino no está disponible:\n" + textDestino.Text +
                             "\n\n¿Está conectado el disco o USB?\n\n" + ex.Message;
                }
            }
            MessageBox.Show(motivo, "Copias de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void numericCopias_ValueChanged(object sender, EventArgs e)
        {
            GuardarConfig();
        }

        // =====================================================================
        //  Botones
        // =====================================================================

        /// <summary>Hacer copia.</summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!DestinoDisponible()) return;
            Empezar(new Trabajo
            {
                Modo = Modo.Copia,
                Destino = textDestino.Text,
                Conservar = (int)numericCopias.Value
            });
        }

        /// <summary>Restaurar una copia.</summary>
        private void buttonRestaurar_Click(object sender, EventArgs e)
        {
            if (!DestinoDisponible()) return;   // ahí se guardará la copia del estado actual

            string zipElegido;
            using (var abrir = new OpenFileDialog())
            {
                abrir.Title = "Elige la copia de seguridad a restaurar";
                abrir.Filter = "Copias de seguridad (*.zip)|*.zip";
                if (Directory.Exists(textDestino.Text)) abrir.InitialDirectory = textDestino.Text;
                if (abrir.ShowDialog(this) != DialogResult.OK) return;
                zipElegido = abrir.FileName;
            }

            string entradaBak;
            bool tieneDocumentos;
            DateTime fechaCopia;
            try
            {
                using (var zip = ZipFile.Read(zipElegido))
                {
                    var bak = BuscarBaseDatos(zip);
                    if (bak == null)
                    {
                        MessageBox.Show("Ese fichero no contiene una copia de la base de datos.", "Restaurar",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    entradaBak = bak.FileName;
                    fechaCopia = bak.LastModified;
                    tieneDocumentos = zip.Entries.Any(z => EsDocumentoRestaurable(z));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede leer ese fichero ZIP.\n\n" + ex.Message, "Restaurar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(
                    "Se van a SUSTITUIR TODOS LOS DATOS ACTUALES (clientes, facturas, remesas...) por los de la copia:\n\n" +
                    "   " + Path.GetFileName(zipElegido) + "\n   (base de datos del " + fechaCopia.ToString("dd/MM/yyyy HH:mm") + ")\n\n" +
                    "Lo que se haya grabado después de esa fecha se perderá.\n" +
                    "Antes de restaurar se hará automáticamente una copia del estado actual en:\n   " + textDestino.Text + "\n\n" +
                    "¿Continuar?",
                    "Restaurar copia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            bool documentos = tieneDocumentos && MessageBox.Show(
                    "¿Restaurar también los documentos (carpeta C:\\ByMartin: documentos de clientes, PDF de facturas...)?\n\n" +
                    "- Sí: los ficheros de la copia sustituyen a los actuales con el mismo nombre (no se borra ninguno).\n" +
                    "- No: solo se restaura la base de datos.",
                    "Restaurar copia", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes;

            if (MessageBox.Show(
                    "ÚLTIMA CONFIRMACIÓN\n\n¿Restaurar la copia del " + fechaCopia.ToString("dd/MM/yyyy HH:mm") + "?\n\n" +
                    "Cierra antes cualquier otra ventana del programa. Al terminar, el programa se cerrará.",
                    "Restaurar copia", MessageBoxButtons.YesNo, MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            Empezar(new Trabajo
            {
                Modo = Modo.Restaurar,
                Destino = textDestino.Text,
                ZipRestaurar = zipElegido,
                EntradaBak = entradaBak,
                RestaurarDocumentos = documentos
            });
        }

        /// <summary>Salir.</summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Backup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Espera a que termine la operación.", "Copias de seguridad",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void Empezar(Trabajo trabajo)
        {
            if (backgroundWorker1.IsBusy) return;

            Bloquear(true);
            progressBar1.Value = 0;
            label3.Text = trabajo.Modo == Modo.Copia ? "Preparando la copia..." : "Preparando la restauración...";
            panel2.Visible = true;
            backgroundWorker1.RunWorkerAsync(trabajo);
        }

        private void Bloquear(bool bloquear)
        {
            button1.Enabled = !bloquear;
            button3.Enabled = !bloquear;
            buttonRestaurar.Enabled = !bloquear;
            buttonCarpeta.Enabled = !bloquear;
            numericCopias.Enabled = !bloquear;
        }

        // =====================================================================
        //  Trabajo en segundo plano
        // =====================================================================

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var trabajo = (Trabajo)e.Argument;
            if (trabajo.Modo == Modo.Copia)
            {
                e.Result = HacerCopia(trabajo.Destino, PrefijoCopia, trabajo.Conservar, 0, 100);
            }
            else
            {
                e.Result = Restaurar(trabajo);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Max(0, Math.Min(100, e.ProgressPercentage));
            var texto = e.UserState as string;
            if (texto != null) label3.Text = texto;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Bloquear(false);
            panel2.Visible = false;

            if (e.Error != null)
            {
                string detalle = e.Error is ErrorParaUsuario ? e.Error.Message : MensajeInterno(e.Error);
                MessageBox.Show("No se ha podido completar la operación.\n\n" + detalle,
                    "Copias de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = (string)e.Result;
            if (resultado.StartsWith("RESTAURADO"))
            {
                MessageBox.Show(resultado.Substring("RESTAURADO".Length) +
                    "\n\nEl programa se cerrará. Vuelve a abrirlo para trabajar con los datos restaurados.",
                    "Restaurar copia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            MessageBox.Show(resultado, "Copias de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================================
        //  Copia
        // =====================================================================

        /// <summary>
        /// Hace la copia y devuelve el texto para el usuario. El progreso se
        /// informa entre <paramref name="desde"/> y <paramref name="hasta"/>.
        /// </summary>
        private string HacerCopia(string destino, string prefijo, int conservar, int desde, int hasta)
        {
            Func<double, int> paso = f => desde + (int)((hasta - desde) * f);
            string marca = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            Directory.CreateDirectory(CarpetaTemporal);
            Directory.CreateDirectory(destino);

            // 1. Copia de la base de datos (la hace SQL Server en la carpeta tmp)
            backgroundWorker1.ReportProgress(paso(0.05), "Copiando la base de datos...");
            var csb = Conexion();
            string bak = Path.Combine(CarpetaTemporal, csb.InitialCatalog + "_" + marca + ".bak");
            try
            {
                using (var con = new SqlConnection(csb.ConnectionString))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = "BACKUP DATABASE " + Corchetes(csb.InitialCatalog) +
                                      " TO DISK = @ruta WITH COPY_ONLY, INIT, NAME = @nombre";
                    cmd.Parameters.AddWithValue("@ruta", bak);
                    cmd.Parameters.AddWithValue("@nombre", "Copia " + marca);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // 2. ZIP con la base de datos y los documentos
                backgroundWorker1.ReportProgress(paso(0.25), "Preparando los documentos...");
                string zipFinal = Path.Combine(destino, prefijo + marca + ".zip");
                string zipParcial = zipFinal + ".parcial";

                using (var zip = new ZipFile())
                {
                    zip.AlternateEncoding = Encoding.UTF8;
                    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                    zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                    zip.Comment = "Copia de seguridad del " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    zip.AddFile(bak, "BaseDatos");
                    AñadirDocumentos(zip, destino);

                    zip.SaveProgress += (s, ev) =>
                    {
                        if (ev.EventType == ZipProgressEventType.Saving_AfterWriteEntry && ev.EntriesTotal > 0)
                        {
                            backgroundWorker1.ReportProgress(
                                paso(0.3 + 0.65 * ev.EntriesSaved / ev.EntriesTotal),
                                "Comprimiendo: " + ev.EntriesSaved + " de " + ev.EntriesTotal + " ficheros...");
                        }
                    };
                    zip.Save(zipParcial);
                }
                if (File.Exists(zipFinal)) File.Delete(zipFinal);
                File.Move(zipParcial, zipFinal);

                // 3. Borrar copias antiguas (solo las normales, nunca las de "antes de restaurar")
                int borradas = 0;
                if (conservar > 0)
                {
                    backgroundWorker1.ReportProgress(paso(0.97), "Borrando copias antiguas...");
                    var antiguas = new DirectoryInfo(destino).GetFiles(PrefijoCopia + "*.zip")
                        .OrderByDescending(f => f.Name)
                        .Skip(conservar);
                    foreach (var f in antiguas)
                    {
                        f.Delete();
                        borradas++;
                    }
                }

                backgroundWorker1.ReportProgress(paso(1), "Copia terminada.");
                long tamano = new FileInfo(zipFinal).Length;
                return "Copia de seguridad realizada correctamente.\n\n" + zipFinal +
                       "\n(" + (tamano / 1024 / 1024.0).ToString("0.0") + " MB)" +
                       (borradas > 0 ? "\n\nSe han borrado " + borradas + " copia(s) antigua(s)." : "");
            }
            finally
            {
                try { if (File.Exists(bak)) File.Delete(bak); } catch { }
            }
        }

        /// <summary>
        /// Añade C:\ByMartin al ZIP, sin la carpeta tmp ni la carpeta donde se
        /// guardan las copias (para que cada copia no contenga las anteriores).
        /// </summary>
        private static void AñadirDocumentos(ZipFile zip, string destino)
        {
            if (!Directory.Exists(CarpetaPrograma)) return;

            var excluir = new List<string>
            {
                Path.GetFullPath(CarpetaTemporal),
                Path.GetFullPath(DestinoPorDefecto)
            };
            Func<string, bool> excluida = ruta =>
            {
                string r = Path.GetFullPath(ruta).TrimEnd('\\') + "\\";
                return excluir.Any(x => r.StartsWith(x.TrimEnd('\\') + "\\", StringComparison.OrdinalIgnoreCase));
            };

            foreach (string carpeta in Directory.GetDirectories(CarpetaPrograma))
            {
                if (!excluida(carpeta))
                {
                    zip.AddDirectory(carpeta, "ByMartin/" + Path.GetFileName(carpeta));
                }
            }
            foreach (string fichero in Directory.GetFiles(CarpetaPrograma))
            {
                zip.AddFile(fichero, "ByMartin");
            }
        }

        // =====================================================================
        //  Restaurar
        // =====================================================================

        private string Restaurar(Trabajo trabajo)
        {
            // 1. Copia de seguridad del estado actual
            backgroundWorker1.ReportProgress(0, "Haciendo copia del estado actual...");
            HacerCopia(trabajo.Destino, PrefijoSeguridad, 0, 0, 50);
            string copiaSeguridad = new DirectoryInfo(trabajo.Destino).GetFiles(PrefijoSeguridad + "*.zip")
                .OrderByDescending(f => f.Name).Select(f => f.FullName).FirstOrDefault();

            var csb = Conexion();
            string baseDatos = csb.InitialCatalog;
            string bak = Path.Combine(CarpetaTemporal, "Restaurar_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak");

            try
            {
                // 2. Sacar el .bak del ZIP
                backgroundWorker1.ReportProgress(55, "Extrayendo la copia...");
                using (var zip = ZipFile.Read(trabajo.ZipRestaurar))
                using (var salida = File.Create(bak))
                {
                    zip[trabajo.EntradaBak].Extract(salida);
                }

                // 3. Restaurar la base de datos (conectado a master)
                backgroundWorker1.ReportProgress(65, "Restaurando la base de datos...");
                csb.InitialCatalog = "master";
                SqlConnection.ClearAllPools();   // cerrar las conexiones del propio programa

                using (var con = new SqlConnection(csb.ConnectionString))
                {
                    con.Open();

                    // Ficheros que contiene la copia
                    var logicos = new List<Tuple<string, string>>();   // (nombre lógico, tipo D/L)
                    using (var cmd = new SqlCommand("RESTORE FILELISTONLY FROM DISK = @ruta", con))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@ruta", bak);
                        using (var lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                logicos.Add(Tuple.Create((string)lector["LogicalName"], (string)lector["Type"]));
                            }
                        }
                    }

                    // Dónde están ahora los ficheros de la base de datos en este equipo
                    var datos = new List<string>();
                    var registro = new List<string>();
                    using (var cmd = new SqlCommand(
                        "SELECT type, physical_name FROM sys.master_files WHERE database_id = DB_ID(@bd) ORDER BY file_id", con))
                    {
                        cmd.Parameters.AddWithValue("@bd", baseDatos);
                        using (var lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                (Convert.ToInt32(lector["type"]) == 1 ? registro : datos).Add((string)lector["physical_name"]);
                            }
                        }
                    }

                    bool existe = datos.Count > 0;
                    string carpetaDatos = existe ? Path.GetDirectoryName(datos[0]) : CarpetaDatosPorDefecto(con);

                    // MOVE: cada fichero de la copia a su sitio en este equipo
                    var move = new StringBuilder();
                    int nDatos = 0, nRegistro = 0;
                    foreach (var l in logicos)
                    {
                        bool esRegistro = l.Item2 == "L";
                        string fisico;
                        if (esRegistro)
                        {
                            fisico = nRegistro < registro.Count
                                ? registro[nRegistro]
                                : Path.Combine(carpetaDatos, baseDatos + "_log" + (nRegistro == 0 ? "" : nRegistro.ToString()) + ".ldf");
                            nRegistro++;
                        }
                        else
                        {
                            fisico = nDatos < datos.Count
                                ? datos[nDatos]
                                : Path.Combine(carpetaDatos, baseDatos + (nDatos == 0 ? "" : "_" + nDatos) + (nDatos == 0 ? ".mdf" : ".ndf"));
                            nDatos++;
                        }
                        move.Append(", MOVE N'").Append(l.Item1.Replace("'", "''"))
                            .Append("' TO N'").Append(fisico.Replace("'", "''")).Append("'");
                    }

                    if (existe)
                    {
                        Ejecutar(con, "ALTER DATABASE " + Corchetes(baseDatos) + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    }
                    try
                    {
                        using (var cmd = new SqlCommand(
                            "RESTORE DATABASE " + Corchetes(baseDatos) + " FROM DISK = @ruta WITH REPLACE" + move, con))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.AddWithValue("@ruta", bak);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    finally
                    {
                        try { Ejecutar(con, "ALTER DATABASE " + Corchetes(baseDatos) + " SET MULTI_USER"); } catch { }
                    }
                }

                // 4. Documentos (opcional): sustituye los ficheros con el mismo nombre, no borra ninguno
                int ficheros = 0;
                if (trabajo.RestaurarDocumentos)
                {
                    backgroundWorker1.ReportProgress(85, "Restaurando documentos...");
                    using (var zip = ZipFile.Read(trabajo.ZipRestaurar))
                    {
                        foreach (var entrada in zip.Entries.Where(EsDocumentoRestaurable).ToList())
                        {
                            entrada.Extract(@"C:\", ExtractExistingFileAction.OverwriteSilently);
                            ficheros++;
                        }
                    }
                }

                // 5. ¿La copia es anterior a los scripts de la carpeta SQL?
                bool antigua;
                using (var con = new SqlConnection(Conexion().ConnectionString))
                using (var cmd = new SqlCommand("SELECT CASE WHEN OBJECT_ID(N'dbo.Retenciones', N'U') IS NULL THEN 1 ELSE 0 END", con))
                {
                    con.Open();
                    antigua = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
                }

                backgroundWorker1.ReportProgress(100, "Restauración terminada.");
                return "RESTAURADO" + "Copia restaurada correctamente." +
                       (antigua ? "\n\nATENCIÓN: la copia es anterior a los cambios de la base de datos. " +
                                  "Antes de usar el programa vuelve a ejecutar, en orden, los scripts de la carpeta SQL." : "") +
                       (trabajo.RestaurarDocumentos ? "\nDocumentos restaurados: " + ficheros + "." : "") +
                       (copiaSeguridad != null ? "\n\nEl estado anterior se ha guardado en:\n" + copiaSeguridad : "");
            }
            catch (Exception ex)
            {
                throw new ErrorParaUsuario(MensajeInterno(ex) +
                    (copiaSeguridad != null ? "\n\nLa copia del estado anterior está en:\n" + copiaSeguridad : ""), ex);
            }
            finally
            {
                try { if (File.Exists(bak)) File.Delete(bak); } catch { }
            }
        }

        /// <summary>
        /// Busca la copia de la base de datos dentro del ZIP. Formato nuevo:
        /// BaseDatos/*.bak. Formato antiguo: fichero "Sql..." en la raíz o en ByMartin/tmp.
        /// </summary>
        private static ZipEntry BuscarBaseDatos(ZipFile zip)
        {
            var ficheros = zip.Entries.Where(z => !z.IsDirectory && z.UncompressedSize > 0).ToList();
            Func<ZipEntry, string> nombre = z => z.FileName.Replace('\\', '/').Split('/').Last();

            return ficheros.Where(z => z.FileName.Replace('\\', '/').StartsWith("BaseDatos/", StringComparison.OrdinalIgnoreCase)
                                       && nombre(z).EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                           .OrderByDescending(z => z.LastModified).FirstOrDefault()
                ?? ficheros.Where(z => !z.FileName.Replace('\\', '/').Contains("/")
                                       && nombre(z).StartsWith("Sql", StringComparison.OrdinalIgnoreCase))
                           .OrderByDescending(z => z.LastModified).FirstOrDefault()
                ?? ficheros.Where(z => z.FileName.Replace('\\', '/').StartsWith("ByMartin/tmp/", StringComparison.OrdinalIgnoreCase)
                                       && nombre(z).StartsWith("Sql", StringComparison.OrdinalIgnoreCase))
                           .OrderByDescending(z => z.LastModified).FirstOrDefault();
        }

        /// <summary>Documentos que se restauran: todo lo de ByMartin menos copias y temporales.</summary>
        private static bool EsDocumentoRestaurable(ZipEntry z)
        {
            string n = z.FileName.Replace('\\', '/');
            return !z.IsDirectory
                && n.StartsWith("ByMartin/", StringComparison.OrdinalIgnoreCase)
                && !n.StartsWith("ByMartin/Backup/", StringComparison.OrdinalIgnoreCase)
                && !n.StartsWith("ByMartin/tmp/", StringComparison.OrdinalIgnoreCase)
                && !n.Contains("../");
        }

        // =====================================================================
        //  Utilidades
        // =====================================================================

        /// <summary>Conexión del propio programa (App.config), válida en cualquier equipo.</summary>
        private static SqlConnectionStringBuilder Conexion()
        {
            using (var bd = new AdministracionAntonioEntities())
            {
                var csb = new SqlConnectionStringBuilder(bd.Database.Connection.ConnectionString);
                csb.DataSource = csb.DataSource.Trim();
                return csb;
            }
        }

        private static string CarpetaDatosPorDefecto(SqlConnection con)
        {
            using (var cmd = new SqlCommand("SELECT CONVERT(nvarchar(260), SERVERPROPERTY('InstanceDefaultDataPath'))", con))
            {
                var ruta = cmd.ExecuteScalar() as string;
                if (string.IsNullOrEmpty(ruta))
                {
                    throw new InvalidOperationException("No se encuentra la carpeta de datos de SQL Server.");
                }
                return ruta;
            }
        }

        private static void Ejecutar(SqlConnection con, string sql)
        {
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
            }
        }

        private static string Corchetes(string nombre)
        {
            return "[" + nombre.Replace("]", "]]") + "]";
        }

        private static string MensajeInterno(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
