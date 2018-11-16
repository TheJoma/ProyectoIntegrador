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

        public void validar()
        {
            if(string.IsNullOrEmpty(codPro))
                throw new Exception("Ingrese un codigo a su productos");
            if (codPro.Length != 6)
                throw new Exception("Debe contener 6 caractes el codigo de producto");
            if (string.IsNullOrEmpty(codPro))
                throw new Exception("Ingrese un codigo a su productos");
            if (string.IsNullOrEmpty(descripcionPro))
                throw new Exception("Debe colocar descripcion a su  producto");
            if (string.IsNullOrEmpty(detallePro))
                throw new Exception("Debe colocar un detalle a su producto");
            if (string.IsNullOrEmpty(precioPro.ToString()))
                throw new Exception("Debe colocar un precio a su producto");
            if (string.IsNullOrEmpty(stockPro.ToString()))
                throw new Exception("Debe colocar el stock de su  producto ");
            if (string.IsNullOrEmpty(codProdCat.ToString()))
                throw new Exception("Debe seleccionar una categoria");
            if (string.IsNullOrEmpty(codProdMar.ToString()))
                throw new Exception("Debe seleccionar una marca");



        }
    }
}
