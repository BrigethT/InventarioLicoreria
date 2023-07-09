using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class EProveedor
    {
        private int id;
        private static int contador;
        private string nombre;
        private string telefono;
        private string ruc;

        public EProveedor(string nombre, string telefono, string ruc)
        {
            contador++;
            id = contador;
            Nombre = nombre;
            Telefono = telefono;
            Ruc = ruc;
        }

        public int Id { get => id; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Ruc { get => ruc; set => ruc = value; }
    }
}
