using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoEcommerceModelos;
using System.Data;

namespace ProyectoEcommerceDatos
{
    public class UsuarioDatos
    {
        string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";

        SqlConnection conexion;

        public UsuarioDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lstUsuario = null;
            SqlCommand comando = new SqlCommand("usp_listar_usuarios", conexion);
            

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstUsuario = new List<Usuario>();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.codUsu = int.Parse(reader["codUsu"].ToString());
                    usuario.nomUsu = reader["nomUsu"].ToString();
                    usuario.apePatUsu = reader["apePatUsu"].ToString();
                    usuario.apeMatUsu = reader["apeMatUsu"].ToString();
                    usuario.dniUsu = reader["dniUsu"].ToString();
                    usuario.celUsu = reader["celUsu"].ToString();
                    usuario.nickUsu = reader["nickUsu"].ToString();
                    usuario.pwdUsu = reader["pwdUsu"].ToString();
                    usuario.fechaRegistroUsu = reader["fechaRegistroUsu"].ToString(); 
                    //usuario.codTipoUsu = int.Parse(reader["codTipoUsu"].ToString());
                    usuario.mailUsu = reader["mailUsu"].ToString();

                    lstUsuario.Add(usuario);
                }
            }



            conexion.Close();

            return lstUsuario;
        }

        public void actualizarUsuario(Usuario usuario)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_actualizar_usuarios", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codUsu", usuario.codUsu);
            comando.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
            comando.Parameters.AddWithValue("@apePatUsu", usuario.apePatUsu);
            comando.Parameters.AddWithValue("@apeMatUsu", usuario.apeMatUsu);
            comando.Parameters.AddWithValue("@dniUsu", usuario.dniUsu);
            comando.Parameters.AddWithValue("@celUsu", usuario.celUsu);
            comando.Parameters.AddWithValue("@nickUsu", usuario.nickUsu);
            comando.Parameters.AddWithValue("@pwdUsu", usuario.pwdUsu);
            //comando.Parameters.AddWithValue("@codTipoUsu", usuario.codTipoUsu);
            comando.Parameters.AddWithValue("@mailUsu", usuario.mailUsu);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void eliminarUsuario(int codUsu)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_eliminar_usuarios", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codUsu", codUsu);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void crearUsuario(Usuario usuario)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_crear_usuarios", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
            comando.Parameters.AddWithValue("@apePatUsu", usuario.apePatUsu);
            comando.Parameters.AddWithValue("@apeMatUsu", usuario.apeMatUsu);
            comando.Parameters.AddWithValue("@dniUsu", usuario.dniUsu);
            comando.Parameters.AddWithValue("@celUsu", usuario.celUsu);
            comando.Parameters.AddWithValue("@nickUsu", usuario.nickUsu);
            comando.Parameters.AddWithValue("@pwdUsu", usuario.pwdUsu);
           // comando.Parameters.AddWithValue("@codTipoUsu", usuario.codTipoUsu);
            comando.Parameters.AddWithValue("@mailUsu", usuario.mailUsu);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
