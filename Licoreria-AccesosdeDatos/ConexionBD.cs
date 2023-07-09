using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Licoreria_AccesosdeDatos
{
    public class ConexionBD
    {
        private SqlConnection Conexion = new SqlConnection("data source=(local);initial catalog=LicoreriaDB;User Id = sa; Password = Doda10582;Integrated Security=true"); 
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
