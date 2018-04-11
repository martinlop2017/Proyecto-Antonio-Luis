namespace Proyecto_Antonio_Luis.Formularios
{
    partial class Espera
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Proyecto_Antonio_Luis.Properties.Resources.Flor_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(77, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 58);
            this.panel1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_Antonio_Luis.Properties.Resources.Flor_1;
            this.pictureBox1.Location = new System.Drawing.Point(322, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 147);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Espera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 294);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Espera";
            this.Text = "Espera";
            this.Load += new System.EventHandler(this.Espera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}