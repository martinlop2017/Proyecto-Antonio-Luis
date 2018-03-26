namespace Proyecto_Antonio_Luis.Formularios
{
    partial class GestionUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionUsuarios));
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.eliminar = new System.Windows.Forms.Button();
            this.sumar = new System.Windows.Forms.Button();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.administracionAntonioDataSet2 = new Proyecto_Antonio_Luis.AdministracionAntonioDataSet2();
            this.ususariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ususariosTableAdapter = new Proyecto_Antonio_Luis.AdministracionAntonioDataSet2TableAdapters.UsusariosTableAdapter();
            this.codDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerousuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preguntaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respuestaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sistemaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.misdatosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usuariosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gusuariosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.impuestosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clientesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gclientesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.articulosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.garticulosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.albaranesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.galbaranesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.facturasDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gfacturasDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.csb19DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contaplusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.listadosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mantenimientoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.copiaseguridadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.agendaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.avisosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gavisosDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ususariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.label7.Location = new System.Drawing.Point(176, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(387, 42);
            this.label7.TabIndex = 38;
            this.label7.Text = "Gestión de Ususarios";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(631, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "&Salir";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(222, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "&Buscar";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(159, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "&Modificar";
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(106, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "&Eliminar";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "&Añadir";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.White;
            this.salir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salir.BackgroundImage")));
            this.salir.Location = new System.Drawing.Point(619, 108);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(52, 56);
            this.salir.TabIndex = 31;
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            this.salir.MouseEnter += new System.EventHandler(this.salir_MouseEnter);
            this.salir.MouseLeave += new System.EventHandler(this.salir_MouseLeave);
            // 
            // modificar
            // 
            this.modificar.BackColor = System.Drawing.Color.White;
            this.modificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("modificar.BackgroundImage")));
            this.modificar.Location = new System.Drawing.Point(158, 108);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(52, 56);
            this.modificar.TabIndex = 29;
            this.modificar.UseVisualStyleBackColor = false;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            this.modificar.MouseEnter += new System.EventHandler(this.modificar_MouseEnter);
            this.modificar.MouseLeave += new System.EventHandler(this.modificar_MouseLeave);
            // 
            // eliminar
            // 
            this.eliminar.BackColor = System.Drawing.Color.White;
            this.eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eliminar.BackgroundImage")));
            this.eliminar.Location = new System.Drawing.Point(100, 108);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(52, 56);
            this.eliminar.TabIndex = 28;
            this.eliminar.UseVisualStyleBackColor = false;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            this.eliminar.MouseEnter += new System.EventHandler(this.eliminar_MouseEnter);
            this.eliminar.MouseLeave += new System.EventHandler(this.eliminar_MouseLeave);
            // 
            // sumar
            // 
            this.sumar.BackColor = System.Drawing.Color.White;
            this.sumar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sumar.BackgroundImage")));
            this.sumar.Location = new System.Drawing.Point(42, 108);
            this.sumar.Name = "sumar";
            this.sumar.Size = new System.Drawing.Size(52, 56);
            this.sumar.TabIndex = 27;
            this.sumar.UseVisualStyleBackColor = false;
            this.sumar.Click += new System.EventHandler(this.button1_Click);
            this.sumar.MouseEnter += new System.EventHandler(this.sumar_MouseEnter);
            this.sumar.MouseLeave += new System.EventHandler(this.sumar_MouseLeave);
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.AutoGenerateColumns = false;
            this.dgvUsuario.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codDataGridViewTextBoxColumn,
            this.numerousuarioDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.activoDataGridViewTextBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.preguntaDataGridViewTextBoxColumn,
            this.respuestaDataGridViewTextBoxColumn,
            this.sistemaDataGridViewCheckBoxColumn,
            this.misdatosDataGridViewCheckBoxColumn,
            this.usuariosDataGridViewCheckBoxColumn,
            this.gusuariosDataGridViewCheckBoxColumn,
            this.impuestosDataGridViewCheckBoxColumn,
            this.clientesDataGridViewCheckBoxColumn,
            this.gclientesDataGridViewCheckBoxColumn,
            this.articulosDataGridViewCheckBoxColumn,
            this.garticulosDataGridViewCheckBoxColumn,
            this.albaranesDataGridViewCheckBoxColumn,
            this.galbaranesDataGridViewCheckBoxColumn,
            this.facturasDataGridViewCheckBoxColumn,
            this.gfacturasDataGridViewCheckBoxColumn,
            this.csb19DataGridViewCheckBoxColumn,
            this.contaplusDataGridViewCheckBoxColumn,
            this.listadosDataGridViewCheckBoxColumn,
            this.mantenimientoDataGridViewCheckBoxColumn,
            this.copiaseguridadDataGridViewCheckBoxColumn,
            this.agendaDataGridViewCheckBoxColumn,
            this.avisosDataGridViewCheckBoxColumn,
            this.gavisosDataGridViewCheckBoxColumn});
            this.dgvUsuario.DataSource = this.ususariosBindingSource;
            this.dgvUsuario.Location = new System.Drawing.Point(42, 215);
            this.dgvUsuario.MultiSelect = false;
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(616, 378);
            this.dgvUsuario.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(216, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 56);
            this.panel1.TabIndex = 52;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(377, 20);
            this.textBox1.TabIndex = 52;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            this.textBox1.MouseLeave += new System.EventHandler(this.textBox1_MouseLeave);
            // 
            // administracionAntonioDataSet2
            // 
            this.administracionAntonioDataSet2.DataSetName = "AdministracionAntonioDataSet2";
            this.administracionAntonioDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ususariosBindingSource
            // 
            this.ususariosBindingSource.DataMember = "Ususarios";
            this.ususariosBindingSource.DataSource = this.administracionAntonioDataSet2;
            // 
            // ususariosTableAdapter
            // 
            this.ususariosTableAdapter.ClearBeforeFill = true;
            // 
            // codDataGridViewTextBoxColumn
            // 
            this.codDataGridViewTextBoxColumn.DataPropertyName = "cod";
            this.codDataGridViewTextBoxColumn.HeaderText = "cod";
            this.codDataGridViewTextBoxColumn.Name = "codDataGridViewTextBoxColumn";
            this.codDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numerousuarioDataGridViewTextBoxColumn
            // 
            this.numerousuarioDataGridViewTextBoxColumn.DataPropertyName = "numerousuario";
            this.numerousuarioDataGridViewTextBoxColumn.HeaderText = "numerousuario";
            this.numerousuarioDataGridViewTextBoxColumn.Name = "numerousuarioDataGridViewTextBoxColumn";
            this.numerousuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "login";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activoDataGridViewTextBoxColumn
            // 
            this.activoDataGridViewTextBoxColumn.DataPropertyName = "activo";
            this.activoDataGridViewTextBoxColumn.HeaderText = "activo";
            this.activoDataGridViewTextBoxColumn.Name = "activoDataGridViewTextBoxColumn";
            this.activoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // grupoDataGridViewTextBoxColumn
            // 
            this.grupoDataGridViewTextBoxColumn.DataPropertyName = "grupo";
            this.grupoDataGridViewTextBoxColumn.HeaderText = "grupo";
            this.grupoDataGridViewTextBoxColumn.Name = "grupoDataGridViewTextBoxColumn";
            this.grupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // preguntaDataGridViewTextBoxColumn
            // 
            this.preguntaDataGridViewTextBoxColumn.DataPropertyName = "pregunta";
            this.preguntaDataGridViewTextBoxColumn.HeaderText = "pregunta";
            this.preguntaDataGridViewTextBoxColumn.Name = "preguntaDataGridViewTextBoxColumn";
            this.preguntaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // respuestaDataGridViewTextBoxColumn
            // 
            this.respuestaDataGridViewTextBoxColumn.DataPropertyName = "respuesta";
            this.respuestaDataGridViewTextBoxColumn.HeaderText = "respuesta";
            this.respuestaDataGridViewTextBoxColumn.Name = "respuestaDataGridViewTextBoxColumn";
            this.respuestaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sistemaDataGridViewCheckBoxColumn
            // 
            this.sistemaDataGridViewCheckBoxColumn.DataPropertyName = "sistema";
            this.sistemaDataGridViewCheckBoxColumn.HeaderText = "sistema";
            this.sistemaDataGridViewCheckBoxColumn.Name = "sistemaDataGridViewCheckBoxColumn";
            this.sistemaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // misdatosDataGridViewCheckBoxColumn
            // 
            this.misdatosDataGridViewCheckBoxColumn.DataPropertyName = "misdatos";
            this.misdatosDataGridViewCheckBoxColumn.HeaderText = "misdatos";
            this.misdatosDataGridViewCheckBoxColumn.Name = "misdatosDataGridViewCheckBoxColumn";
            this.misdatosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // usuariosDataGridViewCheckBoxColumn
            // 
            this.usuariosDataGridViewCheckBoxColumn.DataPropertyName = "usuarios";
            this.usuariosDataGridViewCheckBoxColumn.HeaderText = "usuarios";
            this.usuariosDataGridViewCheckBoxColumn.Name = "usuariosDataGridViewCheckBoxColumn";
            this.usuariosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // gusuariosDataGridViewCheckBoxColumn
            // 
            this.gusuariosDataGridViewCheckBoxColumn.DataPropertyName = "gusuarios";
            this.gusuariosDataGridViewCheckBoxColumn.HeaderText = "gusuarios";
            this.gusuariosDataGridViewCheckBoxColumn.Name = "gusuariosDataGridViewCheckBoxColumn";
            this.gusuariosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // impuestosDataGridViewCheckBoxColumn
            // 
            this.impuestosDataGridViewCheckBoxColumn.DataPropertyName = "impuestos";
            this.impuestosDataGridViewCheckBoxColumn.HeaderText = "impuestos";
            this.impuestosDataGridViewCheckBoxColumn.Name = "impuestosDataGridViewCheckBoxColumn";
            this.impuestosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // clientesDataGridViewCheckBoxColumn
            // 
            this.clientesDataGridViewCheckBoxColumn.DataPropertyName = "clientes";
            this.clientesDataGridViewCheckBoxColumn.HeaderText = "clientes";
            this.clientesDataGridViewCheckBoxColumn.Name = "clientesDataGridViewCheckBoxColumn";
            this.clientesDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // gclientesDataGridViewCheckBoxColumn
            // 
            this.gclientesDataGridViewCheckBoxColumn.DataPropertyName = "gclientes";
            this.gclientesDataGridViewCheckBoxColumn.HeaderText = "gclientes";
            this.gclientesDataGridViewCheckBoxColumn.Name = "gclientesDataGridViewCheckBoxColumn";
            this.gclientesDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // articulosDataGridViewCheckBoxColumn
            // 
            this.articulosDataGridViewCheckBoxColumn.DataPropertyName = "articulos";
            this.articulosDataGridViewCheckBoxColumn.HeaderText = "articulos";
            this.articulosDataGridViewCheckBoxColumn.Name = "articulosDataGridViewCheckBoxColumn";
            this.articulosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // garticulosDataGridViewCheckBoxColumn
            // 
            this.garticulosDataGridViewCheckBoxColumn.DataPropertyName = "garticulos";
            this.garticulosDataGridViewCheckBoxColumn.HeaderText = "garticulos";
            this.garticulosDataGridViewCheckBoxColumn.Name = "garticulosDataGridViewCheckBoxColumn";
            this.garticulosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // albaranesDataGridViewCheckBoxColumn
            // 
            this.albaranesDataGridViewCheckBoxColumn.DataPropertyName = "albaranes";
            this.albaranesDataGridViewCheckBoxColumn.HeaderText = "albaranes";
            this.albaranesDataGridViewCheckBoxColumn.Name = "albaranesDataGridViewCheckBoxColumn";
            this.albaranesDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // galbaranesDataGridViewCheckBoxColumn
            // 
            this.galbaranesDataGridViewCheckBoxColumn.DataPropertyName = "galbaranes";
            this.galbaranesDataGridViewCheckBoxColumn.HeaderText = "galbaranes";
            this.galbaranesDataGridViewCheckBoxColumn.Name = "galbaranesDataGridViewCheckBoxColumn";
            this.galbaranesDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // facturasDataGridViewCheckBoxColumn
            // 
            this.facturasDataGridViewCheckBoxColumn.DataPropertyName = "facturas";
            this.facturasDataGridViewCheckBoxColumn.HeaderText = "facturas";
            this.facturasDataGridViewCheckBoxColumn.Name = "facturasDataGridViewCheckBoxColumn";
            this.facturasDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // gfacturasDataGridViewCheckBoxColumn
            // 
            this.gfacturasDataGridViewCheckBoxColumn.DataPropertyName = "gfacturas";
            this.gfacturasDataGridViewCheckBoxColumn.HeaderText = "gfacturas";
            this.gfacturasDataGridViewCheckBoxColumn.Name = "gfacturasDataGridViewCheckBoxColumn";
            this.gfacturasDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // csb19DataGridViewCheckBoxColumn
            // 
            this.csb19DataGridViewCheckBoxColumn.DataPropertyName = "csb19";
            this.csb19DataGridViewCheckBoxColumn.HeaderText = "csb19";
            this.csb19DataGridViewCheckBoxColumn.Name = "csb19DataGridViewCheckBoxColumn";
            this.csb19DataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // contaplusDataGridViewCheckBoxColumn
            // 
            this.contaplusDataGridViewCheckBoxColumn.DataPropertyName = "contaplus";
            this.contaplusDataGridViewCheckBoxColumn.HeaderText = "contaplus";
            this.contaplusDataGridViewCheckBoxColumn.Name = "contaplusDataGridViewCheckBoxColumn";
            this.contaplusDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // listadosDataGridViewCheckBoxColumn
            // 
            this.listadosDataGridViewCheckBoxColumn.DataPropertyName = "listados";
            this.listadosDataGridViewCheckBoxColumn.HeaderText = "listados";
            this.listadosDataGridViewCheckBoxColumn.Name = "listadosDataGridViewCheckBoxColumn";
            this.listadosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // mantenimientoDataGridViewCheckBoxColumn
            // 
            this.mantenimientoDataGridViewCheckBoxColumn.DataPropertyName = "mantenimiento";
            this.mantenimientoDataGridViewCheckBoxColumn.HeaderText = "mantenimiento";
            this.mantenimientoDataGridViewCheckBoxColumn.Name = "mantenimientoDataGridViewCheckBoxColumn";
            this.mantenimientoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // copiaseguridadDataGridViewCheckBoxColumn
            // 
            this.copiaseguridadDataGridViewCheckBoxColumn.DataPropertyName = "copiaseguridad";
            this.copiaseguridadDataGridViewCheckBoxColumn.HeaderText = "copiaseguridad";
            this.copiaseguridadDataGridViewCheckBoxColumn.Name = "copiaseguridadDataGridViewCheckBoxColumn";
            this.copiaseguridadDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // agendaDataGridViewCheckBoxColumn
            // 
            this.agendaDataGridViewCheckBoxColumn.DataPropertyName = "agenda";
            this.agendaDataGridViewCheckBoxColumn.HeaderText = "agenda";
            this.agendaDataGridViewCheckBoxColumn.Name = "agendaDataGridViewCheckBoxColumn";
            this.agendaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // avisosDataGridViewCheckBoxColumn
            // 
            this.avisosDataGridViewCheckBoxColumn.DataPropertyName = "avisos";
            this.avisosDataGridViewCheckBoxColumn.HeaderText = "avisos";
            this.avisosDataGridViewCheckBoxColumn.Name = "avisosDataGridViewCheckBoxColumn";
            this.avisosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // gavisosDataGridViewCheckBoxColumn
            // 
            this.gavisosDataGridViewCheckBoxColumn.DataPropertyName = "gavisos";
            this.gavisosDataGridViewCheckBoxColumn.HeaderText = "gavisos";
            this.gavisosDataGridViewCheckBoxColumn.Name = "gavisosDataGridViewCheckBoxColumn";
            this.gavisosDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(704, 644);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.sumar);
            this.Name = "GestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionUsuarios";
            this.Activated += new System.EventHandler(this.GestionUsuarios_Activated);
            this.Load += new System.EventHandler(this.GestionUsuarios_Load);
            this.Enter += new System.EventHandler(this.GestionUsuarios_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ususariosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private AdministracionAntonioDataSet2 administracionAntonioDataSet2;
        private System.Windows.Forms.BindingSource ususariosBindingSource;
        private AdministracionAntonioDataSet2TableAdapters.UsusariosTableAdapter ususariosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn codDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerousuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preguntaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn respuestaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sistemaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn misdatosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn usuariosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gusuariosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn impuestosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clientesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gclientesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn articulosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn garticulosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn albaranesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn galbaranesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn facturasDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gfacturasDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn csb19DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn contaplusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn listadosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mantenimientoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn copiaseguridadDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn agendaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn avisosDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gavisosDataGridViewCheckBoxColumn;
    }
}