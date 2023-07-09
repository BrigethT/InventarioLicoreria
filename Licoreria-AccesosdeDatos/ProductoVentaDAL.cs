using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Licoreria_AccesosdeDatos
{
    public class ProductoVentaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarProductoVenta()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductoVenta";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public void InsertarProductoVenta(int cantidad,  float vunitario, int idProd)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductoVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            //comando.Parameters.AddWithValue("@valor_total", total);
            comando.Parameters.AddWithValue("@valor_unitario", vunitario);
            comando.Parameters.AddWithValue("@idProd", idProd);
            
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EliminarProductoVenta(int idPV)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductoVenta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPV", idPV);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        //public int VerNombreProd(int idProd)
        //{
        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "VerNombreProd";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@idProd", idProd);
        //    comando.ExecuteNonQuery();
        //    comando.Parameters.Clear();
        //    conexion.CerrarConexion();
        //}
    }
}
