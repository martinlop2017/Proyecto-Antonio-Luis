namespace Proyecto_Antonio_Luis.Formularios
{
    partial class GestionFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionFacturas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelEnviar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelEjercicio = new System.Windows.Forms.Label();
            this.labelSerie = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sumar = new System.Windows.Forms.Button();
            this.imprimir = new System.Windows.Forms.Button();
            this.enviar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboEjercicio = new System.Windows.Forms.ComboBox();
            this.panelEjercicio = new System.Windows.Forms.Panel();
            this.comboSerie = new System.Windows.Forms.ComboBox();
            this.panelSerie = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.salir = new System.Windows.Forms.Button();
            this.dgvfactura = new System.Windows.Forms.DataGridView();
            this.labelResumen = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelEjercicio.SuspendLayout();
            this.panelSerie.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfactura)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.label7.Location = new System.Drawing.Point(252, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(366, 42);
            this.label7.TabIndex = 51;
            this.label7.Text = "Gestión de Facturas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 88);
            this.label1.Name = "label1";
            this.label1.TabIndex = 52;
            this.label1.Text = "&Añadir";
            this.label1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(94, 87);
            this.label8.Name = "label8";
            this.label8.TabIndex = 53;
            this.label8.Text = "&Imprimir";
            this.label8.Visible = false;
            // 
            // labelEnviar
            // 
            this.labelEnviar.AutoSize = true;
            this.labelEnviar.BackColor = System.Drawing.Color.White;
            this.labelEnviar.Location = new System.Drawing.Point(152, 88);
            this.labelEnviar.Name = "labelEnviar";
            this.labelEnviar.TabIndex = 54;
            this.labelEnviar.Text = "&Enviar";
            this.labelEnviar.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(211, 88);
            this.label4.Name = "label4";
            this.label4.TabIndex = 55;
            this.label4.Text = "&Buscar";
            this.label4.Visible = false;
            // 
            // labelEjercicio
            // 
            this.labelEjercicio.AutoSize = true;
            this.labelEjercicio.BackColor = System.Drawing.Color.White;
            this.labelEjercicio.Location = new System.Drawing.Point(459, 88);
            this.labelEjercicio.Name = "labelEjercicio";
            this.labelEjercicio.TabIndex = 56;
            this.labelEjercicio.Text = "Año";
            this.labelEjercicio.Visible = false;
            // 
            // labelSerie
            // 
            this.labelSerie.AutoSize = true;
            this.labelSerie.BackColor = System.Drawing.Color.White;
            this.labelSerie.Location = new System.Drawing.Point(565, 88);
            this.labelSerie.Name = "labelSerie";
            this.labelSerie.TabIndex = 57;
            this.labelSerie.Text = "Serie";
            this.labelSerie.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(678, 88);
            this.label6.Name = "label6";
            this.label6.TabIndex = 58;
            this.label6.Text = "&Ordenar";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(802, 88);
            this.label5.Name = "label5";
            this.label5.TabIndex = 59;
            this.label5.Text = "&Salir";
            this.label5.Visible = false;
            // 
            // sumar
            // 
            this.sumar.BackColor = System.Drawing.Color.White;
            this.sumar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sumar.BackgroundImage")));
            this.sumar.Location = new System.Drawing.Point(31, 104);
            this.sumar.Name = "sumar";
            this.sumar.Size = new System.Drawing.Size(52, 56);
            this.sumar.TabIndex = 1;
            this.sumar.UseVisualStyleBackColor = false;
            this.sumar.Click += new System.EventHandler(this.sumar_Click);
            this.sumar.MouseEnter += new System.EventHandler(this.sumar_MouseEnter);
            this.sumar.MouseLeave += new System.EventHandler(this.sumar_MouseLeave);
            // 
            // imprimir
            // 
            this.imprimir.BackColor = System.Drawing.Color.White;
            this.imprimir.BackgroundImage = global::Proyecto_Antonio_Luis.Properties.Resources.Impresora;
            this.imprimir.Location = new System.Drawing.Point(89, 103);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(52, 56);
            this.imprimir.TabIndex = 2;
            this.imprimir.UseVisualStyleBackColor = false;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            this.imprimir.MouseEnter += new System.EventHandler(this.imprimir_MouseEnter);
            this.imprimir.MouseLeave += new System.EventHandler(this.imprimir_MouseLeave);
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.Color.White;
            this.enviar.BackgroundImage = global::Proyecto_Antonio_Luis.Properties.Resources.Correo;
            this.enviar.Location = new System.Drawing.Point(147, 103);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(52, 56);
            this.enviar.TabIndex = 3;
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            this.enviar.MouseEnter += new System.EventHandler(this.enviar_MouseEnter);
            this.enviar.MouseLeave += new System.EventHandler(this.enviar_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.textBox1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(205, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 56);
            this.panel1.TabIndex = 4;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // comboEjercicio
            // 
            this.comboEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEjercicio.FormattingEnabled = true;
            this.comboEjercicio.Location = new System.Drawing.Point(10, 18);
            this.comboEjercicio.Name = "comboEjercicio";
            this.comboEjercicio.Size = new System.Drawing.Size(80, 21);
            this.comboEjercicio.TabIndex = 0;
            this.comboEjercicio.SelectedIndexChanged += new System.EventHandler(this.Filtro_Cambiado);
            this.comboEjercicio.MouseEnter += new System.EventHandler(this.panelEjercicio_MouseEnter);
            this.comboEjercicio.MouseLeave += new System.EventHandler(this.panelEjercicio_MouseLeave);
            // 
            // panelEjercicio
            // 
            this.panelEjercicio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelEjercicio.BackgroundImage")));
            this.panelEjercicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelEjercicio.Controls.Add(this.comboEjercicio);
            this.panelEjercicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelEjercicio.Location = new System.Drawing.Point(453, 104);
            this.panelEjercicio.Name = "panelEjercicio";
            this.panelEjercicio.Size = new System.Drawing.Size(100, 56);
            this.panelEjercicio.TabIndex = 4;
            this.panelEjercicio.MouseEnter += new System.EventHandler(this.panelEjercicio_MouseEnter);
            this.panelEjercicio.MouseLeave += new System.EventHandler(this.panelEjercicio_MouseLeave);
            // 
            // comboSerie
            // 
            this.comboSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSerie.DropDownWidth = 200;
            this.comboSerie.FormattingEnabled = true;
            this.comboSerie.Location = new System.Drawing.Point(8, 18);
            this.comboSerie.Name = "comboSerie";
            this.comboSerie.Size = new System.Drawing.Size(87, 21);
            this.comboSerie.TabIndex = 0;
            this.comboSerie.SelectedIndexChanged += new System.EventHandler(this.Filtro_Cambiado);
            this.comboSerie.MouseEnter += new System.EventHandler(this.panelSerie_MouseEnter);
            this.comboSerie.MouseLeave += new System.EventHandler(this.panelSerie_MouseLeave);
            // 
            // panelSerie
            // 
            this.panelSerie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelSerie.BackgroundImage")));
            this.panelSerie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSerie.Controls.Add(this.comboSerie);
            this.panelSerie.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelSerie.Location = new System.Drawing.Point(559, 104);
            this.panelSerie.Name = "panelSerie";
            this.panelSerie.Size = new System.Drawing.Size(103, 56);
            this.panelSerie.TabIndex = 5;
            this.panelSerie.MouseEnter += new System.EventHandler(this.panelSerie_MouseEnter);
            this.panelSerie.MouseLeave += new System.EventHandler(this.panelSerie_MouseLeave);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Número",
            "Fecha",
            "Código",
            "Nombre"});
            this.comboBox1.Location = new System.Drawing.Point(13, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.comboBox1.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(668, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 56);
            this.panel2.TabIndex = 6;
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.White;
            this.salir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salir.BackgroundImage")));
            this.salir.Location = new System.Drawing.Point(790, 104);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(52, 56);
            this.salir.TabIndex = 8;
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            this.salir.MouseEnter += new System.EventHandler(this.salir_MouseEnter);
            this.salir.MouseLeave += new System.EventHandler(this.salir_MouseLeave);
            // 
            // dgvfactura
            // 
            this.dgvfactura.AllowUserToAddRows = false;
            this.dgvfactura.AllowUserToDeleteRows = false;
            this.dgvfactura.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvfactura.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvfactura.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvfactura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvfactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfactura.GridColor = System.Drawing.SystemColors.Control;
            this.dgvfactura.Location = new System.Drawing.Point(41, 207);
            this.dgvfactura.Name = "dgvfactura";
            this.dgvfactura.ReadOnly = true;
            this.dgvfactura.RowHeadersVisible = false;
            this.dgvfactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfactura.Size = new System.Drawing.Size(790, 377);
            this.dgvfactura.TabIndex = 7;
            this.dgvfactura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvclientes_CellDoubleClick);
            this.dgvfactura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvfactura_KeyDown);
            // 
            // labelResumen
            // 
            this.labelResumen.BackColor = System.Drawing.Color.White;
            this.labelResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResumen.Location = new System.Drawing.Point(41, 592);
            this.labelResumen.Name = "labelResumen";
            this.labelResumen.Size = new System.Drawing.Size(790, 20);
            this.labelResumen.TabIndex = 60;
            this.labelResumen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GestionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(874, 642);
            this.Controls.Add(this.labelResumen);
            this.Controls.Add(this.dgvfactura);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSerie);
            this.Controls.Add(this.panelEjercicio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.sumar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelSerie);
            this.Controls.Add(this.labelEjercicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelEnviar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(890, 680);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(890, 680);
            this.Name = "GestionFacturas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eGESTION";
            this.Load += new System.EventHandler(this.GestionFacturas_Load);
            this.panel1.ResumeLayout(false);
            this.panelEjercicio.ResumeLayout(false);
            this.panelSerie.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelEnviar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelEjercicio;
        private System.Windows.Forms.Label labelSerie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.Button imprimir;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboEjercicio;
        private System.Windows.Forms.Panel panelEjercicio;
        private System.Windows.Forms.ComboBox comboSerie;
        private System.Windows.Forms.Panel panelSerie;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.DataGridView dgvfactura;
        private System.Windows.Forms.Label labelResumen;
    }
}
