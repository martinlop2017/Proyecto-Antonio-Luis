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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionFacturas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvfactura = new System.Windows.Forms.DataGridView();
            this.factcontadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factnumerofactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factremesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factfechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factcodclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factnombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factdireccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factlocalidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factprovinciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factcpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factnifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factiban1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factiban2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factiban3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factiban4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factiban5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factiban6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factconcepto1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factbase1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factconcepto2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factbase2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factemleadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factprecioempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factbaseempleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facttipoivaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factimporteivaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facttotalfacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factparaImprimirDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.factimpresaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.factparacontabilizarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.factcontabilizadaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.factparadomiciliarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.factdomiciliadaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.facttotalremesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factpormailDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.factmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetAntonioLuis = new Proyecto_Antonio_Luis.DataSetAntonioLuis();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.sumar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.imprimir = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAntonioLuis)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(678, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "&Ordenar";
            this.label6.Visible = false;
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
            this.panel2.TabIndex = 67;
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Número",
            "Código",
            "Nombre"});
            this.comboBox1.Location = new System.Drawing.Point(13, 18);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.MaximumSize = new System.Drawing.Size(879, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 21);
            this.comboBox1.TabIndex = 54;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseEnter += new System.EventHandler(this.comboBox1_MouseEnter);
            this.comboBox1.MouseLeave += new System.EventHandler(this.comboBox1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(163, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 56);
            this.panel1.TabIndex = 66;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(472, 20);
            this.textBox1.TabIndex = 52;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            this.textBox1.MouseLeave += new System.EventHandler(this.textBox1_MouseLeave);
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
            this.label7.TabIndex = 65;
            this.label7.Text = "Gestión de Facturas";
            // 
            // dgvfactura
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvfactura.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvfactura.AutoGenerateColumns = false;
            this.dgvfactura.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvfactura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvfactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.factcontadorDataGridViewTextBoxColumn,
            this.factnumerofactDataGridViewTextBoxColumn,
            this.factremesaDataGridViewTextBoxColumn,
            this.factfechaDataGridViewTextBoxColumn,
            this.factcodclienteDataGridViewTextBoxColumn,
            this.factnombreDataGridViewTextBoxColumn,
            this.factdireccionDataGridViewTextBoxColumn,
            this.factlocalidadDataGridViewTextBoxColumn,
            this.factprovinciaDataGridViewTextBoxColumn,
            this.factcpDataGridViewTextBoxColumn,
            this.factnifDataGridViewTextBoxColumn,
            this.factiban1DataGridViewTextBoxColumn,
            this.factiban2DataGridViewTextBoxColumn,
            this.factiban3DataGridViewTextBoxColumn,
            this.factiban4DataGridViewTextBoxColumn,
            this.factiban5DataGridViewTextBoxColumn,
            this.factiban6DataGridViewTextBoxColumn,
            this.factconcepto1DataGridViewTextBoxColumn,
            this.factbase1DataGridViewTextBoxColumn,
            this.factconcepto2DataGridViewTextBoxColumn,
            this.factbase2DataGridViewTextBoxColumn,
            this.factemleadosDataGridViewTextBoxColumn,
            this.factprecioempleadoDataGridViewTextBoxColumn,
            this.factbaseempleadoDataGridViewTextBoxColumn,
            this.facttipoivaDataGridViewTextBoxColumn,
            this.factimporteivaDataGridViewTextBoxColumn,
            this.facttotalfacturaDataGridViewTextBoxColumn,
            this.factparaImprimirDataGridViewCheckBoxColumn,
            this.factimpresaDataGridViewCheckBoxColumn,
            this.factparacontabilizarDataGridViewCheckBoxColumn,
            this.factcontabilizadaDataGridViewCheckBoxColumn,
            this.factparadomiciliarDataGridViewCheckBoxColumn,
            this.factdomiciliadaDataGridViewCheckBoxColumn,
            this.facttotalremesaDataGridViewTextBoxColumn,
            this.factpormailDataGridViewCheckBoxColumn,
            this.factmailDataGridViewTextBoxColumn});
            this.dgvfactura.DataSource = this.facturasBindingSource;
            this.dgvfactura.GridColor = System.Drawing.SystemColors.Control;
            this.dgvfactura.Location = new System.Drawing.Point(41, 207);
            this.dgvfactura.Name = "dgvfactura";
            this.dgvfactura.ReadOnly = true;
            this.dgvfactura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvfactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfactura.Size = new System.Drawing.Size(790, 377);
            this.dgvfactura.TabIndex = 64;
            this.dgvfactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvclientes_CellContentClick);
            this.dgvfactura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvclientes_CellDoubleClick);
            // 
            // factcontadorDataGridViewTextBoxColumn
            // 
            this.factcontadorDataGridViewTextBoxColumn.DataPropertyName = "factcontador";
            this.factcontadorDataGridViewTextBoxColumn.HeaderText = "factcontador";
            this.factcontadorDataGridViewTextBoxColumn.Name = "factcontadorDataGridViewTextBoxColumn";
            this.factcontadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factnumerofactDataGridViewTextBoxColumn
            // 
            this.factnumerofactDataGridViewTextBoxColumn.DataPropertyName = "factnumerofact";
            this.factnumerofactDataGridViewTextBoxColumn.HeaderText = "factnumerofact";
            this.factnumerofactDataGridViewTextBoxColumn.Name = "factnumerofactDataGridViewTextBoxColumn";
            this.factnumerofactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factremesaDataGridViewTextBoxColumn
            // 
            this.factremesaDataGridViewTextBoxColumn.DataPropertyName = "factremesa";
            this.factremesaDataGridViewTextBoxColumn.HeaderText = "factremesa";
            this.factremesaDataGridViewTextBoxColumn.Name = "factremesaDataGridViewTextBoxColumn";
            this.factremesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factfechaDataGridViewTextBoxColumn
            // 
            this.factfechaDataGridViewTextBoxColumn.DataPropertyName = "factfecha";
            this.factfechaDataGridViewTextBoxColumn.HeaderText = "factfecha";
            this.factfechaDataGridViewTextBoxColumn.Name = "factfechaDataGridViewTextBoxColumn";
            this.factfechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factcodclienteDataGridViewTextBoxColumn
            // 
            this.factcodclienteDataGridViewTextBoxColumn.DataPropertyName = "factcodcliente";
            this.factcodclienteDataGridViewTextBoxColumn.HeaderText = "factcodcliente";
            this.factcodclienteDataGridViewTextBoxColumn.Name = "factcodclienteDataGridViewTextBoxColumn";
            this.factcodclienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factnombreDataGridViewTextBoxColumn
            // 
            this.factnombreDataGridViewTextBoxColumn.DataPropertyName = "factnombre";
            this.factnombreDataGridViewTextBoxColumn.HeaderText = "factnombre";
            this.factnombreDataGridViewTextBoxColumn.Name = "factnombreDataGridViewTextBoxColumn";
            this.factnombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factdireccionDataGridViewTextBoxColumn
            // 
            this.factdireccionDataGridViewTextBoxColumn.DataPropertyName = "factdireccion";
            this.factdireccionDataGridViewTextBoxColumn.HeaderText = "factdireccion";
            this.factdireccionDataGridViewTextBoxColumn.Name = "factdireccionDataGridViewTextBoxColumn";
            this.factdireccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factlocalidadDataGridViewTextBoxColumn
            // 
            this.factlocalidadDataGridViewTextBoxColumn.DataPropertyName = "factlocalidad";
            this.factlocalidadDataGridViewTextBoxColumn.HeaderText = "factlocalidad";
            this.factlocalidadDataGridViewTextBoxColumn.Name = "factlocalidadDataGridViewTextBoxColumn";
            this.factlocalidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factprovinciaDataGridViewTextBoxColumn
            // 
            this.factprovinciaDataGridViewTextBoxColumn.DataPropertyName = "factprovincia";
            this.factprovinciaDataGridViewTextBoxColumn.HeaderText = "factprovincia";
            this.factprovinciaDataGridViewTextBoxColumn.Name = "factprovinciaDataGridViewTextBoxColumn";
            this.factprovinciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factcpDataGridViewTextBoxColumn
            // 
            this.factcpDataGridViewTextBoxColumn.DataPropertyName = "factcp";
            this.factcpDataGridViewTextBoxColumn.HeaderText = "factcp";
            this.factcpDataGridViewTextBoxColumn.Name = "factcpDataGridViewTextBoxColumn";
            this.factcpDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factnifDataGridViewTextBoxColumn
            // 
            this.factnifDataGridViewTextBoxColumn.DataPropertyName = "factnif";
            this.factnifDataGridViewTextBoxColumn.HeaderText = "factnif";
            this.factnifDataGridViewTextBoxColumn.Name = "factnifDataGridViewTextBoxColumn";
            this.factnifDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factiban1DataGridViewTextBoxColumn
            // 
            this.factiban1DataGridViewTextBoxColumn.DataPropertyName = "factiban1";
            this.factiban1DataGridViewTextBoxColumn.HeaderText = "factiban1";
            this.factiban1DataGridViewTextBoxColumn.Name = "factiban1DataGridViewTextBoxColumn";
            this.factiban1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factiban2DataGridViewTextBoxColumn
            // 
            this.factiban2DataGridViewTextBoxColumn.DataPropertyName = "factiban2";
            this.factiban2DataGridViewTextBoxColumn.HeaderText = "factiban2";
            this.factiban2DataGridViewTextBoxColumn.Name = "factiban2DataGridViewTextBoxColumn";
            this.factiban2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factiban3DataGridViewTextBoxColumn
            // 
            this.factiban3DataGridViewTextBoxColumn.DataPropertyName = "factiban3";
            this.factiban3DataGridViewTextBoxColumn.HeaderText = "factiban3";
            this.factiban3DataGridViewTextBoxColumn.Name = "factiban3DataGridViewTextBoxColumn";
            this.factiban3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factiban4DataGridViewTextBoxColumn
            // 
            this.factiban4DataGridViewTextBoxColumn.DataPropertyName = "factiban4";
            this.factiban4DataGridViewTextBoxColumn.HeaderText = "factiban4";
            this.factiban4DataGridViewTextBoxColumn.Name = "factiban4DataGridViewTextBoxColumn";
            this.factiban4DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factiban5DataGridViewTextBoxColumn
            // 
            this.factiban5DataGridViewTextBoxColumn.DataPropertyName = "factiban5";
            this.factiban5DataGridViewTextBoxColumn.HeaderText = "factiban5";
            this.factiban5DataGridViewTextBoxColumn.Name = "factiban5DataGridViewTextBoxColumn";
            this.factiban5DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factiban6DataGridViewTextBoxColumn
            // 
            this.factiban6DataGridViewTextBoxColumn.DataPropertyName = "factiban6";
            this.factiban6DataGridViewTextBoxColumn.HeaderText = "factiban6";
            this.factiban6DataGridViewTextBoxColumn.Name = "factiban6DataGridViewTextBoxColumn";
            this.factiban6DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factconcepto1DataGridViewTextBoxColumn
            // 
            this.factconcepto1DataGridViewTextBoxColumn.DataPropertyName = "factconcepto1";
            this.factconcepto1DataGridViewTextBoxColumn.HeaderText = "factconcepto1";
            this.factconcepto1DataGridViewTextBoxColumn.Name = "factconcepto1DataGridViewTextBoxColumn";
            this.factconcepto1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factbase1DataGridViewTextBoxColumn
            // 
            this.factbase1DataGridViewTextBoxColumn.DataPropertyName = "factbase1";
            this.factbase1DataGridViewTextBoxColumn.HeaderText = "factbase1";
            this.factbase1DataGridViewTextBoxColumn.Name = "factbase1DataGridViewTextBoxColumn";
            this.factbase1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factconcepto2DataGridViewTextBoxColumn
            // 
            this.factconcepto2DataGridViewTextBoxColumn.DataPropertyName = "factconcepto2";
            this.factconcepto2DataGridViewTextBoxColumn.HeaderText = "factconcepto2";
            this.factconcepto2DataGridViewTextBoxColumn.Name = "factconcepto2DataGridViewTextBoxColumn";
            this.factconcepto2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factbase2DataGridViewTextBoxColumn
            // 
            this.factbase2DataGridViewTextBoxColumn.DataPropertyName = "factbase2";
            this.factbase2DataGridViewTextBoxColumn.HeaderText = "factbase2";
            this.factbase2DataGridViewTextBoxColumn.Name = "factbase2DataGridViewTextBoxColumn";
            this.factbase2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factemleadosDataGridViewTextBoxColumn
            // 
            this.factemleadosDataGridViewTextBoxColumn.DataPropertyName = "factemleados";
            this.factemleadosDataGridViewTextBoxColumn.HeaderText = "factemleados";
            this.factemleadosDataGridViewTextBoxColumn.Name = "factemleadosDataGridViewTextBoxColumn";
            this.factemleadosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factprecioempleadoDataGridViewTextBoxColumn
            // 
            this.factprecioempleadoDataGridViewTextBoxColumn.DataPropertyName = "factprecioempleado";
            this.factprecioempleadoDataGridViewTextBoxColumn.HeaderText = "factprecioempleado";
            this.factprecioempleadoDataGridViewTextBoxColumn.Name = "factprecioempleadoDataGridViewTextBoxColumn";
            this.factprecioempleadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factbaseempleadoDataGridViewTextBoxColumn
            // 
            this.factbaseempleadoDataGridViewTextBoxColumn.DataPropertyName = "factbaseempleado";
            this.factbaseempleadoDataGridViewTextBoxColumn.HeaderText = "factbaseempleado";
            this.factbaseempleadoDataGridViewTextBoxColumn.Name = "factbaseempleadoDataGridViewTextBoxColumn";
            this.factbaseempleadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // facttipoivaDataGridViewTextBoxColumn
            // 
            this.facttipoivaDataGridViewTextBoxColumn.DataPropertyName = "facttipoiva";
            this.facttipoivaDataGridViewTextBoxColumn.HeaderText = "facttipoiva";
            this.facttipoivaDataGridViewTextBoxColumn.Name = "facttipoivaDataGridViewTextBoxColumn";
            this.facttipoivaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factimporteivaDataGridViewTextBoxColumn
            // 
            this.factimporteivaDataGridViewTextBoxColumn.DataPropertyName = "factimporteiva";
            this.factimporteivaDataGridViewTextBoxColumn.HeaderText = "factimporteiva";
            this.factimporteivaDataGridViewTextBoxColumn.Name = "factimporteivaDataGridViewTextBoxColumn";
            this.factimporteivaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // facttotalfacturaDataGridViewTextBoxColumn
            // 
            this.facttotalfacturaDataGridViewTextBoxColumn.DataPropertyName = "facttotalfactura";
            this.facttotalfacturaDataGridViewTextBoxColumn.HeaderText = "facttotalfactura";
            this.facttotalfacturaDataGridViewTextBoxColumn.Name = "facttotalfacturaDataGridViewTextBoxColumn";
            this.facttotalfacturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factparaImprimirDataGridViewCheckBoxColumn
            // 
            this.factparaImprimirDataGridViewCheckBoxColumn.DataPropertyName = "factpara imprimir";
            this.factparaImprimirDataGridViewCheckBoxColumn.HeaderText = "factpara imprimir";
            this.factparaImprimirDataGridViewCheckBoxColumn.Name = "factparaImprimirDataGridViewCheckBoxColumn";
            this.factparaImprimirDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // factimpresaDataGridViewCheckBoxColumn
            // 
            this.factimpresaDataGridViewCheckBoxColumn.DataPropertyName = "factimpresa";
            this.factimpresaDataGridViewCheckBoxColumn.HeaderText = "factimpresa";
            this.factimpresaDataGridViewCheckBoxColumn.Name = "factimpresaDataGridViewCheckBoxColumn";
            this.factimpresaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // factparacontabilizarDataGridViewCheckBoxColumn
            // 
            this.factparacontabilizarDataGridViewCheckBoxColumn.DataPropertyName = "factparacontabilizar";
            this.factparacontabilizarDataGridViewCheckBoxColumn.HeaderText = "factparacontabilizar";
            this.factparacontabilizarDataGridViewCheckBoxColumn.Name = "factparacontabilizarDataGridViewCheckBoxColumn";
            this.factparacontabilizarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // factcontabilizadaDataGridViewCheckBoxColumn
            // 
            this.factcontabilizadaDataGridViewCheckBoxColumn.DataPropertyName = "factcontabilizada";
            this.factcontabilizadaDataGridViewCheckBoxColumn.HeaderText = "factcontabilizada";
            this.factcontabilizadaDataGridViewCheckBoxColumn.Name = "factcontabilizadaDataGridViewCheckBoxColumn";
            this.factcontabilizadaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // factparadomiciliarDataGridViewCheckBoxColumn
            // 
            this.factparadomiciliarDataGridViewCheckBoxColumn.DataPropertyName = "factparadomiciliar";
            this.factparadomiciliarDataGridViewCheckBoxColumn.HeaderText = "factparadomiciliar";
            this.factparadomiciliarDataGridViewCheckBoxColumn.Name = "factparadomiciliarDataGridViewCheckBoxColumn";
            this.factparadomiciliarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // factdomiciliadaDataGridViewCheckBoxColumn
            // 
            this.factdomiciliadaDataGridViewCheckBoxColumn.DataPropertyName = "factdomiciliada";
            this.factdomiciliadaDataGridViewCheckBoxColumn.HeaderText = "factdomiciliada";
            this.factdomiciliadaDataGridViewCheckBoxColumn.Name = "factdomiciliadaDataGridViewCheckBoxColumn";
            this.factdomiciliadaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // facttotalremesaDataGridViewTextBoxColumn
            // 
            this.facttotalremesaDataGridViewTextBoxColumn.DataPropertyName = "facttotalremesa";
            this.facttotalremesaDataGridViewTextBoxColumn.HeaderText = "facttotalremesa";
            this.facttotalremesaDataGridViewTextBoxColumn.Name = "facttotalremesaDataGridViewTextBoxColumn";
            this.facttotalremesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factpormailDataGridViewCheckBoxColumn
            // 
            this.factpormailDataGridViewCheckBoxColumn.DataPropertyName = "factpormail";
            this.factpormailDataGridViewCheckBoxColumn.HeaderText = "factpormail";
            this.factpormailDataGridViewCheckBoxColumn.Name = "factpormailDataGridViewCheckBoxColumn";
            this.factpormailDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // factmailDataGridViewTextBoxColumn
            // 
            this.factmailDataGridViewTextBoxColumn.DataPropertyName = "factmail";
            this.factmailDataGridViewTextBoxColumn.HeaderText = "factmail";
            this.factmailDataGridViewTextBoxColumn.Name = "factmailDataGridViewTextBoxColumn";
            this.factmailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "Facturas";
            this.facturasBindingSource.DataSource = this.dataSetAntonioLuis;
            // 
            // dataSetAntonioLuis
            // 
            this.dataSetAntonioLuis.DataSetName = "DataSetAntonioLuis";
            this.dataSetAntonioLuis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(802, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "&Salir";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(170, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 62;
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
            this.label1.TabIndex = 59;
            this.label1.Text = "&Añadir";
            this.label1.Visible = false;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.White;
            this.salir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("salir.BackgroundImage")));
            this.salir.Location = new System.Drawing.Point(790, 104);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(52, 56);
            this.salir.TabIndex = 58;
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            this.salir.MouseEnter += new System.EventHandler(this.salir_MouseEnter);
            this.salir.MouseLeave += new System.EventHandler(this.salir_MouseLeave);
            // 
            // sumar
            // 
            this.sumar.BackColor = System.Drawing.Color.White;
            this.sumar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sumar.BackgroundImage")));
            this.sumar.Location = new System.Drawing.Point(31, 104);
            this.sumar.Name = "sumar";
            this.sumar.Size = new System.Drawing.Size(52, 56);
            this.sumar.TabIndex = 55;
            this.sumar.UseVisualStyleBackColor = false;
            this.sumar.Click += new System.EventHandler(this.sumar_Click);
            this.sumar.MouseEnter += new System.EventHandler(this.sumar_MouseEnter);
            this.sumar.MouseLeave += new System.EventHandler(this.sumar_MouseLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(94, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "&Imprimir";
            this.label8.Visible = false;
            // 
            // imprimir
            // 
            this.imprimir.BackColor = System.Drawing.Color.White;
            this.imprimir.BackgroundImage = global::Proyecto_Antonio_Luis.Properties.Resources.Impresora;
            this.imprimir.Location = new System.Drawing.Point(89, 103);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(52, 56);
            this.imprimir.TabIndex = 69;
            this.imprimir.UseVisualStyleBackColor = false;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            this.imprimir.MouseEnter += new System.EventHandler(this.imprimir_MouseEnter);
            this.imprimir.MouseLeave += new System.EventHandler(this.imprimir_MouseLeave);
            // 
            // GestionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(874, 642);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvfactura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.sumar);
            this.MaximumSize = new System.Drawing.Size(890, 680);
            this.MinimumSize = new System.Drawing.Size(890, 680);
            this.Name = "GestionFacturas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionFacturas";
            this.Load += new System.EventHandler(this.GestionFacturas_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAntonioLuis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvfactura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button imprimir;
        private DataSetAntonioLuis dataSetAntonioLuis;
        private System.Windows.Forms.BindingSource facturasBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn factcontadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factnumerofactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factremesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factfechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factcodclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factnombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factdireccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factlocalidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factprovinciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factcpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factnifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factiban1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factiban2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factiban3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factiban4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factiban5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factiban6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factconcepto1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factbase1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factconcepto2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factbase2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factemleadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factprecioempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factbaseempleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facttipoivaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factimporteivaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facttotalfacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn factparaImprimirDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn factimpresaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn factparacontabilizarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn factcontabilizadaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn factparadomiciliarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn factdomiciliadaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facttotalremesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn factpormailDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factmailDataGridViewTextBoxColumn;
    }
}