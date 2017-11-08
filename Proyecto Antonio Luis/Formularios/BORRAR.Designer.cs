namespace Proyecto_Antonio_Luis.Formularios
{
    partial class BORRAR
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
            this.dgvIva = new System.Windows.Forms.DataGridView();
            this.numeradorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaconceptoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaporcientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivarecargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIva
            // 
            this.dgvIva.AutoGenerateColumns = false;
            this.dgvIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeradorDataGridViewTextBoxColumn,
            this.ivaconceptoDataGridViewTextBoxColumn,
            this.ivaporcientoDataGridViewTextBoxColumn,
            this.ivarecargoDataGridViewTextBoxColumn});
            this.dgvIva.DataSource = this.ivaBindingSource;
            this.dgvIva.Location = new System.Drawing.Point(40, 239);
            this.dgvIva.Name = "dgvIva";
            this.dgvIva.Size = new System.Drawing.Size(630, 206);
            this.dgvIva.TabIndex = 0;
            this.dgvIva.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIva_CellContentClick);
            // 
            // numeradorDataGridViewTextBoxColumn
            // 
            this.numeradorDataGridViewTextBoxColumn.DataPropertyName = "numerador";
            this.numeradorDataGridViewTextBoxColumn.HeaderText = "numerador";
            this.numeradorDataGridViewTextBoxColumn.Name = "numeradorDataGridViewTextBoxColumn";
            // 
            // ivaconceptoDataGridViewTextBoxColumn
            // 
            this.ivaconceptoDataGridViewTextBoxColumn.DataPropertyName = "ivaconcepto";
            this.ivaconceptoDataGridViewTextBoxColumn.HeaderText = "ivaconcepto";
            this.ivaconceptoDataGridViewTextBoxColumn.Name = "ivaconceptoDataGridViewTextBoxColumn";
            // 
            // ivaporcientoDataGridViewTextBoxColumn
            // 
            this.ivaporcientoDataGridViewTextBoxColumn.DataPropertyName = "ivaporciento";
            this.ivaporcientoDataGridViewTextBoxColumn.HeaderText = "ivaporciento";
            this.ivaporcientoDataGridViewTextBoxColumn.Name = "ivaporcientoDataGridViewTextBoxColumn";
            // 
            // ivarecargoDataGridViewTextBoxColumn
            // 
            this.ivarecargoDataGridViewTextBoxColumn.DataPropertyName = "ivarecargo";
            this.ivarecargoDataGridViewTextBoxColumn.HeaderText = "ivarecargo";
            this.ivarecargoDataGridViewTextBoxColumn.Name = "ivarecargoDataGridViewTextBoxColumn";
            // 
            // ivaBindingSource
            // 
            this.ivaBindingSource.DataSource = typeof(BaseDatos.Iva);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "añadir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(169, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(78, 149);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(169, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(78, 190);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(169, 20);
            this.textBox4.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(499, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 49);
            this.button2.TabIndex = 6;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BORRAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 481);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvIva);
            this.Name = "BORRAR";
            this.Text = "BORRAR";
            this.Load += new System.EventHandler(this.BORRAR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeradorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaconceptoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivaporcientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivarecargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ivaBindingSource;
    }
}