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
    public class ProductoController : ApiController
    {

        ProductoNegocio negocios = new ProductoNegocio();

        [HttpGet]
        public List<Producto> listarProducto()
        {
            var lista = negocios.listarProducto();
            return lista;
        }

        [HttpGet]
        public Producto obtenerProducto(String codPro)
        {
            var producto = negocios.obtenerProducto(codPro);
            return producto;
        }

        [HttpPost]
        public string crearProducto(Producto producto)
        {
            string mensaje = "";
            mensaje = negocios.crearProducto(producto);
            return mensaje;
        }

        [HttpPost]
        public string actualizarProducto(Producto producto)
        {
            string mensaje = "";
            mensaje = negocios.actualizarProducto(producto);
            return mensaje;
        }

        [HttpPost]
        public string eliminarProducto(Producto producto)
        {
            string mensaje = "";
            mensaje = negocios.eliminarProducto(producto.codPro);
            return mensaje;
        }

    }
}

