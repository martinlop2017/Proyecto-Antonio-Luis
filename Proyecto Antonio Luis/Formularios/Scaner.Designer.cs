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
            this.components = new System.ComponentModel.Container();
            this.txtOutput = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txt = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.FormattingEnabled = true;
            this.txtOutput.Location = new System.Drawing.Point(12, 38);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(398, 160);
            this.txtOutput.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(416, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(558, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 294);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(40, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 29);
            this.button4.TabIndex = 6;
            this.button4.Text = "COPIA SEGURIDAD";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(166, 391);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(257, 20);
            this.textBox2.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 247);
            this.progressBar1.MarqueeAnimationSpeed = 15;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(665, 41);
            this.progressBar1.Step = 50;
            this.progressBar1.TabIndex = 8;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(12, 12);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(665, 20);
            this.txt.TabIndex = 9;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Scaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 486);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOutput);
            this.Name = "Scaner";
            this.Text = "Scaner";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox txtOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}