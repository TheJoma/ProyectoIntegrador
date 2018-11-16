using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceModelos
{
    public class Producto
    {
        public string codPro { get; set; }
        public string descripcionPro { get; set; }
        public string detallePro { get; set; }
        public double precioPro { get; set; }
        public int stockPro { get; set; }
        public int codProdCat { get; set; }
        public int codProdMar { get; set; }

    }
}
