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
    public class VentaDatos
    {
        string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";
        SqlConnection conexion;

        public VentaDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public void crearVenta(Venta venta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_registrar_Venta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codUsu", venta.codUsu);
            comando.Parameters.AddWithValue("@numTarjeta", venta.numTarjeta);
            comando.Parameters.AddWithValue("@precioTotal", venta.precioTotal);
            comando.Parameters.AddWithValue("@codEstBol", venta.codEstBol);
            comando.Parameters.AddWithValue("@codBol", venta.codBol);  

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Venta> listarTodasLasVentas()
        {
            List<Venta> lstVenta = null;
            SqlCommand comando = new SqlCommand("usp_listar_todo_ventas", conexion);


            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstVenta = new List<Venta>();
                while (reader.Read())
                {
                    Venta venta = new Venta();
                    venta.codBol = int.Parse(reader["codBol"].ToString());
                    venta.codUsu = int.Parse(reader["codUsu"].ToString());
                    venta.fechaBol = reader["fechaBol"].ToString();
                    venta.numTarjeta = reader["numTarjeta"].ToString();
                    venta.precioTotal = double.Parse(reader["precioTotal"].ToString());
                    venta.codEstBol = int.Parse(reader["codEstBol"].ToString());

                    lstVenta.Add(venta);
                }
            } 
            conexion.Close();

            return lstVenta;
        }

        public List<Venta> listarVentasXEstado(int codEstBol)
        {
            List<Venta> lstVenta = null;
            SqlCommand comando = new SqlCommand("usp_listar_ventas_por_estado", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codEstBol", codEstBol);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstVenta = new List<Venta>();
                while (reader.Read())
                {
                    Venta venta = new Venta();
                    venta.codBol = int.Parse(reader["codBol"].ToString());
                    venta.codUsu = int.Parse(reader["codUsu"].ToString());
                    venta.fechaBol = reader["fechaBol"].ToString();
                    venta.numTarjeta = reader["numTarjeta"].ToString();
                    venta.precioTotal = double.Parse(reader["precioTotal"].ToString());
                    venta.codEstBol = int.Parse(reader["codEstBol"].ToString());

                    lstVenta.Add(venta);
                }
            }
            conexion.Close();

            return lstVenta;
        }

        public List<Venta> listarVentasXUsuario(int codUsu)
        {
            List<Venta> lstVenta = null;
            SqlCommand comando = new SqlCommand("usp_listar_ventas_por_usuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codUsu", codUsu);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstVenta = new List<Venta>();
                while (reader.Read())
                {
                    Venta venta = new Venta();
                    venta.codBol = int.Parse(reader["codBol"].ToString());
                    venta.codUsu = int.Parse(reader["codUsu"].ToString());
                    venta.fechaBol = reader["fechaBol"].ToString();
                    venta.numTarjeta = reader["numTarjeta"].ToString();
                    venta.precioTotal = double.Parse(reader["precioTotal"].ToString());
                    venta.codEstBol = int.Parse(reader["codEstBol"].ToString());

                    lstVenta.Add(venta);
                }
            }
            conexion.Close();

            return lstVenta;
        }

    }
}
