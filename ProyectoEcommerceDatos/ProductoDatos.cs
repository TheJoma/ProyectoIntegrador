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
    public class ProductoDatos
    {
        string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";

        SqlConnection conexion;

        public ProductoDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public List<Producto> listarProducto()
        {
            List<Producto> lstProducto = null;
            SqlCommand comando = new SqlCommand("usp_listar_producto", conexion);


            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstProducto = new List<Producto>();
                while (reader.Read())
                {
                    Producto prod = new Producto();
                    prod.codPro = reader["codPro"].ToString();
                    prod.descripcionPro = reader["descripcionPro"].ToString();
                    prod.detallePro = reader["detallePro"].ToString();
                    prod.precioPro = double.Parse(reader["precioPro"].ToString());
                    prod.stockPro = int.Parse(reader["stockPro"].ToString());
                    prod.codProdCat = int.Parse(reader["codProdCat"].ToString());
                    prod.codProdMar = int.Parse(reader["codProdMar"].ToString());

                    lstProducto.Add(prod);
                }
            } 
            conexion.Close();

            return lstProducto;
        }

        public Producto obtenerProducto(string codPro)
        {
            Producto producto = new Producto();
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_obtener_producto", conexion);
            comando.Parameters.AddWithValue("@codPro", codPro);

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                producto.codPro = reader["codPro"].ToString();
                producto.descripcionPro = reader["descripcionPro"].ToString();
                producto.detallePro = reader["detallePro"].ToString();
                producto.precioPro = double.Parse(reader["precioPro"].ToString());
                producto.stockPro = int.Parse(reader["stockPro"].ToString());
                producto.codProdCat = int.Parse(reader["codProdCat"].ToString());
                producto.codProdMar = int.Parse(reader["codProdMar"].ToString());
            }
            conexion.Close();

            return producto;
        }

        public void crearProducto(Producto producto)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_crear_producto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codPro", producto.codPro);
            comando.Parameters.AddWithValue("@descripcionPro", producto.descripcionPro);
            comando.Parameters.AddWithValue("@detallePro", producto.detallePro);
            comando.Parameters.AddWithValue("@precioPro", producto.precioPro);
            comando.Parameters.AddWithValue("@stockPro", producto.stockPro);
            comando.Parameters.AddWithValue("@codProdCat", producto.codProdCat);
            comando.Parameters.AddWithValue("@codProdMar", producto.codProdMar);

            comando.ExecuteNonQuery();
            conexion.Close();
        }


        public void actualizarProducto(Producto producto)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_actualizar_producto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codPro", producto.codPro);
            comando.Parameters.AddWithValue("@descripcionPro", producto.descripcionPro);
            comando.Parameters.AddWithValue("@detallePro", producto.detallePro);
            comando.Parameters.AddWithValue("@precioPro", producto.precioPro);
            comando.Parameters.AddWithValue("@stockPro", producto.stockPro);
            comando.Parameters.AddWithValue("@codProdCat", producto.codProdCat);
            comando.Parameters.AddWithValue("@codProdMar", producto.codProdMar);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void eliminarProducto(string codPro)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_eliminar_producto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codPro", codPro);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
