using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class ECliente
    {
        private int id;
        private static int contador;
        private string nombre;
        private string direccion;
        private string cedula;
        private string telefono;

        public ECliente(string nombre, string direccion, string cedula, string telefono)
        {
            contador++;
            id = contador;
            this.nombre = nombre;
            this.direccion = direccion;
            this.cedula = cedula;
            this.telefono = telefono;
        }

        public int Id { get => id; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }

    }
}
