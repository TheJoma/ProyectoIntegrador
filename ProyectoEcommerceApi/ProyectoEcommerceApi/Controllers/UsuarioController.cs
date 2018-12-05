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
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class UsuarioController : ApiController
    {

        ProyectoNegocio negocios = new ProyectoNegocio();

        [HttpGet]
        public List<Usuario> ListarUsuarios()
        {
            var lista = negocios.listarUsuarios();
            return lista;
        }

        [HttpPost]
        public string crearUsuario(Usuario usuario)
        {
            string mensaje = "";
            mensaje = negocios.crearUsuario(usuario);
            return mensaje;
        }

        [HttpPost]
        public string actualizarUsuario(Usuario usuario)
        {
            string mensaje = "";
            mensaje = negocios.actualizarUsuario(usuario);
            return mensaje;
        }

        [HttpPost]
        public string eliminarUsuario(Usuario usuario)
        {
            string mensaje = "";
            mensaje = negocios.eliminarUsuario(usuario.codUsu);
            return mensaje;
        }

    }
}
