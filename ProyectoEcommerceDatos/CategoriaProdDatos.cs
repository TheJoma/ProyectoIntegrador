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
    public class CategoriaProdDatos
    {
        string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";
        //string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;Trusted_Connection=True";
        SqlConnection conexion;

        public CategoriaProdDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public List<CategoriaProducto> listarComboCategoriasProd()
        {
            List<CategoriaProducto> lstCatPro = null;
            SqlCommand comando = new SqlCommand("usp_listarCombo_categoria", conexion);
            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstCatPro = new List<CategoriaProducto>();
                while (reader.Read())
                {
                    CategoriaProducto catPro = new CategoriaProducto();
                    catPro.codProdCat = int.Parse(reader["codProdCat"].ToString());
                    catPro.nomProdCat = reader["nomProdCat"].ToString();

                    lstCatPro.Add(catPro);
                }
            } 

            conexion.Close();

            return lstCatPro;
        }

        public CategoriaProducto obtenerCategoria(int codProdCat)
        {
            CategoriaProducto categoria = null;

            SqlCommand comando = new SqlCommand("usp_obtener_categoria", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codProdCat", codProdCat);

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    CategoriaProducto c = new CategoriaProducto();
                    c.codProdCat = int.Parse(reader["codProdCat"].ToString());
                    c.nomProdCat = reader["nomProdCat"].ToString();
                    categoria = c;
                }
            }
            conexion.Close();

            return categoria;
        }

    }
}
