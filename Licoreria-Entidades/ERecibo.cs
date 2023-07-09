using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class ERecibo
    {
        private int id;
        private static int contador;
        private DateTime fecha;
        private EVenta venta;

        public ERecibo(DateTime fecha, EVenta venta)
        {
            contador++;
            id = contador;
            this.fecha = fecha;
            this.venta = venta;
        }

        public int Id { get => id; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public EVenta Venta { get => venta; set => venta = value; }
    }
}
