using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Antonio_Luis.Formularios;



namespace Proyecto_Antonio_Luis
{
           


    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Facturacion());
        }
    }
}



     static class Globales
{
    public static string llamadas;
    public static int modificar;
    public static DateTime fechafactura;
    public static string mesfactura;
    public static decimal tipoiva;
        

}
