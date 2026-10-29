namespace Proyecto_Antonio_Luis.Formularios
{
    partial class ConfiguracionCorreo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracionCorreo));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelServidor = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.labelPuerto = new System.Windows.Forms.Label();
            this.numPuerto = new System.Windows.Forms.NumericUpDown();
            this.checkCifrado = new System.Windows.Forms.CheckBox();
            this.labelAyudaPuerto = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.labelClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.labelRemitente = new System.Windows.Forms.Label();
            this.txtRemitente = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelCopia = new System.Windows.Forms.Label();
            this.txtCopia = new System.Windows.Forms.TextBox();
            this.labelAsunto = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.labelTexto = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.labelCampos = new System.Windows.Forms.Label();
            this.checkAcuseLectura = new System.Windows.Forms.CheckBox();
            this.checkAcuseEntrega = new System.Windows.Forms.CheckBox();
            this.labelAcuses = new System.Windows.Forms.Label();
            this.groupServidor = new System.Windows.Forms.GroupBox();
            this.groupRemitente = new System.Windows.Forms.GroupBox();
            this.groupMensaje = new System.Windows.Forms.GroupBox();
            this.buttonProbar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupServidor.SuspendLayout();
            this.groupRemitente.SuspendLayout();
            this.groupMensaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuerto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Font = new System.Drawing.Font("Tahoma", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.labelTitulo.Location = new System.Drawing.Point(150, 14);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Correo de envío";
            // 
            // labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.BackColor = System.Drawing.Color.Transparent;
            this.labelServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServidor.Location = new System.Drawing.Point(15, 30);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.TabIndex = 2;
            this.labelServidor.Text = "Servidor SMTP";
            // 
            // txtServidor
            // 
            this.txtServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidor.Location = new System.Drawing.Point(130, 27);
            this.txtServidor.MaxLength = 150;
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(250, 22);
            this.txtServidor.TabIndex = 3;
            // 
            // labelPuerto
            // 
            this.labelPuerto.AutoSize = true;
            this.labelPuerto.BackColor = System.Drawing.Color.Transparent;
            this.labelPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPuerto.Location = new System.Drawing.Point(400, 30);
            this.labelPuerto.Name = "labelPuerto";
            this.labelPuerto.TabIndex = 4;
            this.labelPuerto.Text = "Puerto";
            // 
            // numPuerto
            // 
            this.numPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPuerto.Location = new System.Drawing.Point(460, 27);
            this.numPuerto.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.numPuerto.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPuerto.Name = "numPuerto";
            this.numPuerto.Size = new System.Drawing.Size(80, 22);
            this.numPuerto.TabIndex = 5;
            this.numPuerto.Value = new decimal(new int[] { 587, 0, 0, 0 });
            // 
            // checkCifrado
            // 
            this.checkCifrado.AutoSize = true;
            this.checkCifrado.BackColor = System.Drawing.Color.Transparent;
            this.checkCifrado.Checked = true;
            this.checkCifrado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCifrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCifrado.Location = new System.Drawing.Point(130, 58);
            this.checkCifrado.Name = "checkCifrado";
            this.checkCifrado.TabIndex = 6;
            this.checkCifrado.Text = "Conexión cifrada (STARTTLS)";
            this.checkCifrado.UseVisualStyleBackColor = false;
            // 
            // labelAyudaPuerto
            // 
            this.labelAyudaPuerto.AutoSize = true;
            this.labelAyudaPuerto.BackColor = System.Drawing.Color.Transparent;
            this.labelAyudaPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAyudaPuerto.ForeColor = System.Drawing.Color.DimGray;
            this.labelAyudaPuerto.Location = new System.Drawing.Point(345, 60);
            this.labelAyudaPuerto.Name = "labelAyudaPuerto";
            this.labelAyudaPuerto.TabIndex = 7;
            this.labelAyudaPuerto.Text = "Lo normal: puerto 587 con conexión cifrada.";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.BackColor = System.Drawing.Color.Transparent;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(15, 92);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.TabIndex = 8;
            this.labelUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(130, 89);
            this.txtUsuario.MaxLength = 150;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(200, 22);
            this.txtUsuario.TabIndex = 9;
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.BackColor = System.Drawing.Color.Transparent;
            this.labelClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.Location = new System.Drawing.Point(345, 92);
            this.labelClave.Name = "labelClave";
            this.labelClave.TabIndex = 10;
            this.labelClave.Text = "Contraseña";
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(430, 89);
            this.txtClave.MaxLength = 200;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(110, 22);
            this.txtClave.TabIndex = 11;
            // 
            // labelRemitente
            // 
            this.labelRemitente.AutoSize = true;
            this.labelRemitente.BackColor = System.Drawing.Color.Transparent;
            this.labelRemitente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemitente.Location = new System.Drawing.Point(15, 30);
            this.labelRemitente.Name = "labelRemitente";
            this.labelRemitente.TabIndex = 12;
            this.labelRemitente.Text = "Email remitente";
            // 
            // txtRemitente
            // 
            this.txtRemitente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemitente.Location = new System.Drawing.Point(130, 27);
            this.txtRemitente.MaxLength = 150;
            this.txtRemitente.Name = "txtRemitente";
            this.txtRemitente.Size = new System.Drawing.Size(410, 22);
            this.txtRemitente.TabIndex = 13;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.BackColor = System.Drawing.Color.Transparent;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(15, 62);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.TabIndex = 14;
            this.labelNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(130, 59);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(410, 22);
            this.txtNombre.TabIndex = 15;
            // 
            // labelCopia
            // 
            this.labelCopia.AutoSize = true;
            this.labelCopia.BackColor = System.Drawing.Color.Transparent;
            this.labelCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopia.Location = new System.Drawing.Point(15, 94);
            this.labelCopia.Name = "labelCopia";
            this.labelCopia.TabIndex = 16;
            this.labelCopia.Text = "Copia oculta";
            // 
            // txtCopia
            // 
            this.txtCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopia.Location = new System.Drawing.Point(130, 91);
            this.txtCopia.MaxLength = 150;
            this.txtCopia.Name = "txtCopia";
            this.txtCopia.Size = new System.Drawing.Size(410, 22);
            this.txtCopia.TabIndex = 17;
            // 
            // labelAsunto
            // 
            this.labelAsunto.AutoSize = true;
            this.labelAsunto.BackColor = System.Drawing.Color.Transparent;
            this.labelAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAsunto.Location = new System.Drawing.Point(15, 30);
            this.labelAsunto.Name = "labelAsunto";
            this.labelAsunto.TabIndex = 18;
            this.labelAsunto.Text = "Asunto";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsunto.Location = new System.Drawing.Point(130, 27);
            this.txtAsunto.MaxLength = 250;
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(410, 22);
            this.txtAsunto.TabIndex = 19;
            // 
            // labelTexto
            // 
            this.labelTexto.AutoSize = true;
            this.labelTexto.BackColor = System.Drawing.Color.Transparent;
            this.labelTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto.Location = new System.Drawing.Point(15, 62);
            this.labelTexto.Name = "labelTexto";
            this.labelTexto.TabIndex = 20;
            this.labelTexto.Text = "Texto";
            // 
            // txtTexto
            // 
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(130, 59);
            this.txtTexto.Multiline = true;
            this.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTexto.AcceptsReturn = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(410, 90);
            this.txtTexto.TabIndex = 21;
            // 
            // labelCampos
            // 
            this.labelCampos.AutoSize = true;
            this.labelCampos.BackColor = System.Drawing.Color.Transparent;
            this.labelCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCampos.ForeColor = System.Drawing.Color.DimGray;
            this.labelCampos.Location = new System.Drawing.Point(128, 153);
            this.labelCampos.Name = "labelCampos";
            this.labelCampos.TabIndex = 22;
            this.labelCampos.Text = "Se puede usar: {numero} {fecha} {total} {cliente} {emisor} {remesa}";
            // 
            // checkAcuseLectura
            // 
            this.checkAcuseLectura.AutoSize = true;
            this.checkAcuseLectura.BackColor = System.Drawing.Color.Transparent;
            this.checkAcuseLectura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAcuseLectura.Location = new System.Drawing.Point(130, 176);
            this.checkAcuseLectura.Name = "checkAcuseLectura";
            this.checkAcuseLectura.TabIndex = 23;
            this.checkAcuseLectura.Text = "Pedir confirmación de lectura";
            this.checkAcuseLectura.UseVisualStyleBackColor = false;
            // 
            // checkAcuseEntrega
            // 
            this.checkAcuseEntrega.AutoSize = true;
            this.checkAcuseEntrega.BackColor = System.Drawing.Color.Transparent;
            this.checkAcuseEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAcuseEntrega.Location = new System.Drawing.Point(350, 176);
            this.checkAcuseEntrega.Name = "checkAcuseEntrega";
            this.checkAcuseEntrega.TabIndex = 24;
            this.checkAcuseEntrega.Text = "Pedir aviso de entrega";
            this.checkAcuseEntrega.UseVisualStyleBackColor = false;
            // 
            // labelAcuses
            // 
            this.labelAcuses.AutoSize = true;
            this.labelAcuses.BackColor = System.Drawing.Color.Transparent;
            this.labelAcuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAcuses.ForeColor = System.Drawing.Color.DimGray;
            this.labelAcuses.Location = new System.Drawing.Point(128, 200);
            this.labelAcuses.Name = "labelAcuses";
            this.labelAcuses.TabIndex = 25;
            this.labelAcuses.Text = "Llegan al buzón del remitente; el cliente o su servidor pueden no enviarlas.";
            // 
            // groupServidor
            // 
            this.groupServidor.BackColor = System.Drawing.Color.Transparent;
            this.groupServidor.Controls.Add(this.labelServidor);
            this.groupServidor.Controls.Add(this.txtServidor);
            this.groupServidor.Controls.Add(this.labelPuerto);
            this.groupServidor.Controls.Add(this.numPuerto);
            this.groupServidor.Controls.Add(this.checkCifrado);
            this.groupServidor.Controls.Add(this.labelAyudaPuerto);
            this.groupServidor.Controls.Add(this.labelUsuario);
            this.groupServidor.Controls.Add(this.txtUsuario);
            this.groupServidor.Controls.Add(this.labelClave);
            this.groupServidor.Controls.Add(this.txtClave);
            this.groupServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupServidor.Location = new System.Drawing.Point(30, 75);
            this.groupServidor.Name = "groupServidor";
            this.groupServidor.Size = new System.Drawing.Size(560, 125);
            this.groupServidor.TabIndex = 26;
            this.groupServidor.TabStop = false;
            this.groupServidor.Text = "Servidor de correo";
            // 
            // groupRemitente
            // 
            this.groupRemitente.BackColor = System.Drawing.Color.Transparent;
            this.groupRemitente.Controls.Add(this.labelRemitente);
            this.groupRemitente.Controls.Add(this.txtRemitente);
            this.groupRemitente.Controls.Add(this.labelNombre);
            this.groupRemitente.Controls.Add(this.txtNombre);
            this.groupRemitente.Controls.Add(this.labelCopia);
            this.groupRemitente.Controls.Add(this.txtCopia);
            this.groupRemitente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRemitente.Location = new System.Drawing.Point(30, 208);
            this.groupRemitente.Name = "groupRemitente";
            this.groupRemitente.Size = new System.Drawing.Size(560, 125);
            this.groupRemitente.TabIndex = 27;
            this.groupRemitente.TabStop = false;
            this.groupRemitente.Text = "Remitente";
            // 
            // groupMensaje
            // 
            this.groupMensaje.BackColor = System.Drawing.Color.Transparent;
            this.groupMensaje.Controls.Add(this.labelAsunto);
            this.groupMensaje.Controls.Add(this.txtAsunto);
            this.groupMensaje.Controls.Add(this.labelTexto);
            this.groupMensaje.Controls.Add(this.txtTexto);
            this.groupMensaje.Controls.Add(this.labelCampos);
            this.groupMensaje.Controls.Add(this.checkAcuseLectura);
            this.groupMensaje.Controls.Add(this.checkAcuseEntrega);
            this.groupMensaje.Controls.Add(this.labelAcuses);
            this.groupMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupMensaje.Location = new System.Drawing.Point(30, 341);
            this.groupMensaje.Name = "groupMensaje";
            this.groupMensaje.Size = new System.Drawing.Size(560, 222);
            this.groupMensaje.TabIndex = 28;
            this.groupMensaje.TabStop = false;
            this.groupMensaje.Text = "Mensaje con la factura";
            // 
            // buttonProbar
            // 
            this.buttonProbar.BackColor = System.Drawing.Color.White;
            this.buttonProbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.buttonProbar.Location = new System.Drawing.Point(30, 592);
            this.buttonProbar.Name = "buttonProbar";
            this.buttonProbar.Size = new System.Drawing.Size(150, 44);
            this.buttonProbar.TabIndex = 29;
            this.buttonProbar.Text = "Enviar prueba";
            this.buttonProbar.UseVisualStyleBackColor = false;
            this.buttonProbar.Click += new System.EventHandler(this.buttonProbar_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(215, 585);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 56);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(405, 585);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 56);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConfiguracionCorreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(620, 657);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonProbar);
            this.Controls.Add(this.groupMensaje);
            this.Controls.Add(this.groupRemitente);
            this.Controls.Add(this.groupServidor);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguracionCorreo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "eGESTION - Correo de envío";
            this.Load += new System.EventHandler(this.ConfiguracionCorreo_Load);
            this.groupServidor.ResumeLayout(false);
            this.groupServidor.PerformLayout();
            this.groupRemitente.ResumeLayout(false);
            this.groupRemitente.PerformLayout();
            this.groupMensaje.ResumeLayout(false);
            this.groupMensaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuerto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelServidor;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label labelPuerto;
        private System.Windows.Forms.NumericUpDown numPuerto;
        private System.Windows.Forms.CheckBox checkCifrado;
        private System.Windows.Forms.Label labelAyudaPuerto;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label labelRemitente;
        private System.Windows.Forms.TextBox txtRemitente;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelCopia;
        private System.Windows.Forms.TextBox txtCopia;
        private System.Windows.Forms.Label labelAsunto;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label labelTexto;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label labelCampos;
        private System.Windows.Forms.CheckBox checkAcuseLectura;
        private System.Windows.Forms.CheckBox checkAcuseEntrega;
        private System.Windows.Forms.Label labelAcuses;
        private System.Windows.Forms.GroupBox groupServidor;
        private System.Windows.Forms.GroupBox groupRemitente;
        private System.Windows.Forms.GroupBox groupMensaje;
        private System.Windows.Forms.Button buttonProbar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
