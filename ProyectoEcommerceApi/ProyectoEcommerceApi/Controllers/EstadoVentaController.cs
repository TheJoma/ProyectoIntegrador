using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;  
using System.Web.Http.Cors;
using ProyectoEcommerceModelos;
using ProyectoEcommerceNegocio;

namespace ProyectoEcommerceApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EstadoVentaController : ApiController
    {
        EstadoVentaNegocio negocios = new EstadoVentaNegocio();

        [HttpGet]
        public List<EstadoVenta> listarComboEstadoVentas()
        {
            var lista = negocios.listarComboEstadoVentas();
            return lista;
        }

        [HttpGet]
        public EstadoVenta obtenerEstadoVenta(int codEstBol)
        {
            var categoria = negocios.obtenerEstadoVenta(codEstBol);
            return categoria;
        }
    }
}
