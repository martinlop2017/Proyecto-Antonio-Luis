using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Antonio_Luis.Utils.Models.Iva
{
    class AltaIvaViewModel
    {
        public int numerador { get; set; }
        public string ivaconcepto { get; set; }
        public decimal ivaporciento { get; set; }
        public decimal ivarecargo { get; set; }
        public string SelectedIVA { get; set; }
    }
}
