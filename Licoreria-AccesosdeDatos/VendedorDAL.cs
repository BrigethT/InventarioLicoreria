using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Licoreria_Entidades;

namespace Licoreria_AccesosdeDatos
{
    public class VendedorDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable MostrarVendedores()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarVendedores";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public void InsertarVendedor(string nombreVendedor)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarVendedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreVendedor", nombreVendedor);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EditarVendedor(string nombreVendedor, int idvd)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarVendedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombreVendedor", nombreVendedor);
            comando.Parameters.AddWithValue("@idvd", idvd);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EliminarVendedor(int idvd)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarVendedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idvd", idvd);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public ArrayList obtenerVendedores()
        {
            ArrayList listaaux = new ArrayList();
            conexion.AbrirConexion();
            string consulta = "MostrarVendedores";
            SqlConnection con = conexion.AbrirConexion();
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EVendedor vendedoraux = new EVendedor(reader.GetInt32(0), reader.GetString(1));
                    listaaux.Add(vendedoraux);
                }
            }
            conexion.CerrarConexion();
            return listaaux;

        }
    }
}
