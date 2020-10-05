namespace Proyecto_Antonio_Luis.Formularios
{
    partial class Gestionlistados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestionlistados));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Clientes");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sistema", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Facturas Clientes Entre Fechas");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Gestion", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFechaFinal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFechaInicial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBoxClienteFinal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxClienteInicial = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.BackgroundImage")));
            this.buttonImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonImprimir.Location = new System.Drawing.Point(110, 424);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(208, 60);
            this.buttonImprimir.TabIndex = 67;
            this.buttonImprimir.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.Location = new System.Drawing.Point(343, 424);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(208, 60);
            this.button8.TabIndex = 66;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(484, 317);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 65;
            this.label2.Text = "A Fecha";
            // 
            // textBoxFechaFinal
            // 
            this.textBoxFechaFinal.Enabled = false;
            this.textBoxFechaFinal.Location = new System.Drawing.Point(487, 338);
            this.textBoxFechaFinal.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFechaFinal.Name = "textBoxFechaFinal";
            this.textBoxFechaFinal.Size = new System.Drawing.Size(107, 20);
            this.textBoxFechaFinal.TabIndex = 64;
            this.textBoxFechaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(359, 317);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 63;
            this.label4.Text = "De Fecha";
            // 
            // textBoxFechaInicial
            // 
            this.textBoxFechaInicial.Enabled = false;
            this.textBoxFechaInicial.Location = new System.Drawing.Point(362, 338);
            this.textBoxFechaInicial.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFechaInicial.Name = "textBoxFechaInicial";
            this.textBoxFechaInicial.Size = new System.Drawing.Size(108, 20);
            this.textBoxFechaInicial.TabIndex = 62;
            this.textBoxFechaInicial.Text = "12/12/2018";
            this.textBoxFechaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(238, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 42);
            this.label9.TabIndex = 57;
            this.label9.Text = "Listados";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(61, 155);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Clientes";
            treeNode1.Text = "Clientes";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Sistema";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Sistema";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Facturas";
            treeNode3.Text = "Facturas Clientes Entre Fechas";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Gestion";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "Gestion";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(276, 226);
            this.treeView1.TabIndex = 56;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // textBoxClienteFinal
            // 
            this.textBoxClienteFinal.Enabled = false;
            this.textBoxClienteFinal.Location = new System.Drawing.Point(66, 178);
            this.textBoxClienteFinal.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxClienteFinal.Name = "textBoxClienteFinal";
            this.textBoxClienteFinal.Size = new System.Drawing.Size(233, 20);
            this.textBoxClienteFinal.TabIndex = 60;
            this.textBoxClienteFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(62, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "A Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(62, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "De Cliente";
            // 
            // textBoxClienteInicial
            // 
            this.textBoxClienteInicial.Enabled = false;
            this.textBoxClienteInicial.Location = new System.Drawing.Point(65, 118);
            this.textBoxClienteInicial.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxClienteInicial.Name = "textBoxClienteInicial";
            this.textBoxClienteInicial.Size = new System.Drawing.Size(234, 20);
            this.textBoxClienteInicial.TabIndex = 58;
            this.textBoxClienteInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxClienteInicial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxClienteFinal);
            this.panel1.Location = new System.Drawing.Point(37, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 483);
            this.panel1.TabIndex = 68;
            // 
            // Gestionlistados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFechaFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFechaInicial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.treeView1);
            this.Name = "Gestionlistados";
            this.Text = "Gestionlistados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFechaFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFechaInicial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBoxClienteFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxClienteInicial;
        private System.Windows.Forms.Panel panel1;
    }
}