using BaseDatos;
using Proyecto_Antonio_Luis.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_Antonio_Luis.Mapeos
{
    public class Mapeo
    {


        public static List<temporal> MapeoClienteDB_A_Temporal(List<Clientes>pasoclientes)
        {
            //hace el mapeo

            

            return pasoclientes.Select(c => new temporal()
            {
                tempcod = c.codcliente.Value,
                tempnombre = c.nombrecliente,
                tempcif = c.cifcliente,
                tempdireccion = c.direcioncliente,
                templocalidad = c.localidacliente,
                tempprovincia = c.provinciacliente,
                tempcp = c.cod_postalcliente,
                tempmail = c.mailcliente,
                temppormail = c.pormailcliente.Value,
                tempdomiciliado = c.domiciliadocliente.Value,
                tempiban1 = c.iban1cliente,
                tempiban2 = c.iban2cliente.Value,
                tempiban3 = c.iban3cliente.Value,
                tempiban4 = c.iban4cliente.Value,
                tempiban5 = c.iban5cliente.Value,
                tempiban6 = c.iban6cliente.Value,
                tempgrupo = c.grupocliente,
                tempempleados = c.empleadoscliente.Value,
                tempprecioempelado = c.precioempleadocliente.Value,
                temptarifa = c.tarifacliente.Value,               
                tempfecharemesa = Globales.fechafactura.ToString("dd/mm/yyyy"),
                tempmes = Globales.mesfactura,
                tempconcepto1 = "Honorários Correspondiente al mes de " + Globales.fechafactura.ToString("mm"),
              
               
            }).ToList();

            //return listaTemporales;
        }

    }

}
