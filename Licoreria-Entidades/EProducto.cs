using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class EProducto
    {
        private int id;
        private static int contador;
        private string nombre;
        private decimal precio_compra;
        private decimal precio_venta;
        private int stock;
        private EProveedor proveedor;

        public EProducto(string nombre, decimal precio_compra, decimal precio_venta, int stock, EProveedor proveedor)
        {
            contador++;
            id = contador;
            this.nombre = nombre;
            this.precio_compra = precio_compra;
            this.precio_venta = precio_venta;
            this.stock = stock;
            this.proveedor = proveedor;
        }
        public int Id { get => id; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio_compra { get => precio_compra; set => precio_compra = value; }
        public decimal Precio_venta { get => precio_venta; set => precio_venta = value; }
        public int Stock { get => stock; set => stock = value; }
        public EProveedor Proveedor { get => proveedor; set => proveedor = value; }
    }
}
