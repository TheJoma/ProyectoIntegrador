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
    public class TipoUsuarioController : ApiController
    {
        TipoUsuarioNegocio negocios = new TipoUsuarioNegocio();
        [HttpGet]
        public List<TipoUsuario> listarTipoUsuario()
        {
            var lista = negocios.listarTipoUsuario();
            return lista;
        }
    }
}
    

