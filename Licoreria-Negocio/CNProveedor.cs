using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Licoreria_AccesosdeDatos;

namespace Licoreria_Negocio
{
    public class CNProveedor
    {
        private ProveedorDAL objetoCD = new ProveedorDAL();
        public DataTable MostrarC()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarProveedor();
            return tabla;
        }
        public void InsertarProv(string ruc, string nombreProv, string telefono)
        {
            objetoCD.InsertarProveedor(ruc, nombreProv, telefono);
        }
        public void EditarProv(string ruc, string nombreProv, string telefono, int idpr)
        {
            objetoCD.EditarProveedor(ruc, nombreProv, telefono, idpr);
        }
        public void EliminarProv(int id)
        {
            objetoCD.EliminarProveedor(id);
        }

        public DataTable BuscarProv(string ruc)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarProveedor(ruc);
            return tabla;
        }
    }
}
