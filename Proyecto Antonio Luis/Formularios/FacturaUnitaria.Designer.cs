namespace Proyecto_Antonio_Luis.Formularios
{
    partial class FacturaUnitaria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturaUnitaria));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelNumero = new System.Windows.Forms.Label();
            this.labelNumeroFactura = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.labelCliente = new System.Windows.Forms.Label();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.checkOcasional = new System.Windows.Forms.CheckBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelNif = new System.Windows.Forms.Label();
            this.txtNif = new System.Windows.Forms.TextBox();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.labelCp = new System.Windows.Forms.Label();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.labelLocalidad = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.labelProvincia = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.labelCobro = new System.Windows.Forms.Label();
            this.labelEfectivo = new System.Windows.Forms.Label();
            this.checkContabilizar = new System.Windows.Forms.CheckBox();
            this.checkRetencion = new System.Windows.Forms.CheckBox();
            this.checkPorMail = new System.Windows.Forms.CheckBox();
            this.groupCliente = new System.Windows.Forms.GroupBox();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIva = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridLineas = new System.Windows.Forms.DataGridView();
            this.tituloBase = new System.Windows.Forms.Label();
            this.valorBase = new System.Windows.Forms.Label();
            this.tituloIva = new System.Windows.Forms.Label();
            this.valorIva = new System.Windows.Forms.Label();
            this.tituloRetencion = new System.Windows.Forms.Label();
            this.valorRetencion = new System.Windows.Forms.Label();
            this.tituloSuplidos = new System.Windows.Forms.Label();
            this.valorSuplidos = new System.Windows.Forms.Label();
            this.tituloTotal = new System.Windows.Forms.Label();
            this.valorTotal = new System.Windows.Forms.Label();
            this.groupTotales = new System.Windows.Forms.GroupBox();
            this.labelDesglose = new System.Windows.Forms.Label();
            this.labelAviso = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imprimir = new System.Windows.Forms.Button();
            this.groupCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLineas)).BeginInit();
            this.groupTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitulo.Font = new System.Drawing.Font("Tahoma", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.labelTitulo.Location = new System.Drawing.Point(290, 14);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Factura directa";
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.BackColor = System.Drawing.Color.Transparent;
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero.Location = new System.Drawing.Point(40, 80);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.TabIndex = 2;
            this.labelNumero.Text = "Factura nº";
            // 
            // labelNumeroFactura
            // 
            this.labelNumeroFactura.AutoSize = true;
            this.labelNumeroFactura.BackColor = System.Drawing.Color.Transparent;
            this.labelNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumeroFactura.Location = new System.Drawing.Point(120, 80);
            this.labelNumeroFactura.Name = "labelNumeroFactura";
            this.labelNumeroFactura.TabIndex = 3;
            this.labelNumeroFactura.Text = "";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.BackColor = System.Drawing.Color.Transparent;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(620, 80);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.TabIndex = 4;
            this.labelFecha.Text = "Fecha";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFecha.Location = new System.Drawing.Point(674, 76);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFecha.TabIndex = 5;
            this.dateTimePickerFecha.ValueChanged += new System.EventHandler(this.dateTimePickerFecha_ValueChanged);
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.Location = new System.Drawing.Point(12, 28);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.TabIndex = 6;
            this.labelCliente.Text = "Cliente";
            // 
            // comboCliente
            // 
            this.comboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(90, 25);
            this.comboCliente.MaxDropDownItems = 20;
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(480, 24);
            this.comboCliente.TabIndex = 7;
            this.comboCliente.SelectedIndexChanged += new System.EventHandler(this.comboCliente_SelectedIndexChanged);
            this.comboCliente.Leave += new System.EventHandler(this.comboCliente_Leave);
            // 
            // checkOcasional
            // 
            this.checkOcasional.AutoSize = true;
            this.checkOcasional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOcasional.Location = new System.Drawing.Point(590, 27);
            this.checkOcasional.Name = "checkOcasional";
            this.checkOcasional.TabIndex = 8;
            this.checkOcasional.Text = "Cliente ocasional (no dado de alta)";
            this.checkOcasional.UseVisualStyleBackColor = true;
            this.checkOcasional.CheckedChanged += new System.EventHandler(this.checkOcasional_CheckedChanged);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(12, 63);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.TabIndex = 9;
            this.labelNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(90, 60);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(480, 22);
            this.txtNombre.TabIndex = 10;
            // 
            // labelNif
            // 
            this.labelNif.AutoSize = true;
            this.labelNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNif.Location = new System.Drawing.Point(590, 63);
            this.labelNif.Name = "labelNif";
            this.labelNif.TabIndex = 11;
            this.labelNif.Text = "NIF";
            // 
            // txtNif
            // 
            this.txtNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNif.Location = new System.Drawing.Point(640, 60);
            this.txtNif.MaxLength = 20;
            this.txtNif.Name = "txtNif";
            this.txtNif.Size = new System.Drawing.Size(180, 22);
            this.txtNif.TabIndex = 12;
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccion.Location = new System.Drawing.Point(12, 95);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.TabIndex = 13;
            this.labelDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(90, 92);
            this.txtDireccion.MaxLength = 150;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(480, 22);
            this.txtDireccion.TabIndex = 14;
            // 
            // labelCp
            // 
            this.labelCp.AutoSize = true;
            this.labelCp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCp.Location = new System.Drawing.Point(590, 95);
            this.labelCp.Name = "labelCp";
            this.labelCp.TabIndex = 15;
            this.labelCp.Text = "C.P.";
            // 
            // txtCp
            // 
            this.txtCp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCp.Location = new System.Drawing.Point(640, 92);
            this.txtCp.MaxLength = 20;
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(180, 22);
            this.txtCp.TabIndex = 16;
            // 
            // labelLocalidad
            // 
            this.labelLocalidad.AutoSize = true;
            this.labelLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocalidad.Location = new System.Drawing.Point(12, 127);
            this.labelLocalidad.Name = "labelLocalidad";
            this.labelLocalidad.TabIndex = 17;
            this.labelLocalidad.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalidad.Location = new System.Drawing.Point(90, 124);
            this.txtLocalidad.MaxLength = 100;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(230, 22);
            this.txtLocalidad.TabIndex = 18;
            // 
            // labelProvincia
            // 
            this.labelProvincia.AutoSize = true;
            this.labelProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProvincia.Location = new System.Drawing.Point(330, 127);
            this.labelProvincia.Name = "labelProvincia";
            this.labelProvincia.TabIndex = 19;
            this.labelProvincia.Text = "Provincia";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvincia.Location = new System.Drawing.Point(400, 124);
            this.txtProvincia.MaxLength = 100;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(170, 22);
            this.txtProvincia.TabIndex = 20;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMail.Location = new System.Drawing.Point(590, 127);
            this.labelMail.Name = "labelMail";
            this.labelMail.TabIndex = 21;
            this.labelMail.Text = "Email";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(640, 124);
            this.txtMail.MaxLength = 100;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(180, 22);
            this.txtMail.TabIndex = 22;
            // 
            // labelCobro
            // 
            this.labelCobro.AutoSize = true;
            this.labelCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCobro.Location = new System.Drawing.Point(12, 159);
            this.labelCobro.Name = "labelCobro";
            this.labelCobro.TabIndex = 23;
            this.labelCobro.Text = "Cobro";
            // 
            // labelEfectivo
            // 
            this.labelEfectivo.AutoSize = true;
            this.labelEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEfectivo.ForeColor = System.Drawing.Color.DimGray;
            this.labelEfectivo.Location = new System.Drawing.Point(90, 159);
            this.labelEfectivo.Name = "labelEfectivo";
            this.labelEfectivo.TabIndex = 24;
            this.labelEfectivo.Text = "En efectivo (no se pasa al banco)";
            // 
            // checkContabilizar
            // 
            this.checkContabilizar.AutoSize = true;
            this.checkContabilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkContabilizar.Location = new System.Drawing.Point(505, 158);
            this.checkContabilizar.Name = "checkContabilizar";
            this.checkContabilizar.TabIndex = 25;
            this.checkContabilizar.Text = "Contabilizar";
            this.checkContabilizar.UseVisualStyleBackColor = true;
            // 
            // checkRetencion
            // 
            this.checkRetencion.AutoSize = true;
            this.checkRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRetencion.Location = new System.Drawing.Point(618, 158);
            this.checkRetencion.Name = "checkRetencion";
            this.checkRetencion.TabIndex = 26;
            this.checkRetencion.Text = "Retención IRPF";
            this.checkRetencion.UseVisualStyleBackColor = true;
            this.checkRetencion.CheckedChanged += new System.EventHandler(this.checkRetencion_CheckedChanged);
            // 
            // checkPorMail
            // 
            this.checkPorMail.AutoSize = true;
            this.checkPorMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPorMail.Location = new System.Drawing.Point(740, 158);
            this.checkPorMail.Name = "checkPorMail";
            this.checkPorMail.TabIndex = 27;
            this.checkPorMail.Text = "Por mail";
            this.checkPorMail.UseVisualStyleBackColor = true;
            // 
            // groupCliente
            // 
            this.groupCliente.BackColor = System.Drawing.Color.Transparent;
            this.groupCliente.Controls.Add(this.labelCliente);
            this.groupCliente.Controls.Add(this.comboCliente);
            this.groupCliente.Controls.Add(this.checkOcasional);
            this.groupCliente.Controls.Add(this.labelNombre);
            this.groupCliente.Controls.Add(this.txtNombre);
            this.groupCliente.Controls.Add(this.labelNif);
            this.groupCliente.Controls.Add(this.txtNif);
            this.groupCliente.Controls.Add(this.labelDireccion);
            this.groupCliente.Controls.Add(this.txtDireccion);
            this.groupCliente.Controls.Add(this.labelCp);
            this.groupCliente.Controls.Add(this.txtCp);
            this.groupCliente.Controls.Add(this.labelLocalidad);
            this.groupCliente.Controls.Add(this.txtLocalidad);
            this.groupCliente.Controls.Add(this.labelProvincia);
            this.groupCliente.Controls.Add(this.txtProvincia);
            this.groupCliente.Controls.Add(this.labelMail);
            this.groupCliente.Controls.Add(this.txtMail);
            this.groupCliente.Controls.Add(this.labelCobro);
            this.groupCliente.Controls.Add(this.labelEfectivo);
            this.groupCliente.Controls.Add(this.checkContabilizar);
            this.groupCliente.Controls.Add(this.checkRetencion);
            this.groupCliente.Controls.Add(this.checkPorMail);
            this.groupCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCliente.Location = new System.Drawing.Point(40, 108);
            this.groupCliente.Name = "groupCliente";
            this.groupCliente.Size = new System.Drawing.Size(834, 192);
            this.groupCliente.TabIndex = 28;
            this.groupCliente.TabStop = false;
            this.groupCliente.Text = "Datos del cliente";
            // 
            // dataGridLineas
            // 
            this.dataGridLineas.AllowUserToResizeRows = false;
            this.dataGridLineas.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridLineas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConcepto,
            this.colCantidad,
            this.colPrecio,
            this.colIva,
            this.colImporte});
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridLineas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridLineas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridLineas.Location = new System.Drawing.Point(40, 310);
            this.dataGridLineas.Name = "dataGridLineas";
            this.dataGridLineas.RowHeadersWidth = 25;
            this.dataGridLineas.Size = new System.Drawing.Size(834, 180);
            this.dataGridLineas.TabIndex = 29;
            this.dataGridLineas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLineas_CellEndEdit);
            this.dataGridLineas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridLineas_CellValidating);
            this.dataGridLineas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLineas_CellValueChanged);
            this.dataGridLineas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridLineas_CurrentCellDirtyStateChanged);
            this.dataGridLineas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridLineas_DataError);
            this.dataGridLineas.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridLineas_DefaultValuesNeeded);
            this.dataGridLineas.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridLineas_RowsRemoved);
            // 
            // colConcepto
            // 
            this.colConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colConcepto.DefaultCellStyle = dataGridViewCellStyle3;
            this.colConcepto.HeaderText = "Concepto";
            this.colConcepto.MaxInputLength = 250;
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCantidad.Width = 80;
            // 
            // colPrecio
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPrecio.Width = 100;
            // 
            // colIva
            // 
            this.colIva.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colIva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIva.HeaderText = "IVA";
            this.colIva.Name = "colIva";
            this.colIva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIva.Width = 90;
            // 
            // colImporte
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle6;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            this.colImporte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImporte.Width = 110;
            // 
            // tituloBase
            // 
            this.tituloBase.AutoSize = true;
            this.tituloBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloBase.Location = new System.Drawing.Point(12, 20);
            this.tituloBase.Name = "tituloBase";
            this.tituloBase.TabIndex = 30;
            this.tituloBase.Text = "Base imponible";
            // 
            // valorBase
            // 
            this.valorBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorBase.Location = new System.Drawing.Point(170, 18);
            this.valorBase.Name = "valorBase";
            this.valorBase.Size = new System.Drawing.Size(165, 20);
            this.valorBase.TabIndex = 31;
            this.valorBase.Text = "0,00 €";
            this.valorBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tituloIva
            // 
            this.tituloIva.AutoSize = true;
            this.tituloIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloIva.Location = new System.Drawing.Point(12, 43);
            this.tituloIva.Name = "tituloIva";
            this.tituloIva.TabIndex = 32;
            this.tituloIva.Text = "IVA";
            // 
            // valorIva
            // 
            this.valorIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorIva.Location = new System.Drawing.Point(170, 41);
            this.valorIva.Name = "valorIva";
            this.valorIva.Size = new System.Drawing.Size(165, 20);
            this.valorIva.TabIndex = 33;
            this.valorIva.Text = "0,00 €";
            this.valorIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tituloRetencion
            // 
            this.tituloRetencion.AutoSize = true;
            this.tituloRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloRetencion.Location = new System.Drawing.Point(12, 66);
            this.tituloRetencion.Name = "tituloRetencion";
            this.tituloRetencion.TabIndex = 34;
            this.tituloRetencion.Text = "Retención IRPF";
            // 
            // valorRetencion
            // 
            this.valorRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorRetencion.Location = new System.Drawing.Point(170, 64);
            this.valorRetencion.Name = "valorRetencion";
            this.valorRetencion.Size = new System.Drawing.Size(165, 20);
            this.valorRetencion.TabIndex = 35;
            this.valorRetencion.Text = "0,00 €";
            this.valorRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tituloSuplidos
            // 
            this.tituloSuplidos.AutoSize = true;
            this.tituloSuplidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloSuplidos.Location = new System.Drawing.Point(12, 89);
            this.tituloSuplidos.Name = "tituloSuplidos";
            this.tituloSuplidos.TabIndex = 36;
            this.tituloSuplidos.Text = "Suplidos";
            // 
            // valorSuplidos
            // 
            this.valorSuplidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorSuplidos.Location = new System.Drawing.Point(170, 87);
            this.valorSuplidos.Name = "valorSuplidos";
            this.valorSuplidos.Size = new System.Drawing.Size(165, 20);
            this.valorSuplidos.TabIndex = 37;
            this.valorSuplidos.Text = "0,00 €";
            this.valorSuplidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tituloTotal
            // 
            this.tituloTotal.AutoSize = true;
            this.tituloTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloTotal.Location = new System.Drawing.Point(12, 118);
            this.tituloTotal.Name = "tituloTotal";
            this.tituloTotal.TabIndex = 38;
            this.tituloTotal.Text = "TOTAL A PAGAR";
            // 
            // valorTotal
            // 
            this.valorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(208)))));
            this.valorTotal.Location = new System.Drawing.Point(150, 116);
            this.valorTotal.Name = "valorTotal";
            this.valorTotal.Size = new System.Drawing.Size(185, 24);
            this.valorTotal.TabIndex = 39;
            this.valorTotal.Text = "0,00 €";
            this.valorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupTotales
            // 
            this.groupTotales.BackColor = System.Drawing.Color.Transparent;
            this.groupTotales.Controls.Add(this.tituloBase);
            this.groupTotales.Controls.Add(this.valorBase);
            this.groupTotales.Controls.Add(this.tituloIva);
            this.groupTotales.Controls.Add(this.valorIva);
            this.groupTotales.Controls.Add(this.tituloRetencion);
            this.groupTotales.Controls.Add(this.valorRetencion);
            this.groupTotales.Controls.Add(this.tituloSuplidos);
            this.groupTotales.Controls.Add(this.valorSuplidos);
            this.groupTotales.Controls.Add(this.tituloTotal);
            this.groupTotales.Controls.Add(this.valorTotal);
            this.groupTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTotales.Location = new System.Drawing.Point(527, 508);
            this.groupTotales.Name = "groupTotales";
            this.groupTotales.Size = new System.Drawing.Size(344, 144);
            this.groupTotales.TabIndex = 40;
            this.groupTotales.TabStop = false;
            this.groupTotales.Text = "Totales";
            // 
            // labelDesglose
            // 
            this.labelDesglose.BackColor = System.Drawing.Color.Transparent;
            this.labelDesglose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesglose.ForeColor = System.Drawing.Color.DimGray;
            this.labelDesglose.Location = new System.Drawing.Point(40, 512);
            this.labelDesglose.Name = "labelDesglose";
            this.labelDesglose.Size = new System.Drawing.Size(470, 18);
            this.labelDesglose.TabIndex = 41;
            this.labelDesglose.Text = "";
            // 
            // labelAviso
            // 
            this.labelAviso.BackColor = System.Drawing.Color.Transparent;
            this.labelAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAviso.ForeColor = System.Drawing.Color.DimGray;
            this.labelAviso.Location = new System.Drawing.Point(40, 534);
            this.labelAviso.Name = "labelAviso";
            this.labelAviso.Size = new System.Drawing.Size(470, 18);
            this.labelAviso.TabIndex = 42;
            this.labelAviso.Text = "Una vez emitida, la factura no se puede modificar ni borrar.";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(60, 575);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 60);
            this.button1.TabIndex = 43;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(290, 575);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 60);
            this.button2.TabIndex = 44;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imprimir
            // 
            this.imprimir.BackColor = System.Drawing.Color.White;
            this.imprimir.BackgroundImage = global::Proyecto_Antonio_Luis.Properties.Resources.Impresora;
            this.imprimir.Location = new System.Drawing.Point(60, 577);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(52, 56);
            this.imprimir.TabIndex = 45;
            this.imprimir.UseVisualStyleBackColor = false;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // FacturaUnitaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(914, 671);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelAviso);
            this.Controls.Add(this.labelDesglose);
            this.Controls.Add(this.groupTotales);
            this.Controls.Add(this.dataGridLineas);
            this.Controls.Add(this.groupCliente);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.labelNumeroFactura);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.labelTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(930, 709);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(930, 709);
            this.Name = "FacturaUnitaria";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eGESTION";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FacturaUnitaria_FormClosing);
            this.Load += new System.EventHandler(this.FacturaUnitaria_Load);
            this.groupCliente.ResumeLayout(false);
            this.groupCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLineas)).EndInit();
            this.groupTotales.ResumeLayout(false);
            this.groupTotales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Label labelNumeroFactura;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.CheckBox checkOcasional;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelNif;
        private System.Windows.Forms.TextBox txtNif;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label labelCp;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.Label labelLocalidad;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label labelProvincia;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label labelCobro;
        private System.Windows.Forms.Label labelEfectivo;
        private System.Windows.Forms.CheckBox checkContabilizar;
        private System.Windows.Forms.CheckBox checkRetencion;
        private System.Windows.Forms.CheckBox checkPorMail;
        private System.Windows.Forms.GroupBox groupCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewComboBoxColumn colIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridView dataGridLineas;
        private System.Windows.Forms.Label tituloBase;
        private System.Windows.Forms.Label valorBase;
        private System.Windows.Forms.Label tituloIva;
        private System.Windows.Forms.Label valorIva;
        private System.Windows.Forms.Label tituloRetencion;
        private System.Windows.Forms.Label valorRetencion;
        private System.Windows.Forms.Label tituloSuplidos;
        private System.Windows.Forms.Label valorSuplidos;
        private System.Windows.Forms.Label tituloTotal;
        private System.Windows.Forms.Label valorTotal;
        private System.Windows.Forms.GroupBox groupTotales;
        private System.Windows.Forms.Label labelDesglose;
        private System.Windows.Forms.Label labelAviso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button imprimir;
    }
}
