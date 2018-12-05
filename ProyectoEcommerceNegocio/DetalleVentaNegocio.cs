using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;

namespace ProyectoEcommerceNegocio
{
    public class DetalleVentaNegocio
    {
        DetalleVentasDatos datos = new DetalleVentasDatos();

        public string crearDetalleVenta(DetalleVenta detalleVenta)
        {
            string mensaje = "";
            try
            {

                //detalleVenta.validar();
                datos.crearDetalleVenta(detalleVenta);
                mensaje = "Detalle CREADO";
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA CREACION DEL Detalle " + e.Message;
            }

            return mensaje;
        }

        public List<DetalleVenta> listarDetalleXVentas(int codBol)
        {
            return datos.listarDetalleXVentas(codBol);
        }
    }
}
