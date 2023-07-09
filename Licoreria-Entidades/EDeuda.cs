using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class EDeuda
    {
        private int id;
        private static int contador;
        private string prenda;
        private DateTime fecha;
        private int cantidad;
        private EEstado estado;
        private ECliente cliente;

        public EDeuda(string prenda, DateTime fecha, int cantidad, string e, ECliente cliente)
        {
            contador++;
            id = contador;
            this.prenda = prenda;
            this.fecha = fecha;
            this.cantidad = cantidad;
            if (e == "Activo" || e == "activo")
            {
                this.estado = EEstado.Activo;
            }
            else { this.estado = EEstado.Inactivo; }

            this.cliente = cliente;
        }

        public int Id { get => id; }
        public string Prenda { get => prenda; set => prenda = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        internal EEstado Estado { get => estado; set => estado = value; }
        public ECliente Cliente { get => cliente; set => cliente = value; }
    }
}
