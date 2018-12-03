using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceModelos
{
    public class ValidarPagoRequest
    {
        public string numeroTarjeta { get; set; }
        public int TipoTarjeta { get; set; }
        public string CodigoSeguridadTarjeta{get;set;}
        public string TitularTarjeta{get;set;}
        public string MesExpiracionTarjeta{get;set;}
        public string AñoExpiracionTarjeta { get;set;}
        public double MontoConsumir { get; set; }


    }
}
