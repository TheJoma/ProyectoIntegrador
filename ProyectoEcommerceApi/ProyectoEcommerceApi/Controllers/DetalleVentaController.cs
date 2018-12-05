using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectoEcommerceModelos;
using ProyectoEcommerceNegocio;
using System.Web.Http.Cors;

namespace ProyectoEcommerceApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DetalleVentaController : ApiController
    {
        DetalleVentaNegocio negocios = new DetalleVentaNegocio();

        [HttpPost]
        public string crearDetalleVenta(DetalleVenta detalleVenta)
        {
            string mensaje = "";
            mensaje = negocios.crearDetalleVenta(detalleVenta);
            return mensaje;
        }

        [HttpGet]
        public List<DetalleVenta> listarDetalleXVentas(int codBol)
        {
            var lista = negocios.listarDetalleXVentas(codBol);
            return lista;
        }

    }
}
