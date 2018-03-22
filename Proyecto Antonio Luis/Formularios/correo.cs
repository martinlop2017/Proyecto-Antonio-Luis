using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Mail;
using System.Net.Mime;



namespace Proyecto_Antonio_Luis.Formularios
{
    public partial class correo : Form
        {
       // String path;
       // MailMessage mail = new MailMessage();

        public correo()
        {
            InitializeComponent();
        }
             

            private void Button1_Click(object sender, EventArgs e)
            {
               
               
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                textBox2.Text = "martinlopezestevez@gmail.com";
            }

            private void Button2_Click(object sender, EventArgs e)
            {


            }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(textBox1.Text));
            email.From = new MailAddress(textBox2.Text);
            email.Subject = (textBox3.Text );
            email.Body = textBox4.Text;
                //"Cualquier contenido en <b>HTML</b> para enviarlo por correo electrónico.";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            Attachment data = new Attachment("C:\\Equipo Martin\\Programacion\\Repositorio Remoto\\Proyecto Antonio Luis\\Proyecto Antonio Luis\\Imagenes\\Botones\\Big\\Historico.bmp", MediaTypeNames.Application.Octet);

            email.Attachments.Add(data);


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
       //     smtp.Credentials = new NetworkCredential("email_from@example.com", "contraseña");
            smtp.Credentials = new System.Net.NetworkCredential
                          ("martinlopezestevez@gmail.com", "Espigon_%2007&");

            string output = null;


            try
            {
                smtp.Send(email);
                email.Dispose();
                MessageBox.Show("Corre electrónico fue enviado satisfactoriamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando correo electrónico: " + ex.Message);
            }

            Console.WriteLine(output);




        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }


    
}
