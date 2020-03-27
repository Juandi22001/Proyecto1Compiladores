using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class Nodo
    {

        public enum TipoNodo
        {
            CerraduraP,
            Concatenacion, 
            OR,
            CerraduraI,
            CerraduraA,
            Terminal,


        }

        TipoNodo TipoN;
        string Descripcion;// transicion 

        public Nodo()
        {

        }
        public Nodo(string Descripcion, TipoNodo Tipo)
        {
            this.Descripcion = Descripcion;
            this.TipoN = Tipo;
                
        }
        public string getDescripcion()
        {
            return this.Descripcion;
        }
        public TipoNodo getT()
        {
            return this.TipoN;
        }
        public string getTipo()
        {
            switch (TipoN)
            {
                case TipoNodo.CerraduraP:
               return "cerradura +";
                case TipoNodo.Concatenacion:
                    return "concatenación .";
                case TipoNodo.OR:
                    return "OR |";
                case TipoNodo.CerraduraI:
                    return "Cerradura ?";
                case TipoNodo.CerraduraA:
                    return "Cerradura *";
                case TipoNodo.Terminal:
                    return "TERMINAL";
                default:
                    return "Desconocido";
            }

        }




    }
}
