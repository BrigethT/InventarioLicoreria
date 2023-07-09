using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Licoreria_Entidades
{
    public class EListaVendedor
    {
        ArrayList ListaV = new ArrayList();
        private ArrayList listaC;

        public EListaVendedor(ArrayList listaV)
        {
            ListaV = listaV;
        }
        public EListaVendedor()
        {
            listaC = new ArrayList();
        }
        public ArrayList getListaC()
        {
            return this.listaC;
        }

        public void setListac(ArrayList c)
        {

            this.listaC = c;
        }

        public void AgregarVendedor(EVendedor p)
        {
            ListaV.Add(p);
        }
        public void EliminarVendedor(int idv)
        {
            foreach (EVendedor v in ListaV)
            {
                if (v.Id == idv)
                {
                    ListaV.Remove(v);
                }
            }
        }
        public EVendedor BuscarVendedor(int idV)
        {
            foreach (EVendedor v in ListaV)
            {
                if (v.Id.Equals(idV))
                {
                    return v;
                }
            }
            return null;
        }
        public void EditarProveedor(int id, string nombre)
        {
            foreach (EVendedor v in ListaV)
            {
                if (v.Id.Equals(id))
                {
                    v.Nombre = nombre;
                }
            }

        }

        public bool devolver2(string a)
        {
            foreach (EVendedor v in listaC)
            {
                if (v.Nombre.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }
        public EVendedor delvolverVendedor(string a)
        {
            foreach (EVendedor v1 in listaC)
            {
                if (v1.Nombre.Equals(a))
                {
                    return v1;
                }
            }
            return null;
        }
    }
}
