using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceModelos
{
    public class Producto
    {
        public int codPro { get; set; }
        public string descripcionPro { get; set; }
        public string detallePro { get; set; }
        public double precioPro { get; set; }
        public int stockPro { get; set; }
        public string imgPro { get; set; }
        public int codProdCat { get; set; }
        public int codProdMar { get; set; }

        public void validar()
        {
         
         
           
            if (string.IsNullOrEmpty(descripcionPro))
                throw new Exception("Debe colocar descripcion a su  producto");
            //if (string.IsNullOrEmpty(detallePro))
              //  throw new Exception("Debe colocar un detalle a su producto");
            if (string.IsNullOrEmpty(precioPro.ToString()))
                throw new Exception("Debe colocar un precio a su producto");
            if (string.IsNullOrEmpty(stockPro.ToString()))
                throw new Exception("Debe colocar el stock de su  producto ");
            if (string.IsNullOrEmpty(codProdCat.ToString()))
                throw new Exception("Debe seleccionar una categoria");
            if (string.IsNullOrEmpty(codProdMar.ToString()))
                throw new Exception("Debe seleccionar una marca");
            //if (string.IsNullOrEmpty(imgPro.ToString()))
                //throw new Exception("Ingrese imagen a su productos");



        }
    }
}
