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

        public string actualizarEstadoVenta(Venta venta)
        {
            string mensaje = "";
            try
            {
                if (venta.codBol == 0)
                {
                    mensaje = "CODIGO DE BOLETA NO ES VALIDO";
                }
                else
                {
                    var existeBoleta = datos.listarTodasLasVentas().Any(x => x.codBol == venta.codBol);
                    if (existeBoleta)
                    {


                       // venta.validar();
                        datos.actualizarEstadoVenta(venta);
                        mensaje = "ESTADO ACTUALIZADO";
                    }
                    else

                        mensaje = "BOLETA NO EXISTE";

                }
            }
            catch (Exception e)
            {
                mensaje = "ERROR EN LA ACTUALIZACION DEL ESTADO " + e.Message;
            }

            return mensaje;
        }

        public string crearVenta(out int codBol,Venta venta)
        {
            string mensaje = "";
            codBol = 0;
            try
            {
                // venta.validar(); 
                codBol = datos.crearVenta(venta);
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
