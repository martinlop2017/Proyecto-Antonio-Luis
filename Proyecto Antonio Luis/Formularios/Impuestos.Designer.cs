namespace Proyecto_Antonio_Luis.Formularios
{
    partial class Impuestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Impuestos));
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.dataGridViewIVAs = new System.Windows.Forms.DataGridView();
            this.ivaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ususariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.eliminar = new System.Windows.Forms.Button();
            this.sumar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIVAs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ususariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAceptar.BackgroundImage")));
            this.buttonAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAceptar.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.Location = new System.Drawing.Point(56, 411);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(208, 60);
            this.buttonAceptar.TabIndex = 114;
            this.buttonAceptar.UseVisualStyleBackColor = true;
            // 
            // dataGridViewIVAs
            // 
            this.dataGridViewIVAs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIVAs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewIVAs.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewIVAs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIVAs.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.ivaBindingSource, "numerador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridViewIVAs.Location = new System.Drawing.Point(46, 210);
            this.dataGridViewIVAs.Name = "dataGridViewIVAs";
            this.dataGridViewIVAs.RowHeadersWidth = 15;
            this.dataGridViewIVAs.Size = new System.Drawing.Size(455, 165);
            this.dataGridViewIVAs.TabIndex = 117;
            this.dataGridViewIVAs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIVAs_CellContentClick);
            // 
            // ivaBindingSource
            // 
            this.ivaBindingSource.DataSource = typeof(BaseDatos.Iva);
            // 
            // ususariosBindingSource
            // 
            this.ususariosBindingSource.DataSource = typeof(BaseDatos.Ususarios);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 30);
            this.button1.TabIndex = 120;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.label7.Location = new System.Drawing.Point(122, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 42);
            this.label7.TabIndex = 131;
            this.label7.Text = "Tipos Impuestos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(475, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 130;
            this.label5.Text = "&Salir";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(155, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "&Modificar";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(102, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "&Eliminar";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "&Añadir";
            this.label1.Visible = false;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.White;
            this.salir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salir.BackgroundImage")));
            this.salir.Location = new System.Drawing.Point(463, 105);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(52, 56);
            this.salir.TabIndex = 125;
            this.salir.UseVisualStyleBackColor = false;
            this.salir.MouseEnter += new System.EventHandler(this.salir_MouseEnter);
            this.salir.MouseLeave += new System.EventHandler(this.salir_MouseLeave);
            // 
            // modificar
            // 
            this.modificar.BackColor = System.Drawing.Color.White;
            this.modificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("modificar.BackgroundImage")));
            this.modificar.Location = new System.Drawing.Point(154, 105);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(52, 56);
            this.modificar.TabIndex = 123;
            this.modificar.UseVisualStyleBackColor = false;
            this.modificar.MouseEnter += new System.EventHandler(this.modificar_MouseEnter);
            this.modificar.MouseLeave += new System.EventHandler(this.modificar_MouseLeave);
            // 
            // eliminar
            // 
            this.eliminar.BackColor = System.Drawing.Color.White;
            this.eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eliminar.BackgroundImage")));
            this.eliminar.Location = new System.Drawing.Point(96, 105);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(52, 56);
            this.eliminar.TabIndex = 122;
            this.eliminar.UseVisualStyleBackColor = false;
            this.eliminar.MouseEnter += new System.EventHandler(this.eliminar_MouseEnter);
            this.eliminar.MouseLeave += new System.EventHandler(this.eliminar_MouseLeave);
            // 
            // sumar
            // 
            this.sumar.BackColor = System.Drawing.Color.White;
            this.sumar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sumar.BackgroundImage")));
            this.sumar.Location = new System.Drawing.Point(38, 105);
            this.sumar.Name = "sumar";
            this.sumar.Size = new System.Drawing.Size(52, 56);
            this.sumar.TabIndex = 121;
            this.sumar.UseVisualStyleBackColor = false;
            this.sumar.MouseEnter += new System.EventHandler(this.sumar_MouseEnter);
            this.sumar.MouseLeave += new System.EventHandler(this.sumar_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(290, 411);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 60);
            this.button2.TabIndex = 197;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Impuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(549, 528);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.sumar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewIVAs);
            this.Controls.Add(this.buttonAceptar);
            this.DoubleBuffered = true;
            this.Name = "Impuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impuestos";
            this.Load += new System.EventHandler(this.Impuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIVAs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ususariosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.DataGridView dataGridViewIVAs;
        public System.Windows.Forms.BindingSource ivaBindingSource;
        private System.Windows.Forms.BindingSource ususariosBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.Button button2;
    }
}