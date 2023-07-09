using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Licoreria_Entidades
{
    public class EListaRecibo
    {
        ArrayList ListaR = new ArrayList();

        public EListaRecibo(ArrayList listaR)
        {
            ListaR = listaR;
        }

        public void AgregarRecibo(ERecibo r)
        {
            ListaR.Add(r);
        }
        public void EliminarRecibo(int idr)
        {
            foreach (ERecibo r in ListaR)
            {
                if (r.Id == idr)
                {
                    ListaR.Remove(r);
                }
            }
        }
        public ERecibo BuscarRecibo(int idr)
        {
            foreach (ERecibo r in ListaR)
            {
                if (r.Id.Equals(idr))
                {
                    return r;
                }
            }
            return null;
        }
        public void EditarRecibo(int id, DateTime fecha, EVenta venta)
        {
            foreach (ERecibo r in ListaR)
            {
                if (r.Id == id)
                {
                    r.Fecha = fecha;
                    r.Venta = venta;
                }
            }

        }
    }
}
