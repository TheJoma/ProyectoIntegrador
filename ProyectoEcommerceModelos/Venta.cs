using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceModelos
{
    public class Venta
    {
        public int codBol { get; set; }
        public int codUsu { get; set; }
        public string fechaBol { get; set; }
        public string numTarjeta { get; set; }
        public double precioTotal { get; set; }
        public int codEstBol { get; set; }
    }
}
