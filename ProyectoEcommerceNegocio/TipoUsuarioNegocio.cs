using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceNegocio
{
    public class TipoUsuarioNegocio
    {
        TipoUsuarioDatos datos = new TipoUsuarioDatos();

        public List<TipoUsuario> listarComboTipoUsuario()
        {
            return datos.listarComboTipoUsuario();
        }
    }
}
