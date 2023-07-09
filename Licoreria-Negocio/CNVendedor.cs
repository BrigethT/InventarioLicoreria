using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Licoreria_AccesosdeDatos;
using System.Collections;

namespace Licoreria_Negocio
{
    public class CNVendedor
    {
        private VendedorDAL objetoCD = new VendedorDAL();
        public DataTable MostrarV()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarVendedores();
            return tabla;
        }
        public void InsertarVend(string nombreVendedor)
        {
            objetoCD.InsertarVendedor(nombreVendedor);
        }
        public void EditarVend(string nombreVendedor, int idvd)
        {
            objetoCD.EditarVendedor(nombreVendedor, idvd);
        }
        public void EliminarVend(int id)
        {
            objetoCD.EliminarVendedor(id);
        }
        public ArrayList ObtenerVendedores()
        {
            ArrayList lista = new ArrayList();
            lista = objetoCD.obtenerVendedores();
            return lista;
        }
    }
}
