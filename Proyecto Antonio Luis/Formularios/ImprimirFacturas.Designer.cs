namespace Proyecto_Antonio_Luis.Formularios
{
    partial class ImprimirFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimirFacturas));
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDocumentoFinal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDocumentoInicial = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(97, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(405, 42);
            this.label9.TabIndex = 52;
            this.label9.Text = "Imprimir Documentos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(300, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 51;
            this.label1.Text = "Documento Final";
            // 
            // textBoxDocumentoFinal
            // 
            this.textBoxDocumentoFinal.Location = new System.Drawing.Point(439, 148);
            this.textBoxDocumentoFinal.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDocumentoFinal.Name = "textBoxDocumentoFinal";
            this.textBoxDocumentoFinal.Size = new System.Drawing.Size(98, 20);
            this.textBoxDocumentoFinal.TabIndex = 50;
            this.textBoxDocumentoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDocumentoFinal.Leave += new System.EventHandler(this.textBoxDocumentoFinal_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(36, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 49;
            this.label3.Text = "Documento Inical";
            // 
            // textBoxDocumentoInicial
            // 
            this.textBoxDocumentoInicial.Location = new System.Drawing.Point(177, 150);
            this.textBoxDocumentoInicial.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDocumentoInicial.Name = "textBoxDocumentoInicial";
            this.textBoxDocumentoInicial.Size = new System.Drawing.Size(96, 20);
            this.textBoxDocumentoInicial.TabIndex = 48;
            this.textBoxDocumentoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.Location = new System.Drawing.Point(290, 230);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(208, 60);
            this.button8.TabIndex = 47;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGuardar.BackgroundImage")));
            this.buttonGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGuardar.Location = new System.Drawing.Point(65, 230);
            this.buttonGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(208, 60);
            this.buttonGuardar.TabIndex = 46;
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // ImprimirFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(578, 350);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDocumentoFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDocumentoInicial);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.buttonGuardar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(594, 388);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(594, 388);
            this.Name = "ImprimirFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eGESTION";
            this.Load += new System.EventHandler(this.ImprimirFacturas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDocumentoFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDocumentoInicial;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
    }
}