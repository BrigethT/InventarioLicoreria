using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Licoreria_Entidades
{
    public class EListaProducto
    {
        ArrayList ListaPr = new ArrayList();

        public EListaProducto(ArrayList listaPr)
        {
            ListaPr = listaPr;
        }

        public void AgregarProducto(EProveedor p)
        {
            ListaPr.Add(p);
        }
        public void EliminarProducto(int idp)
        {
            foreach (EProducto p in ListaPr)
            {
                if (p.Id == idp)
                {
                    ListaPr.Remove(p);
                }
            }
        }
        public EProducto BuscarProducto(int idp)
        {
            foreach (EProducto p in ListaPr)
            {
                if (p.Id.Equals(idp))
                {
                    return p;
                }
            }
            return null;
        }
        public void EditarProducto(int id, string nombre, decimal pcompra, decimal pventa, int stock, EProveedor proveedor)
        {
            foreach (EProducto p in ListaPr)
            {
                if (p.Id == id)
                {
                    p.Nombre = nombre;
                    p.Precio_compra = pcompra;
                    p.Precio_venta = pventa;
                    p.Stock = stock;
                    p.Proveedor = proveedor;

                }
            }

        }
    }
}
