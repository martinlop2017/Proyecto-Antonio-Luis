namespace Proyecto_Antonio_Luis.Formularios
{
    partial class GestionRemesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionRemesas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.sumar = new System.Windows.Forms.Button();
            this.imprimir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvremesas = new System.Windows.Forms.DataGridView();
            this.resillaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetAntonioLuis = new Proyecto_Antonio_Luis.DataSetAntonioLuis();
            this.remesanumeradorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesanumeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesafechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesatotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesacontabilizadaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvremesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resillaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAntonioLuis)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(94, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 86;
            this.label8.Text = "&Imprimir";
            this.label8.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(484, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "&Salir";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(154, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 78;
            this.label4.Text = "&Buscar";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "&Añadir";
            this.label1.Visible = false;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.White;
            this.salir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salir.BackgroundImage")));
            this.salir.Location = new System.Drawing.Point(472, 103);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(52, 56);
            this.salir.TabIndex = 74;
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // sumar
            // 
            this.sumar.BackColor = System.Drawing.Color.White;
            this.sumar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sumar.BackgroundImage")));
            this.sumar.Location = new System.Drawing.Point(31, 104);
            this.sumar.Name = "sumar";
            this.sumar.Size = new System.Drawing.Size(52, 56);
            this.sumar.TabIndex = 71;
            this.sumar.UseVisualStyleBackColor = false;
            this.sumar.Click += new System.EventHandler(this.sumar_Click);
            // 
            // imprimir
            // 
            this.imprimir.BackColor = System.Drawing.Color.White;
            this.imprimir.BackgroundImage = global::Proyecto_Antonio_Luis.Properties.Resources.Impresora;
            this.imprimir.Location = new System.Drawing.Point(89, 103);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(52, 56);
            this.imprimir.TabIndex = 85;
            this.imprimir.UseVisualStyleBackColor = false;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(380, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 84;
            this.label6.Text = "&Ordenar";
            this.label6.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(370, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(96, 56);
            this.panel2.TabIndex = 83;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Remesa",
            "Fecha",
            "Importe"});
            this.comboBox1.Location = new System.Drawing.Point(13, 18);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.MaximumSize = new System.Drawing.Size(879, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(67, 21);
            this.comboBox1.TabIndex = 54;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(147, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 56);
            this.panel1.TabIndex = 82;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 52;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.label7.Location = new System.Drawing.Point(93, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(373, 42);
            this.label7.TabIndex = 81;
            this.label7.Text = "Gestión de Remesas";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dgvremesas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvremesas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvremesas.AutoGenerateColumns = false;
            this.dgvremesas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvremesas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvremesas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvremesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvremesas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remesanumeradorDataGridViewTextBoxColumn,
            this.remesanumeroDataGridViewTextBoxColumn,
            this.remesafechaDataGridViewTextBoxColumn,
            this.remesatotalDataGridViewTextBoxColumn,
            this.remesacontabilizadaDataGridViewCheckBoxColumn});
            this.dgvremesas.DataSource = this.resillaBindingSource;
            this.dgvremesas.GridColor = System.Drawing.SystemColors.Control;
            this.dgvremesas.Location = new System.Drawing.Point(38, 204);
            this.dgvremesas.Name = "dgvremesas";
            this.dgvremesas.ReadOnly = true;
            this.dgvremesas.RowHeadersWidth = 20;
            this.dgvremesas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvremesas.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvremesas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvremesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvremesas.Size = new System.Drawing.Size(477, 383);
            this.dgvremesas.TabIndex = 80;
            // 
            // resillaBindingSource
            // 
            this.resillaBindingSource.DataMember = "Resilla";
            this.resillaBindingSource.DataSource = this.dataSetAntonioLuis;
            // 
            // dataSetAntonioLuis
            // 
            this.dataSetAntonioLuis.DataSetName = "DataSetAntonioLuis";
            this.dataSetAntonioLuis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // remesanumeradorDataGridViewTextBoxColumn
            // 
            this.remesanumeradorDataGridViewTextBoxColumn.DataPropertyName = "remesanumerador";
            this.remesanumeradorDataGridViewTextBoxColumn.HeaderText = "remesanumerador";
            this.remesanumeradorDataGridViewTextBoxColumn.Name = "remesanumeradorDataGridViewTextBoxColumn";
            this.remesanumeradorDataGridViewTextBoxColumn.ReadOnly = true;
            this.remesanumeradorDataGridViewTextBoxColumn.Visible = false;
            // 
            // remesanumeroDataGridViewTextBoxColumn
            // 
            this.remesanumeroDataGridViewTextBoxColumn.DataPropertyName = "remesanumero";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remesanumeroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.remesanumeroDataGridViewTextBoxColumn.HeaderText = "Remesa";
            this.remesanumeroDataGridViewTextBoxColumn.Name = "remesanumeroDataGridViewTextBoxColumn";
            this.remesanumeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.remesanumeroDataGridViewTextBoxColumn.Width = 150;
            // 
            // remesafechaDataGridViewTextBoxColumn
            // 
            this.remesafechaDataGridViewTextBoxColumn.DataPropertyName = "remesafecha";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.remesafechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.remesafechaDataGridViewTextBoxColumn.HeaderText = "      Fecha";
            this.remesafechaDataGridViewTextBoxColumn.Name = "remesafechaDataGridViewTextBoxColumn";
            this.remesafechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remesatotalDataGridViewTextBoxColumn
            // 
            this.remesatotalDataGridViewTextBoxColumn.DataPropertyName = "remesatotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "0";
            this.remesatotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.remesatotalDataGridViewTextBoxColumn.HeaderText = "       Importe";
            this.remesatotalDataGridViewTextBoxColumn.Name = "remesatotalDataGridViewTextBoxColumn";
            this.remesatotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.remesatotalDataGridViewTextBoxColumn.Width = 115;
            // 
            // remesacontabilizadaDataGridViewCheckBoxColumn
            // 
            this.remesacontabilizadaDataGridViewCheckBoxColumn.DataPropertyName = "remesacontabilizada";
            this.remesacontabilizadaDataGridViewCheckBoxColumn.HeaderText = "Contabilizada";
            this.remesacontabilizadaDataGridViewCheckBoxColumn.Name = "remesacontabilizadaDataGridViewCheckBoxColumn";
            this.remesacontabilizadaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.remesacontabilizadaDataGridViewCheckBoxColumn.Width = 90;
            // 
            // GestionRemesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(559, 641);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.sumar);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvremesas);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(575, 679);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(575, 679);
            this.Name = "GestionRemesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionRemesas";
            this.Load += new System.EventHandler(this.GestionRemesas_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvremesas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resillaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAntonioLuis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.Button imprimir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvremesas;
        private DataSetAntonioLuis dataSetAntonioLuis;
        private System.Windows.Forms.BindingSource resillaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesanumeradorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesanumeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesafechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesatotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn remesacontabilizadaDataGridViewCheckBoxColumn;
    }
}