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
            this.dgvIva = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.sumar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.boxrecargo = new System.Windows.Forms.TextBox();
            this.boxiva = new System.Windows.Forms.TextBox();
            this.boxconcepto = new System.Windows.Forms.TextBox();
            this.eliminar = new System.Windows.Forms.Button();
            this.ivaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numeradorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaconceptoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaporcientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivarecargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAceptar.BackgroundImage")));
            this.buttonAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAceptar.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.Location = new System.Drawing.Point(20, 192);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(180, 60);
            this.buttonAceptar.TabIndex = 114;
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // dgvIva
            // 
            this.dgvIva.AllowUserToAddRows = false;
            this.dgvIva.AllowUserToDeleteRows = false;
            this.dgvIva.AllowUserToOrderColumns = true;
            this.dgvIva.AutoGenerateColumns = false;
            this.dgvIva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIva.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvIva.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeradorDataGridViewTextBoxColumn,
            this.ivaconceptoDataGridViewTextBoxColumn,
            this.ivaporcientoDataGridViewTextBoxColumn,
            this.ivarecargoDataGridViewTextBoxColumn});
            this.dgvIva.DataSource = this.ivaBindingSource;
            this.dgvIva.Location = new System.Drawing.Point(38, 212);
            this.dgvIva.MultiSelect = false;
            this.dgvIva.Name = "dgvIva";
            this.dgvIva.RowHeadersWidth = 15;
            this.dgvIva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIva.Size = new System.Drawing.Size(385, 211);
            this.dgvIva.TabIndex = 117;
            this.dgvIva.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIVAs_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.label7.Location = new System.Drawing.Point(78, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 42);
            this.label7.TabIndex = 131;
            this.label7.Text = "Tipos Impuestos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(396, 89);
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
            this.label3.Location = new System.Drawing.Point(140, 89);
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
            this.label2.Location = new System.Drawing.Point(88, 89);
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
            this.label1.Location = new System.Drawing.Point(38, 89);
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
            this.salir.Location = new System.Drawing.Point(380, 105);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(52, 56);
            this.salir.TabIndex = 125;
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            this.salir.MouseEnter += new System.EventHandler(this.salir_MouseEnter);
            this.salir.MouseLeave += new System.EventHandler(this.salir_MouseLeave);
            // 
            // modificar
            // 
            this.modificar.BackColor = System.Drawing.Color.White;
            this.modificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("modificar.BackgroundImage")));
            this.modificar.Location = new System.Drawing.Point(140, 105);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(52, 56);
            this.modificar.TabIndex = 123;
            this.modificar.UseVisualStyleBackColor = false;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            this.modificar.MouseEnter += new System.EventHandler(this.modificar_MouseEnter);
            this.modificar.MouseLeave += new System.EventHandler(this.modificar_MouseLeave);
            // 
            // sumar
            // 
            this.sumar.BackColor = System.Drawing.Color.White;
            this.sumar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sumar.BackgroundImage")));
            this.sumar.Location = new System.Drawing.Point(30, 105);
            this.sumar.Name = "sumar";
            this.sumar.Size = new System.Drawing.Size(52, 56);
            this.sumar.TabIndex = 121;
            this.sumar.UseVisualStyleBackColor = false;
            this.sumar.Click += new System.EventHandler(this.sumar_Click);
            this.sumar.MouseEnter += new System.EventHandler(this.sumar_MouseEnter);
            this.sumar.MouseLeave += new System.EventHandler(this.sumar_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(215, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 60);
            this.button2.TabIndex = 197;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.boxrecargo);
            this.panel1.Controls.Add(this.boxiva);
            this.panel1.Controls.Add(this.boxconcepto);
            this.panel1.Controls.Add(this.buttonAceptar);
            this.panel1.Location = new System.Drawing.Point(23, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 268);
            this.panel1.TabIndex = 198;
            this.panel1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.label9.Font = new System.Drawing.Font("Tahoma", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.label9.Location = new System.Drawing.Point(124, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 33);
            this.label9.TabIndex = 199;
            this.label9.Text = "Alta de Tipo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.label8.Location = new System.Drawing.Point(340, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "% R.E.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.label6.Location = new System.Drawing.Point(265, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "% I.V.A.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.label4.Location = new System.Drawing.Point(16, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Concepto";
            // 
            // boxrecargo
            // 
            this.boxrecargo.Location = new System.Drawing.Point(331, 119);
            this.boxrecargo.Name = "boxrecargo";
            this.boxrecargo.Size = new System.Drawing.Size(64, 20);
            this.boxrecargo.TabIndex = 2;
            // 
            // boxiva
            // 
            this.boxiva.Location = new System.Drawing.Point(256, 119);
            this.boxiva.Name = "boxiva";
            this.boxiva.Size = new System.Drawing.Size(64, 20);
            this.boxiva.TabIndex = 1;
            // 
            // boxconcepto
            // 
            this.boxconcepto.Location = new System.Drawing.Point(19, 119);
            this.boxconcepto.Name = "boxconcepto";
            this.boxconcepto.Size = new System.Drawing.Size(222, 20);
            this.boxconcepto.TabIndex = 0;
            this.boxconcepto.TextChanged += new System.EventHandler(this.boxconcepto_TextChanged);
            // 
            // eliminar
            // 
            this.eliminar.BackColor = System.Drawing.Color.White;
            this.eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eliminar.BackgroundImage")));
            this.eliminar.Location = new System.Drawing.Point(85, 105);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(52, 56);
            this.eliminar.TabIndex = 199;
            this.eliminar.UseVisualStyleBackColor = false;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click_1);
            // 
            // ivaBindingSource
            // 
  //          this.ivaBindingSource.DataSource = typeof(BaseDatos.Iva);
            // 
            // numeradorDataGridViewTextBoxColumn
            // 
            this.numeradorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.numeradorDataGridViewTextBoxColumn.DataPropertyName = "numerador";
            this.numeradorDataGridViewTextBoxColumn.FillWeight = 55.10756F;
            this.numeradorDataGridViewTextBoxColumn.HeaderText = "Id.";
            this.numeradorDataGridViewTextBoxColumn.Name = "numeradorDataGridViewTextBoxColumn";
            this.numeradorDataGridViewTextBoxColumn.Width = 37;
            // 
            // ivaconceptoDataGridViewTextBoxColumn
            // 
            this.ivaconceptoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ivaconceptoDataGridViewTextBoxColumn.DataPropertyName = "ivaconcepto";
            this.ivaconceptoDataGridViewTextBoxColumn.FillWeight = 145.8943F;
            this.ivaconceptoDataGridViewTextBoxColumn.HeaderText = "Concepto";
            this.ivaconceptoDataGridViewTextBoxColumn.Name = "ivaconceptoDataGridViewTextBoxColumn";
            this.ivaconceptoDataGridViewTextBoxColumn.Width = 190;
            // 
            // ivaporcientoDataGridViewTextBoxColumn
            // 
            this.ivaporcientoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ivaporcientoDataGridViewTextBoxColumn.DataPropertyName = "ivaporciento";
            this.ivaporcientoDataGridViewTextBoxColumn.FillWeight = 66.73797F;
            this.ivaporcientoDataGridViewTextBoxColumn.HeaderText = "Iva %";
            this.ivaporcientoDataGridViewTextBoxColumn.Name = "ivaporcientoDataGridViewTextBoxColumn";
            this.ivaporcientoDataGridViewTextBoxColumn.Width = 70;
            // 
            // ivarecargoDataGridViewTextBoxColumn
            // 
            this.ivarecargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ivarecargoDataGridViewTextBoxColumn.DataPropertyName = "ivarecargo";
            this.ivarecargoDataGridViewTextBoxColumn.FillWeight = 94.13318F;
            this.ivarecargoDataGridViewTextBoxColumn.HeaderText = "R.E. %";
            this.ivarecargoDataGridViewTextBoxColumn.Name = "ivarecargoDataGridViewTextBoxColumn";
            this.ivarecargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ivarecargoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ivarecargoDataGridViewTextBoxColumn.Width = 70;
            // 
            // Impuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(463, 478);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.sumar);
            this.Controls.Add(this.dgvIva);
            this.DoubleBuffered = true;
            this.Name = "Impuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impuestos";
            this.Load += new System.EventHandler(this.Impuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.DataGridView dgvIva;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.Button button2;
       
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox boxrecargo;
        private System.Windows.Forms.TextBox boxiva;
        private System.Windows.Forms.TextBox boxconcepto;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.BindingSource ivaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeradorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaconceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaporcientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivarecargoDataGridViewTextBoxColumn;
    }
}