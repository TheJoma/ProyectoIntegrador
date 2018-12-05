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
    public class DetalleVentasDatos
    {

        string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";
        SqlConnection conexion;

        public DetalleVentasDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public void crearDetalleVenta(DetalleVenta detalleVenta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("usp_registrar_detalle_Venta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codBol", detalleVenta.codBol);
            comando.Parameters.AddWithValue("@codProd", detalleVenta.codProd);
            comando.Parameters.AddWithValue("@canProd", detalleVenta.canProd);
            comando.Parameters.AddWithValue("@preProd", detalleVenta.preProd); 

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public List<DetalleVenta> listarDetalleXVentas(int codBol)
        {
            List<DetalleVenta> lstDetVenta = null;
            SqlCommand comando = new SqlCommand("usp_listar_detalle_ventas_por_ventas", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codBol", codBol);

            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstDetVenta = new List<DetalleVenta>();
                while (reader.Read())
                {
                    DetalleVenta detVen = new DetalleVenta();
                    detVen.codDetBol = int.Parse(reader["codDetBol"].ToString());
                    detVen.codBol = int.Parse(reader["codBol"].ToString());
                    detVen.codProd = int.Parse(reader["codProd"].ToString());
                    detVen.canProd = int.Parse(reader["canProd"].ToString());
                    detVen.preProd = double.Parse(reader["preProd"].ToString()); 

                    lstDetVenta.Add(detVen);
                }
            }
            conexion.Close();

            return lstDetVenta;
        }
    }
}
