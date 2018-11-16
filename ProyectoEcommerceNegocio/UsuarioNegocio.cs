using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceNegocio
{
    public class UsuarioNegocio
    {
        UsuarioDatos datos = new UsuarioDatos();

        public List<Usuario> listarUsuarios()
        {
            return datos.listarUsuarios();
        }

        public string crearUsuario(Usuario usuario)
        {
            string mensaje = "";
            try
            {
                usuario.validar();
                datos.crearUsuario(usuario);
                mensaje = "USUARIO CREADO";
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA CREACION DEL USUARIO" + e.Message;
            }

            return mensaje;
        }

        public string actualizarUsuario(Usuario usuario)
        {
            string mensaje = "";
            try
            {
                if (usuario.codUsu == 0)
                {
                    mensaje = "CODIGO DE USUARIO NO ES VALIDO";
                }
                else
                {
                    var existeUsuario = datos.listarUsuarios().Any(x => x.codUsu == usuario.codUsu);
                    if (existeUsuario)
                    {

                        
                        usuario.validar();
                        datos.actualizarUsuario(usuario);
                        mensaje = "USUARIO ACTUALIZADO";
                    }
                    else
                    
                        mensaje = "USUARIO NO EXISTE";
                    
                }
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA ACTUALIZACION DEL USUARIO " + e.Message;
            }

            return mensaje;
        }

        public string eliminarUsuario(int codUsu)
        {
            string mensaje = "";
            try
            {
                if (codUsu == 0)
                {
                    mensaje = "CODIGO DE USUARIO NO ES VALIDO";
                }
                else
                {
                    var existeUsuario = datos.listarUsuarios().Any(x => x.codUsu == codUsu);
                    if (existeUsuario)
                    {

                        //aca se agrega la validaciones
                        //usuario.validar();
                        datos.eliminarUsuario(codUsu);
                        mensaje = "USUARIO ELIMINADO";
                    }
                    else

                        mensaje = "USUARIO NO EXISTE";

                }
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA ELIMINACION DEL USUARIO " + e.Message;
            }
            return mensaje;
        }
    }
}
