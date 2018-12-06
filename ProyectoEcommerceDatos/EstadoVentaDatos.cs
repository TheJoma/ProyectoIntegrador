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
    public class EstadoVentaDatos
    {
        //string conexionBD = @"server=LAPTOP-SIRTGLBO\SQLJOSEMARIA;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";
        string conexionBD = @"server=.;database=BD_PROYECTO_INTEGRADOR;uid=sa;pwd=sql";
        SqlConnection conexion;

        public EstadoVentaDatos()
        {
            conexion = new SqlConnection(conexionBD);
        }

        public List<EstadoVenta> listarComboEstadoVentas()
        {
            List<EstadoVenta> lstEstVen = null;
            SqlCommand comando = new SqlCommand("usp_Listar_Estado_Venta", conexion);
            conexion.Open();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                lstEstVen = new List<EstadoVenta>();
                while (reader.Read())
                {
                    EstadoVenta estVen = new EstadoVenta();
                    estVen.codEstBol = int.Parse(reader["codEstBol"].ToString());
                    estVen.descriBol = reader["descriBol"].ToString();

                    lstEstVen.Add(estVen);
                }
            }

            conexion.Close();

            return lstEstVen;
        }

        public EstadoVenta obtenerEstadoVenta(int codEstBol)
        {
            EstadoVenta estVen = null;

            SqlCommand comando = new SqlCommand("usp_obtener_estado_venta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codEstBol", codEstBol);

            conexion.Open();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    EstadoVenta est = new EstadoVenta();
                    est.codEstBol = int.Parse(reader["codEstBol"].ToString());
                    est.descriBol = reader["descriBol"].ToString();
                    estVen = est;
                }
            }
            conexion.Close();

            return estVen;
        }

    }
}
