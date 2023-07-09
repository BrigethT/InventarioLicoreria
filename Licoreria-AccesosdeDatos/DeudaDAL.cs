using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Licoreria_AccesosdeDatos
{
    public class DeudaDAL
    {
        private ConexionBD conexion = new ConexionBD();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        //public DataTable MostrarDeuda()
        //{

        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "SELECT Deuda.prenda, Deuda.fecha, Deuda.estado,Cliente.nombreCliente FROM Cliente INNER JOIN Deuda ON Deuda.idCliente = Cliente.ced";
        //    comando.CommandType = CommandType.Text;
        //    leer = comando.ExecuteReader();
        //    tabla.Load(leer);
        //    conexion.CerrarConexion();
        //    return tabla;

        //}
        public DataTable MostrarDeuda()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarDeuda";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public DataTable MostrarDeudaCliente(string cedula)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarDeudaCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cedula", cedula);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        //public DataTable EstadoDeuda(string cedula)
        //{
        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "EstadoDeuda";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@cedula", cedula);
        //    leer = comando.ExecuteReader();
        //    tabla.Load(leer);
        //    conexion.CerrarConexion();
        //    return tabla;

        //}
        public void InsertarDeuda(string prenda, DateTime fecha, float total,string estado, byte[] foto, int idC)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarDeuda";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@prenda", prenda);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@total", total);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@foto", foto);
            comando.Parameters.AddWithValue("@idCliente", idC);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EditarDeuda(string prenda,  string estado, int idD)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarDeuda";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@prenda", prenda);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@idD", idD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EliminarDeuda(int idD)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarDeuda";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idD", idD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
