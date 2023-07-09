using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class EPago
    {
        private int id;
        private static int contador;
        private double cantidadTransferencia;
        private double cantidadEfectivo;


        public EPago(double cantidadTransferencia, double cantidadEfectivo)
        {
            contador++;
            id = contador;
            this.cantidadTransferencia = cantidadTransferencia;
            this.cantidadEfectivo = cantidadEfectivo;
        }
        public int Id { get => id; }
        public double CantidadTransferencia { get => cantidadTransferencia; set => cantidadTransferencia = value; }
        public double CantidadEfectivo { get => cantidadEfectivo; set => cantidadEfectivo = value; }
    }
}
