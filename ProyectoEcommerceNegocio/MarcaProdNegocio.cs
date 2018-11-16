using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceNegocio
{
    public class MarcaProdNegocio
    {
        MarcaProdDatos datos = new MarcaProdDatos();

        public List<MarcaProducto> listarComboMarcaProd()
        {
            return datos.listarComboMarcaProd();
        }
    }
}
