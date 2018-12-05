using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;

namespace ProyectoEcommerceNegocio
{
    public class EstadoVentaNegocio
    {
        EstadoVentaDatos datos = new EstadoVentaDatos();

        public List<EstadoVenta> listarComboEstadoVentas()
        {
            return datos.listarComboEstadoVentas();
        }

        public EstadoVenta obtenerEstadoVenta(int codEstBol)
        {
            return datos.obtenerEstadoVenta(codEstBol);
        }
    }

}
