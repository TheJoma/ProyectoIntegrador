using ProyectoEcommerceModelos;
using ProyectoEcommerceNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoEcommerceApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PagoController : ApiController
    {
        ValidarPagoNegocios negocios = new ValidarPagoNegocios();

        [HttpPost]
        public ValidarPagoResponse Validar(ValidarPagoRequest request)
        {
            ValidarPagoResponse response = new ValidarPagoResponse();
            string mensaje = "";
            response.TransaccionCompleta=negocios.ValidarPago(out mensaje,
                                                            request.TipoTarjeta,
                                                            request.numeroTarjeta,
                                                            request.TitularTarjeta,
                                                            request.MontoConsumir,
                                                            request.MesExpiracionTarjeta,
                                                            request.AñoExpiracionTarjeta,
                                                            request.CodigoSeguridadTarjeta);
            response.MensajeTransaccion = mensaje;

     


           return response;
        }
    }
}
