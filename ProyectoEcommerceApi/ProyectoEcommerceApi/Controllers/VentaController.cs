using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http; 
using ProyectoEcommerceModelos;
using ProyectoEcommerceNegocio;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoEcommerceApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VentaController : ApiController
    {
        VentaNegocio negocios = new VentaNegocio();


        [HttpPost]
        public string crearVenta(Venta venta)
        {
            string mensaje = "";
            mensaje = negocios.crearVenta(venta);
            return mensaje;
        }

        [HttpGet]
        public List<Venta> listarTodasLasVentas()
        {
            var lista = negocios.listarTodasLasVentas();
            return lista;
        }

        [HttpGet]
        public List<Venta> listarVentasXEstado(int codEstBol)
        {
            var lista = negocios.listarVentasXEstado(codEstBol);
            return lista;
        }

        [HttpGet]
        public List<Venta> listarVentasXUsuario(int codUsu)
        {
            var lista = negocios.listarVentasXUsuario(codUsu);
            return lista;
        }
    }
}
