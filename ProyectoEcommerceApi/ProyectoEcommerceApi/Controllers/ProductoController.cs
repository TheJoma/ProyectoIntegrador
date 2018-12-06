using ProyectoEcommerceModelos;
using ProyectoEcommerceNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web;
using System.IO;

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
        public Producto obtenerProducto(int codPro)
        {
            var producto = negocios.obtenerProducto(codPro);
            return producto;
        }

        /*[HttpPost]
        public string crearProducto(Producto producto)
        {
            string mensaje = "";
            string imgPro = null;

            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["imgPro"];
            imgPro = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imgPro = imgPro + DateTime.Now.ToString("ssmmyyfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imgPro);
            postedFile.SaveAs(filePath);
            producto.imgPro = imgPro;

            mensaje = negocios.crearProducto(producto);
            return mensaje;
        }*/

        [HttpPost]
        [Route("api/Producto/crearProducto")]
        public HttpResponseMessage crearProducto()
        {
            string imgPro = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["archivoImagen"];
            //Create custom filename
            imgPro = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imgPro = imgPro + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imgPro);
            postedFile.SaveAs(filePath);
            Producto producto = new Producto();
            producto.descripcionPro = httpRequest["descripcionPro"];
            producto.detallePro= httpRequest["detallePro"];
            producto.precioPro= double.Parse(httpRequest["precioProx100"])/100;
            producto.stockPro = int.Parse(httpRequest["stockPro"]);
            producto.imgPro = imgPro;
            producto.codProdCat = int.Parse(httpRequest["codProdCat"]);
            producto.codProdMar= int.Parse(httpRequest["codProdMar"]);

            String mensaje = negocios.crearProducto(producto);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("api/Producto/obtenerImagen")]
        public HttpResponseMessage obtenerImagen(int codPro,int aux)
        {
            Producto producto = negocios.obtenerProducto(codPro);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            var path = "~/Image/" + producto.imgPro;
            path = System.Web.Hosting.HostingEnvironment.MapPath(path);
            var ext = System.IO.Path.GetExtension(path);
            var contents = System.IO.File.ReadAllBytes(path);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(contents);
            response.Content = new StreamContent(ms);
            ext=ext.Replace(".", "");
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/"+ext); 
            return response;
        }

     
        [HttpPost]
        public string actualizarProducto(Producto producto)
        {
            string mensaje = "";
            mensaje = negocios.actualizarProducto(producto);
            return mensaje;
        }


        [HttpPost]
        [Route("api/Producto/actualizarProductoConImagen")]
        public HttpResponseMessage actualizarProductoConImagen()
        {
            string imgPro = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["archivoImagen"];
            //Create custom filename
            imgPro = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imgPro = imgPro + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imgPro);
            postedFile.SaveAs(filePath);
            Producto producto = new Producto();
            producto.codPro = int.Parse(httpRequest["codPro"]);
            producto.descripcionPro = httpRequest["descripcionPro"];
            producto.detallePro = httpRequest["detallePro"];
            producto.precioPro = double.Parse(httpRequest["precioProx100"]) / 100;
            producto.stockPro = int.Parse(httpRequest["stockPro"]);
            producto.imgPro = imgPro;
            producto.codProdCat = int.Parse(httpRequest["codProdCat"]);
            producto.codProdMar = int.Parse(httpRequest["codProdMar"]);

            String mensaje = negocios.actualizarProductoConImagen(producto);

            return Request.CreateResponse(HttpStatusCode.Created);
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

