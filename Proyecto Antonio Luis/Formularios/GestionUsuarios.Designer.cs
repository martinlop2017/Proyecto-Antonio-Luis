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
            this.buscar = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.eliminar = new System.Windows.Forms.Button();
            this.sumar = new System.Windows.Forms.Button();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.ususariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preguntaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respuestaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sistemaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.misdatosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuariosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gusuariosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impuestosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gclientesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articulosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.garticulosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albaranesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.galbaranesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gfacturasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csb19DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contaplusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mantenimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copiaseguridadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avisosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gavisosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
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
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.White;
            this.buscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buscar.BackgroundImage")));
            this.buscar.Location = new System.Drawing.Point(216, 108);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(52, 56);
            this.buscar.TabIndex = 30;
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            this.buscar.MouseEnter += new System.EventHandler(this.buscar_MouseEnter);
            this.buscar.MouseLeave += new System.EventHandler(this.buscar_MouseLeave);
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
            this.nombreDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.activoDataGridViewTextBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.preguntaDataGridViewTextBoxColumn,
            this.respuestaDataGridViewTextBoxColumn,
            this.sistemaDataGridViewTextBoxColumn,
            this.misdatosDataGridViewTextBoxColumn,
            this.usuariosDataGridViewTextBoxColumn,
            this.gusuariosDataGridViewTextBoxColumn,
            this.impuestosDataGridViewTextBoxColumn,
            this.clientesDataGridViewTextBoxColumn,
            this.gclientesDataGridViewTextBoxColumn,
            this.articulosDataGridViewTextBoxColumn,
            this.garticulosDataGridViewTextBoxColumn,
            this.albaranesDataGridViewTextBoxColumn,
            this.galbaranesDataGridViewTextBoxColumn,
            this.facturasDataGridViewTextBoxColumn,
            this.gfacturasDataGridViewTextBoxColumn,
            this.csb19DataGridViewTextBoxColumn,
            this.contaplusDataGridViewTextBoxColumn,
            this.listadosDataGridViewTextBoxColumn,
            this.mantenimientoDataGridViewTextBoxColumn,
            this.copiaseguridadDataGridViewTextBoxColumn,
            this.agendaDataGridViewTextBoxColumn,
            this.avisosDataGridViewTextBoxColumn,
            this.gavisosDataGridViewTextBoxColumn});
            this.dgvUsuario.DataSource = this.ususariosBindingSource;
            this.dgvUsuario.Location = new System.Drawing.Point(42, 215);
            this.dgvUsuario.MultiSelect = false;
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(616, 378);
            this.dgvUsuario.TabIndex = 39;
            // 
            // ususariosBindingSource
            // 
            this.ususariosBindingSource.DataSource = typeof(BaseDatos.Ususarios);
            // 
            // codDataGridViewTextBoxColumn
            // 
            this.codDataGridViewTextBoxColumn.DataPropertyName = "cod";
            this.codDataGridViewTextBoxColumn.HeaderText = "cod";
            this.codDataGridViewTextBoxColumn.Name = "codDataGridViewTextBoxColumn";
            this.codDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.loginDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // activoDataGridViewTextBoxColumn
            // 
            this.activoDataGridViewTextBoxColumn.DataPropertyName = "activo";
            this.activoDataGridViewTextBoxColumn.HeaderText = "activo";
            this.activoDataGridViewTextBoxColumn.Name = "activoDataGridViewTextBoxColumn";
            this.activoDataGridViewTextBoxColumn.ReadOnly = true;
            this.activoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // sistemaDataGridViewTextBoxColumn
            // 
            this.sistemaDataGridViewTextBoxColumn.DataPropertyName = "sistema";
            this.sistemaDataGridViewTextBoxColumn.HeaderText = "sistema";
            this.sistemaDataGridViewTextBoxColumn.Name = "sistemaDataGridViewTextBoxColumn";
            this.sistemaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // misdatosDataGridViewTextBoxColumn
            // 
            this.misdatosDataGridViewTextBoxColumn.DataPropertyName = "misdatos";
            this.misdatosDataGridViewTextBoxColumn.HeaderText = "misdatos";
            this.misdatosDataGridViewTextBoxColumn.Name = "misdatosDataGridViewTextBoxColumn";
            this.misdatosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuariosDataGridViewTextBoxColumn
            // 
            this.usuariosDataGridViewTextBoxColumn.DataPropertyName = "usuarios";
            this.usuariosDataGridViewTextBoxColumn.HeaderText = "usuarios";
            this.usuariosDataGridViewTextBoxColumn.Name = "usuariosDataGridViewTextBoxColumn";
            this.usuariosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gusuariosDataGridViewTextBoxColumn
            // 
            this.gusuariosDataGridViewTextBoxColumn.DataPropertyName = "gusuarios";
            this.gusuariosDataGridViewTextBoxColumn.HeaderText = "gusuarios";
            this.gusuariosDataGridViewTextBoxColumn.Name = "gusuariosDataGridViewTextBoxColumn";
            this.gusuariosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impuestosDataGridViewTextBoxColumn
            // 
            this.impuestosDataGridViewTextBoxColumn.DataPropertyName = "impuestos";
            this.impuestosDataGridViewTextBoxColumn.HeaderText = "impuestos";
            this.impuestosDataGridViewTextBoxColumn.Name = "impuestosDataGridViewTextBoxColumn";
            this.impuestosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientesDataGridViewTextBoxColumn
            // 
            this.clientesDataGridViewTextBoxColumn.DataPropertyName = "clientes";
            this.clientesDataGridViewTextBoxColumn.HeaderText = "clientes";
            this.clientesDataGridViewTextBoxColumn.Name = "clientesDataGridViewTextBoxColumn";
            this.clientesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gclientesDataGridViewTextBoxColumn
            // 
            this.gclientesDataGridViewTextBoxColumn.DataPropertyName = "gclientes";
            this.gclientesDataGridViewTextBoxColumn.HeaderText = "gclientes";
            this.gclientesDataGridViewTextBoxColumn.Name = "gclientesDataGridViewTextBoxColumn";
            this.gclientesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // articulosDataGridViewTextBoxColumn
            // 
            this.articulosDataGridViewTextBoxColumn.DataPropertyName = "articulos";
            this.articulosDataGridViewTextBoxColumn.HeaderText = "articulos";
            this.articulosDataGridViewTextBoxColumn.Name = "articulosDataGridViewTextBoxColumn";
            this.articulosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // garticulosDataGridViewTextBoxColumn
            // 
            this.garticulosDataGridViewTextBoxColumn.DataPropertyName = "garticulos";
            this.garticulosDataGridViewTextBoxColumn.HeaderText = "garticulos";
            this.garticulosDataGridViewTextBoxColumn.Name = "garticulosDataGridViewTextBoxColumn";
            this.garticulosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // albaranesDataGridViewTextBoxColumn
            // 
            this.albaranesDataGridViewTextBoxColumn.DataPropertyName = "albaranes";
            this.albaranesDataGridViewTextBoxColumn.HeaderText = "albaranes";
            this.albaranesDataGridViewTextBoxColumn.Name = "albaranesDataGridViewTextBoxColumn";
            this.albaranesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // galbaranesDataGridViewTextBoxColumn
            // 
            this.galbaranesDataGridViewTextBoxColumn.DataPropertyName = "galbaranes";
            this.galbaranesDataGridViewTextBoxColumn.HeaderText = "galbaranes";
            this.galbaranesDataGridViewTextBoxColumn.Name = "galbaranesDataGridViewTextBoxColumn";
            this.galbaranesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // facturasDataGridViewTextBoxColumn
            // 
            this.facturasDataGridViewTextBoxColumn.DataPropertyName = "facturas";
            this.facturasDataGridViewTextBoxColumn.HeaderText = "facturas";
            this.facturasDataGridViewTextBoxColumn.Name = "facturasDataGridViewTextBoxColumn";
            this.facturasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gfacturasDataGridViewTextBoxColumn
            // 
            this.gfacturasDataGridViewTextBoxColumn.DataPropertyName = "gfacturas";
            this.gfacturasDataGridViewTextBoxColumn.HeaderText = "gfacturas";
            this.gfacturasDataGridViewTextBoxColumn.Name = "gfacturasDataGridViewTextBoxColumn";
            this.gfacturasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // csb19DataGridViewTextBoxColumn
            // 
            this.csb19DataGridViewTextBoxColumn.DataPropertyName = "csb19";
            this.csb19DataGridViewTextBoxColumn.HeaderText = "csb19";
            this.csb19DataGridViewTextBoxColumn.Name = "csb19DataGridViewTextBoxColumn";
            this.csb19DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contaplusDataGridViewTextBoxColumn
            // 
            this.contaplusDataGridViewTextBoxColumn.DataPropertyName = "contaplus";
            this.contaplusDataGridViewTextBoxColumn.HeaderText = "contaplus";
            this.contaplusDataGridViewTextBoxColumn.Name = "contaplusDataGridViewTextBoxColumn";
            this.contaplusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // listadosDataGridViewTextBoxColumn
            // 
            this.listadosDataGridViewTextBoxColumn.DataPropertyName = "listados";
            this.listadosDataGridViewTextBoxColumn.HeaderText = "listados";
            this.listadosDataGridViewTextBoxColumn.Name = "listadosDataGridViewTextBoxColumn";
            this.listadosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mantenimientoDataGridViewTextBoxColumn
            // 
            this.mantenimientoDataGridViewTextBoxColumn.DataPropertyName = "mantenimiento";
            this.mantenimientoDataGridViewTextBoxColumn.HeaderText = "mantenimiento";
            this.mantenimientoDataGridViewTextBoxColumn.Name = "mantenimientoDataGridViewTextBoxColumn";
            this.mantenimientoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // copiaseguridadDataGridViewTextBoxColumn
            // 
            this.copiaseguridadDataGridViewTextBoxColumn.DataPropertyName = "copiaseguridad";
            this.copiaseguridadDataGridViewTextBoxColumn.HeaderText = "copiaseguridad";
            this.copiaseguridadDataGridViewTextBoxColumn.Name = "copiaseguridadDataGridViewTextBoxColumn";
            this.copiaseguridadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // agendaDataGridViewTextBoxColumn
            // 
            this.agendaDataGridViewTextBoxColumn.DataPropertyName = "agenda";
            this.agendaDataGridViewTextBoxColumn.HeaderText = "agenda";
            this.agendaDataGridViewTextBoxColumn.Name = "agendaDataGridViewTextBoxColumn";
            this.agendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // avisosDataGridViewTextBoxColumn
            // 
            this.avisosDataGridViewTextBoxColumn.DataPropertyName = "avisos";
            this.avisosDataGridViewTextBoxColumn.HeaderText = "avisos";
            this.avisosDataGridViewTextBoxColumn.Name = "avisosDataGridViewTextBoxColumn";
            this.avisosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gavisosDataGridViewTextBoxColumn
            // 
            this.gavisosDataGridViewTextBoxColumn.DataPropertyName = "gavisos";
            this.gavisosDataGridViewTextBoxColumn.HeaderText = "gavisos";
            this.gavisosDataGridViewTextBoxColumn.Name = "gavisosDataGridViewTextBoxColumn";
            this.gavisosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(704, 644);
            this.ControlBox = false;
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.buscar);
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
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.BindingSource ususariosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preguntaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn respuestaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sistemaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn misdatosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuariosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gusuariosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impuestosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gclientesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articulosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn garticulosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn albaranesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn galbaranesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gfacturasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn csb19DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contaplusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn listadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mantenimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn copiaseguridadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avisosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gavisosDataGridViewTextBoxColumn;
    }
}