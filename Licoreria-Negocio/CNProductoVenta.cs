using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Licoreria_AccesosdeDatos;

namespace Licoreria_Negocio
{
    public class CNProductoVenta
    {
        private ProductoVentaDAL objetoCD = new ProductoVentaDAL();
        public DataTable MostrarPV()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarProductoVenta();
            return tabla;
        }
        public void InsertarPV(int cantidad, float unitario, int idProd)
        {
            objetoCD.InsertarProductoVenta(cantidad, unitario, idProd);
        }
        public void EliminarPV(string id)
        {
            objetoCD.EliminarProductoVenta(Convert.ToInt32(id));
        }
    }
}
