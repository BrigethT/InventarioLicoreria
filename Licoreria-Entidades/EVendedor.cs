using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licoreria_Entidades
{
    public class EVendedor
    {
        private int id;
        private static int contador;
        private string nombre;

        public EVendedor(int vid, string vnombre)
        {
            this.id = vid;
            this.nombre = vnombre;
        }
        public EVendedor(string nombre)
        {
            contador++;
            id = contador;
            this.nombre = nombre;
        }
        public int Id { get => id; }
        public string Nombre { get => nombre; set => nombre = value; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
