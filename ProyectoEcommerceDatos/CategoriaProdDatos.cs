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
        string conexionBD = @"server=LAPTOP-SIRTGLBO\SQLJOSEMARIA;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";

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


    }
}
