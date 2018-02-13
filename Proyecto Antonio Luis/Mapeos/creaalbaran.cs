using BaseDatos;
using Proyecto_Antonio_Luis.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Antonio_Luis.Mapeos
{
    public class creaalbaran
    {
        public static List<albaranesclientes> pasoclientes_a_albaran(List<Clientes> albaran)
        {
            //hace el mapeo

            return albaran.Select(c => new albaranesclientes()

            {

                albcod = c.codcliente.Value,
                albnombre = c.nombrecliente,
                albcif = c.cifcliente,
                albdireccion = c.direcioncliente,
                alblocalidad = c.localidacliente,
                albprovincia = c.provinciacliente,
                albcp = c.cod_postalcliente,
                albmail = c.mailcliente,
                albpormail = c.pormailcliente.Value,
                albdomiciliado = c.domiciliadocliente.Value,
                albiban1 = c.iban1cliente,
                albiban2 = c.iban2cliente,
                albiban3 = c.iban3cliente,
                albiban4 = c.iban4cliente,
                albiban5 = c.iban5cliente,
                albiban6 = c.iban6cliente,
                albgrupo = c.grupocliente,
                albempleados = c.empleadoscliente.Value,
                albpvpempleados = c.precioempleadocliente.Value,
                albtarifa = c.tarifacliente.Value,
                albfecha = Globales.fechafactura.ToString("dd/MM/yyyy"),
                albmes = Globales.mesfactura,
                albconcepto1 = "Honorários Correspondiente al mes de " + Globales.mesfactura.ToString(),
                albconcepto2 = null,
                albtarifa2 = 0,
                alblaboral = c.empleadoscliente.Value * c.precioempleadocliente.Value,
                albbase = (c.empleadoscliente.Value * c.precioempleadocliente.Value) + c.tarifacliente.Value,
                albiva = (((c.empleadoscliente.Value * c.precioempleadocliente.Value) + c.tarifacliente.Value)
                           * Globales.tipoiva / 100),
                albtotal = ((c.empleadoscliente.Value * c.precioempleadocliente.Value) + c.tarifacliente.Value) +
                            (((c.empleadoscliente.Value * c.precioempleadocliente.Value) + c.tarifacliente.Value) * Globales.tipoiva  / 100),


                albtipoiva = Globales.tipoiva,
                albparadomiciliar = c.domiciliadocliente.Value,
                albparacontabilizar = c.contabilizarcliente.Value,
               // albparaimprimir = c.

             
            }).ToList();

            //return listaTemporales;
        }

    }
}

