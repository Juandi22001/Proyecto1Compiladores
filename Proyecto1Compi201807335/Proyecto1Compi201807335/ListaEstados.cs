using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class ListaEstados
    {
     public   LinkedList<NodoThomson> a = new LinkedList<NodoThomson>();
        LinkedList<ListaEstados> b = new LinkedList<ListaEstados>();

        ListaEstados ESTADOS;
        int Estado;
        public static int cont = 0;

        string Transicion;
    
     
        public ListaEstados( LinkedList<NodoThomson > a )
        {
            this.Estado = cont;
            cont++;
         
            this.a = a;
           
            
        }
        public ListaEstados(ListaEstados L, string Transicion)
         {
            this.Transicion = Transicion;
           this.ESTADOS=L;
            this.Estado = L.GetEstado();

        
        }



        public LinkedList<NodoThomson> GetListaCerradura()
        {
            return a;

        }
        public LinkedList<ListaEstados> GetListaEstados()
        {
            return b;

        }
        public void SetEstado(LinkedList<ListaEstados> L)
        {
            this.b = L;
        }
        public int GetEstado()
        {
            return Estado;

        }
        public string GetTransicion()
        {
            return Transicion;

        }
        public void SetEstado(string A)
        {
            this.Transicion = A;
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
