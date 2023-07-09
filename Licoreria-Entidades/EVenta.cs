using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class EVenta
    {
        private int id;
        private static int contador;
        private ECliente cliente;
        private EVendedor vendedor;
        private double total;
        private EListaProducto detalle;
        private string observaciones;
        private EPago pago;

        public EVenta(ECliente cliente, EVendedor vendedor, double total, EListaProducto detalle, string observaciones, EPago pago)
        {
            contador++;
            id = contador;
            this.cliente = cliente;
            this.vendedor = vendedor;
            this.total = total;
            this.detalle = detalle;
            this.observaciones = observaciones;
            this.pago = pago;
        }

        public int Id { get => id; }
        public ECliente Cliente { get => cliente; set => cliente = value; }
        public EVendedor Vendedor { get => vendedor; set => vendedor = value; }
        public double Total { get => total; set => total = value; }
        public EListaProducto Detalle { get => detalle; set => detalle = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public EPago Pago { get => pago; set => pago = value; }
    }
}
