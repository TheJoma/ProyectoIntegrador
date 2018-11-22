using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceNegocio
{
    public class ProductoNegocio
    {
        ProductoDatos datos = new ProductoDatos();

        public List<Producto> listarProducto()
        {
            return datos.listarProducto();
        }

        public string crearProducto(Producto producto)
        {
            string mensaje = "";
            try
            {
               
                producto.validar();
                datos.crearProducto(producto);
                mensaje = "PRODUCTO CREADO";
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA CREACION DEL PRODUCTO " + e.Message;
            }

            return mensaje;
        }

        public Producto obtenerProducto(int codPro)
        {
            return datos.obtenerProducto(codPro);
        }

        public string actualizarProducto(Producto producto)
        {
            string mensaje = "";
            try
            { 
                    var existeProducto = datos.listarProducto().Any(x => x.codPro == producto.codPro);
                    if (existeProducto)
                    {
                        producto.validar();
                        datos.actualizarProducto(producto);
                        mensaje = "PRODUCTO ACTUALIZADO";
                    }
                    else

                        mensaje = "PRODUCTO NO EXISTE";

                
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA ACTUALIZACION DEL PRODUCTO " + e.Message;
            }

            return mensaje;
        }

        public string eliminarProducto(int codPro)
        {
            string mensaje = "";
            try
            {
                var existeProducto = datos.listarProducto().Any(x => x.codPro == codPro);
                if (existeProducto)
                {
                    //producto.validar();
                    datos.eliminarProducto(codPro);
                    mensaje = "PRODUCTO ELIMINADO";
                }
                else

                    mensaje = "PRODUCTO NO EXISTE";
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA ELIMINACION DEL PRODUCTO " + e.Message;
            }

            return mensaje;
        }
    }
}

