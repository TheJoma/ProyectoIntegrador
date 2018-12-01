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

        public MarcaProducto obtenerMarca(int codProdMar)
        {
            return datos.obtenerMarca(codProdMar);
        }
    }
}
