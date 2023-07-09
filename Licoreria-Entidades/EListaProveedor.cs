using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Licoreria_Entidades
{
    public class EListaProveedor
    {
        ArrayList ListaP = new ArrayList();

        public EListaProveedor(ArrayList listaP)
        {
            ListaP = listaP;
        }

        public void AgregarProveedor(EProveedor p)
        {
            ListaP.Add(p);
        }
        public void EliminarProveedor(int idp)
        {
            foreach (EProveedor p in ListaP)
            {
                if (p.Id == idp)
                {
                    ListaP.Remove(p);
                }
            }
        }
        public EProveedor BuscarProveedor(int idp)
        {
            foreach (EProveedor p in ListaP)
            {
                if (p.Id.Equals(idp))
                {
                    return p;
                }
            }
            return null;
        }
        public void EditarProveedor(int id, string nombre, string telefono, string ruc)
        {
            foreach (EProveedor p in ListaP)
            {
                if (p.Id == id)
                {
                    p.Nombre = nombre;
                    p.Telefono = telefono;
                    p.Ruc = ruc;
                }
            }

        }
    }
}
