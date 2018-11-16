using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ProyectoEcommerceModelos;

namespace ProyectoEcommerceDatos
{
    public class TipoUsuarioDatos
    {
        string conexionBD = @"server=LAPTOP-SIRTGLBO\SQLJOSEMARIA;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";

        SqlConnection conexion;

        public TipoUsuarioDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public List<TipoUsuario> listarComboTipoUsuario()
        {
            List<TipoUsuario> lstTipoUsuario = null;
            SqlCommand comando = new SqlCommand("usp_listar_tipoUsuario", conexion);
            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstTipoUsuario = new List<TipoUsuario>();
                while (reader.Read())
                {
                    TipoUsuario tipUsu = new TipoUsuario();
                    tipUsu.codTipoUsu = int.Parse(reader["codTipoUsu"].ToString());
                    tipUsu.desTipoUsu = reader["desTipoUsu"].ToString();

                    lstTipoUsuario.Add(tipUsu);
                }
            }

            conexion.Close();

            return lstTipoUsuario;
        }
    }
}
