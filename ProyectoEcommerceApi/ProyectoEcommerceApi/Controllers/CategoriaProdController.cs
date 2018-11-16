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
    public class CategoriaProdController : ApiController
    {
        CategoriaProdNegocio negocios = new CategoriaProdNegocio();

        [HttpGet]
        public List<CategoriaProducto> listarCategoriasProd()
        {
            var lista = negocios.listarCategoriasProd();
            return lista;
        }
    }
}