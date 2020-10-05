namespace Proyecto_Antonio_Luis.Formularios
{
    partial class Scaner
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
            this.button4 = new System.Windows.Forms.Button();
            this.Devices = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(518, 421);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 29);
            this.button4.TabIndex = 6;
            this.button4.Text = "COPIA SEGURIDAD";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Devices
            // 
            this.Devices.FormattingEnabled = true;
            this.Devices.Location = new System.Drawing.Point(21, 58);
            this.Devices.Name = "Devices";
            this.Devices.Size = new System.Drawing.Size(353, 186);
            this.Devices.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(454, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 363);
            this.panel1.TabIndex = 10;
            // 
            // Scaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 486);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Devices);
            this.Controls.Add(this.button4);
            this.Name = "Scaner";
            this.Text = "Scaner";
            this.Load += new System.EventHandler(this.Scaner_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox Devices;
        private System.Windows.Forms.Panel panel1;
    }
}