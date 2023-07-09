using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Licoreria_Entidades
{
    public class EListaCliente
    {
        ArrayList ListaC = new ArrayList();

        public EListaCliente(ArrayList listaC)
        {
            ListaC = listaC;
        }

        public void AgregarCliente(ECliente c)
        {
            ListaC.Add(c);
        }
        public void EliminarCliente(int idc)
        {
            foreach (ECliente cliente in ListaC)
            {
                if (cliente.Id == idc)
                {
                    ListaC.Remove(idc);
                }
            }
        }
        public ECliente BuscarCliente(int idc)
        {
            foreach (ECliente c in ListaC)
            {
                if (c.Id.Equals(idc))
                {
                    return c;
                }
            }
            return null;
        }
        public void EditarCliente(int id, string nombre, string direccion, string cedula, string telefono)
        {
            foreach (ECliente c in ListaC)
            {
                if (c.Id == id)
                {
                    c.Nombre = nombre;
                    c.Direccion = direccion;
                    c.Cedula = cedula;
                    c.Telefono = telefono;
                }
            }

        }
    }
}
