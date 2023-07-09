using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Licoreria_AccesosdeDatos;

namespace Licoreria_Negocio
{
    public class CNCliente
    {
        private ClienteDAL objetoCD = new ClienteDAL();
        public DataTable MostrarC()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCliente();
            return tabla;
        }
        public void InsertarC(string ced, string nombreCliente, string telefono, string direccion)
        {
            objetoCD.InsertarCliente(ced, nombreCliente, telefono, direccion);
        }
        public void EditarC(string ced, string nombreCliente, string telefono, string direccion, int idcl)
        {
            objetoCD.EditarCliente(ced, nombreCliente, telefono, direccion, idcl);
        }
        public void EliminarC(string id)
        {
            objetoCD.EliminarCliente(Convert.ToInt32(id));
        }

        public DataTable BuscarC(string variable)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarCliente(variable);
            return tabla;
        }
        public DataTable BuscarCnombre(string nombre)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarClienteNombre(nombre);
            return tabla;
        }
    }
}
