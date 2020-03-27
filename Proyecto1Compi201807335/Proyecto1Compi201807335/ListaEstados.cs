using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class ListaEstados
    {
        LinkedList<NodoThomson> a = new LinkedList<NodoThomson> ();
        int Estado;
        public static int cont = 0;
       NodoThomson L = new NodoThomson();
        public ListaEstados( )
        {
            cont++;
            this.Estado = cont;

        }
     
        public ListaEstados( LinkedList<NodoThomson > a )
        {
            this.a = a;
            cont++;
            this.Estado = cont;
        }



        public LinkedList<NodoThomson> GetLista()
        {
            return a;

        }
        public int GetEstado()
        {
            return Estado;

        }

    }
    class ListaTransiciones {
        string Trans;
        public ListaTransiciones()
        {



        }

        public ListaTransiciones(string Trans)
        {
            this.Trans = Trans;


        }

    }

}
