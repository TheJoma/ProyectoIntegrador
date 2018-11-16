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
                //aca se agrega la validaciones
                //usuario.validar();
                datos.crearProducto(producto);
                mensaje = "PRODUCTO CREADO";
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA CREACION DEL PRODUCTO " + e.Message;
            }

            return mensaje;
        }
        
    }
}
