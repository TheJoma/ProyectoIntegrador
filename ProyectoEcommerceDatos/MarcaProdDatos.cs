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
    public class MarcaProdDatos
    {
        string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";
        //string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;Trusted_Connection=True";
        SqlConnection conexion;

        public MarcaProdDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public List<MarcaProducto> listarComboMarcaProd()
        {
            List<MarcaProducto> lstMarcaProd = null;
            SqlCommand comando = new SqlCommand("usp_listarMarca_categoria", conexion);
            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstMarcaProd = new List<MarcaProducto>();
                while (reader.Read())
                {
                    MarcaProducto marPro = new MarcaProducto();
                    marPro.codProdMar = int.Parse(reader["codProdMar"].ToString());
                    marPro.nomProdMar = reader["nomProdMar"].ToString();

                    lstMarcaProd.Add(marPro);
                }
            }

            conexion.Close();

            return lstMarcaProd;
        }

        public MarcaProducto obtenerMarca(int codProdMar)
        {
            MarcaProducto marca = null;

            SqlCommand comando = new SqlCommand("usp_obtener_marca", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codProdMar", codProdMar);

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    MarcaProducto m = new MarcaProducto();
                    m.codProdMar = int.Parse(reader["codProdMar"].ToString());
                    m.nomProdMar = reader["nomProdMar"].ToString();
                    marca = m;
                }
            }
            conexion.Close();

            return marca;
        }

    }

}

   

