namespace Proyecto_Antonio_Luis.Formularios
{
    partial class Form3
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.administracionAntonioDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.administracionAntonioDataSet1 = new Proyecto_Antonio_Luis.AdministracionAntonioDataSet1();
            this.dataSetListadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetListados = new Proyecto_Antonio_Luis.DataSetListados();
            this.facturasTableAdapter = new Proyecto_Antonio_Luis.AdministracionAntonioDataSet1TableAdapters.FacturasTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datoslistadoremeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datoslistadoremeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // administracionAntonioDataSet1BindingSource
            // 
            this.administracionAntonioDataSet1BindingSource.DataSource = this.administracionAntonioDataSet1;
            this.administracionAntonioDataSet1BindingSource.Position = 0;
            // 
            // administracionAntonioDataSet1
            // 
            this.administracionAntonioDataSet1.DataSetName = "AdministracionAntonioDataSet1";
            this.administracionAntonioDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetListadosBindingSource
            // 
            this.dataSetListadosBindingSource.DataSource = this.dataSetListados;
            this.dataSetListadosBindingSource.Position = 0;
            // 
            // dataSetListados
            // 
            this.dataSetListados.DataSetName = "DataSetListados";
            this.dataSetListados.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturasTableAdapter
            // 
            this.facturasTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 26;
            reportDataSource1.Name = "DaraSetFacturas";
            reportDataSource1.Value = this.datoslistadoremeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_Antonio_Luis.Formularios.ReportFacturas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(729, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "Facturas";
            this.facturasBindingSource.DataSource = this.administracionAntonioDataSet1BindingSource;
            // 
            // datoslistadoremeBindingSource
            // 
            this.datoslistadoremeBindingSource.DataSource = typeof(Proyecto_Antonio_Luis.Clases.datoslistadoreme);
            this.datoslistadoremeBindingSource.CurrentChanged += new System.EventHandler(this.datoslistadoremeBindingSource_CurrentChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administracionAntonioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datoslistadoremeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dataSetListadosBindingSource;
        private DataSetListados dataSetListados;
        private System.Windows.Forms.BindingSource administracionAntonioDataSet1BindingSource;
        private AdministracionAntonioDataSet1 administracionAntonioDataSet1;
        private AdministracionAntonioDataSet1TableAdapters.FacturasTableAdapter facturasTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource datoslistadoremeBindingSource;
        private System.Windows.Forms.BindingSource facturasBindingSource;
    }
}