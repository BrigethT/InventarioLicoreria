using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Licoreria_AccesosdeDatos;


namespace Licoreria_Negocio
{
    public class CNDeuda
    {
        private DeudaDAL objetoCD = new DeudaDAL();
        public DataTable MostrarD()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarDeuda();
            return tabla;
        }
        public DataTable MostrarDC(string ced)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarDeudaCliente(ced);
            return tabla;
        }
        //public DataTable EstadoDeuda(string ced)
        //{
        //    DataTable tabla = new DataTable();
        //    tabla = objetoCD.EstadoDeuda(ced);
        //    return tabla;
        //}

        public void InsertarD(string prenda, DateTime fecha, float total, string estado, byte[] foto, int idC)
        {
            objetoCD.InsertarDeuda(prenda, fecha, total, estado, foto, idC);
        }
        public void EditarD(string prenda, string estado, int idD)
        {
            objetoCD.EditarDeuda(prenda,estado, idD);
        }
        public void EliminarD(int id)
        {
            objetoCD.EliminarDeuda(id);
        }
    }
}
