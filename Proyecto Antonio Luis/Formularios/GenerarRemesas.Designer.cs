namespace Proyecto_Antonio_Luis.Formularios
{
    partial class GenerarRemesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarRemesas));
            this.button2 = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.administracionAntonioEntitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.administracionAntonioDataSet = new Proyecto_Antonio_Luis.AdministracionAntonioDataSet();
            this.remesasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.remesasTableAdapter = new Proyecto_Antonio_Luis.AdministracionAntonioDataSetTableAdapters.RemesasTableAdapter();
            this.remesanumeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesafechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesatotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesabancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remesaimpresaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.remesacontabilizadaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.remesanumeradorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioEntitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remesasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(344, 542);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 60);
            this.button2.TabIndex = 199;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAceptar.BackgroundImage")));
            this.buttonAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAceptar.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonAceptar.FlatAppearance.BorderSize = 0;
            this.buttonAceptar.Location = new System.Drawing.Point(148, 542);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(180, 60);
            this.buttonAceptar.TabIndex = 198;
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remesanumeroDataGridViewTextBoxColumn,
            this.remesafechaDataGridViewTextBoxColumn,
            this.remesatotalDataGridViewTextBoxColumn,
            this.remesabancoDataGridViewTextBoxColumn,
            this.remesaimpresaDataGridViewCheckBoxColumn,
            this.remesacontabilizadaDataGridViewCheckBoxColumn,
            this.remesanumeradorDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.remesasBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(53, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 15;
            this.dataGridView1.Size = new System.Drawing.Size(329, 318);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 201;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 203;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 204;
            this.label5.Text = "label5";
            // 
            // administracionAntonioEntitiesBindingSource
            // 
            this.administracionAntonioEntitiesBindingSource.DataSource = typeof(BaseDatos.AdministracionAntonioEntities);
            // 
            // administracionAntonioDataSet
            // 
            this.administracionAntonioDataSet.DataSetName = "AdministracionAntonioDataSet";
            this.administracionAntonioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // remesasBindingSource
            // 
            this.remesasBindingSource.DataMember = "Remesas";
            this.remesasBindingSource.DataSource = this.administracionAntonioDataSet;
            // 
            // remesasTableAdapter
            // 
            this.remesasTableAdapter.ClearBeforeFill = true;
            // 
            // remesanumeroDataGridViewTextBoxColumn
            // 
            this.remesanumeroDataGridViewTextBoxColumn.DataPropertyName = "remesanumero";
            this.remesanumeroDataGridViewTextBoxColumn.HeaderText = "remesanumero";
            this.remesanumeroDataGridViewTextBoxColumn.Name = "remesanumeroDataGridViewTextBoxColumn";
            // 
            // remesafechaDataGridViewTextBoxColumn
            // 
            this.remesafechaDataGridViewTextBoxColumn.DataPropertyName = "remesafecha";
            this.remesafechaDataGridViewTextBoxColumn.HeaderText = "remesafecha";
            this.remesafechaDataGridViewTextBoxColumn.Name = "remesafechaDataGridViewTextBoxColumn";
            // 
            // remesatotalDataGridViewTextBoxColumn
            // 
            this.remesatotalDataGridViewTextBoxColumn.DataPropertyName = "remesatotal";
            this.remesatotalDataGridViewTextBoxColumn.HeaderText = "remesatotal";
            this.remesatotalDataGridViewTextBoxColumn.Name = "remesatotalDataGridViewTextBoxColumn";
            // 
            // remesabancoDataGridViewTextBoxColumn
            // 
            this.remesabancoDataGridViewTextBoxColumn.DataPropertyName = "remesabanco";
            this.remesabancoDataGridViewTextBoxColumn.HeaderText = "remesabanco";
            this.remesabancoDataGridViewTextBoxColumn.Name = "remesabancoDataGridViewTextBoxColumn";
            this.remesabancoDataGridViewTextBoxColumn.Visible = false;
            // 
            // remesaimpresaDataGridViewCheckBoxColumn
            // 
            this.remesaimpresaDataGridViewCheckBoxColumn.DataPropertyName = "remesaimpresa";
            this.remesaimpresaDataGridViewCheckBoxColumn.HeaderText = "remesaimpresa";
            this.remesaimpresaDataGridViewCheckBoxColumn.Name = "remesaimpresaDataGridViewCheckBoxColumn";
            this.remesaimpresaDataGridViewCheckBoxColumn.Visible = false;
            // 
            // remesacontabilizadaDataGridViewCheckBoxColumn
            // 
            this.remesacontabilizadaDataGridViewCheckBoxColumn.DataPropertyName = "remesacontabilizada";
            this.remesacontabilizadaDataGridViewCheckBoxColumn.HeaderText = "remesacontabilizada";
            this.remesacontabilizadaDataGridViewCheckBoxColumn.Name = "remesacontabilizadaDataGridViewCheckBoxColumn";
            this.remesacontabilizadaDataGridViewCheckBoxColumn.Visible = false;
            // 
            // remesanumeradorDataGridViewTextBoxColumn
            // 
            this.remesanumeradorDataGridViewTextBoxColumn.DataPropertyName = "remesanumerador";
            this.remesanumeradorDataGridViewTextBoxColumn.HeaderText = "remesanumerador";
            this.remesanumeradorDataGridViewTextBoxColumn.Name = "remesanumeradorDataGridViewTextBoxColumn";
            this.remesanumeradorDataGridViewTextBoxColumn.ReadOnly = true;
            this.remesanumeradorDataGridViewTextBoxColumn.Visible = false;
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Proyecto_Antonio_Luis.Form1);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(Proyecto_Antonio_Luis.Program);
            // 
            // caja
            // 
            this.caja.AutoSize = true;
            this.caja.Location = new System.Drawing.Point(464, 257);
            this.caja.Name = "caja";
            this.caja.Size = new System.Drawing.Size(35, 13);
            this.caja.TabIndex = 205;
            this.caja.Text = "label6";
            // 
            // GenerarRemesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 641);
            this.Controls.Add(this.caja);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GenerarRemesas";
            this.Text = "GenerarRemesas";
            this.Load += new System.EventHandler(this.GenerarRemesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioEntitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remesasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource administracionAntonioEntitiesBindingSource;
        private System.Windows.Forms.BindingSource programBindingSource;
        private AdministracionAntonioDataSet administracionAntonioDataSet;
        private System.Windows.Forms.BindingSource remesasBindingSource;
        private AdministracionAntonioDataSetTableAdapters.RemesasTableAdapter remesasTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesanumeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesafechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesatotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesabancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn remesaimpresaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn remesacontabilizadaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remesanumeradorDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label caja;
    }
}