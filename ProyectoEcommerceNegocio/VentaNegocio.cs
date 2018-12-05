using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;

namespace ProyectoEcommerceNegocio
{
    public class VentaNegocio
    {
        VentaDatos datos = new VentaDatos();

        public string crearVenta(Venta venta)
        {
            string mensaje = "";
            try
            {
                // venta.validar(); 
                datos.crearVenta(venta);
                mensaje = " VENTA REGISTRADA";
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA CREACION DE LA VENTA" + e.Message;
            }

            return mensaje;
        }

        public List<Venta> listarTodasLasVentas()
        {
            return datos.listarTodasLasVentas();
        }

        public List<Venta> listarVentasXEstado(int codEstBol)
        {
            return datos.listarVentasXEstado(codEstBol);
        }

        public List<Venta> listarVentasXUsuario(int codUsu)
        {
            return datos.listarVentasXUsuario(codUsu);
        }

    }
}
