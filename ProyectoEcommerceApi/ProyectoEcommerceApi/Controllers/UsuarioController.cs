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

        UsuarioNegocio negocios = new UsuarioNegocio();

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

        [HttpDelete]
        public string eliminarUsuario(Usuario usuario)
        {
            string mensaje = "";
            mensaje = negocios.eliminarUsuario(usuario.codUsu);
            return mensaje;
        }

    }
}
