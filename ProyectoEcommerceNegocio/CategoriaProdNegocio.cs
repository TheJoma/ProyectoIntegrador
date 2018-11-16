using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceNegocio
{
    public class CategoriaProdNegocio
    {
        CategoriaProdDatos datos = new CategoriaProdDatos();

        public List<CategoriaProducto> listarComboCategoriasProd()
        {
            return datos.listarComboCategoriasProd();
        }
    }
}
