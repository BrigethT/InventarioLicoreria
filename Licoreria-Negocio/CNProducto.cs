using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Licoreria_AccesosdeDatos;

namespace Licoreria_Negocio
{
    public class CNProducto
    {
        private ProductoDAL objetoCD = new ProductoDAL();
        public DataTable MostrarP()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarProductos();
            return tabla;
        }
        public void InsertarP(string nombreProd, int stock, decimal precio_compra, decimal precio_venta, int idProd)
        {
            objetoCD.InsertarProducto(nombreProd, stock, precio_compra, precio_venta, idProd);
        }
        public void EditarP(string nombreProd, int stock, decimal precio_compra, decimal precio_venta, int idProv, int idpro)
        {
            objetoCD.EditarProductos(nombreProd, stock, precio_compra, precio_venta, idProv, idpro);
        }
        public void EliminarP(string id)
        {
            objetoCD.EliminarProducto(Convert.ToInt32(id));
        }

        public DataTable BuscarP(string nombreP)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarProductos(nombreP);
            return tabla;
        }
    }
}
