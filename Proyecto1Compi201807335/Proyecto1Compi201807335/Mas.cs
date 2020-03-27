using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class Mas
    {


        private ListaThomson aux1 = new ListaThomson();
        private ListaThomson aux2 = new ListaThomson();


        public Mas( ListaThomson aux1 )
        {
            this.aux1 = aux1;
            

        }

        public ListaThomson Union()
        {
            ListaThomson Pila = new ListaThomson();
            NodoThomson vacio= new NodoThomson("epsilon");
            NodoThomson Iniciovacio = new NodoThomson("epsilon");
            NodoThomson Finalvacio = new NodoThomson("epsilon");

            if (aux1.GetTipo()=="unica" )
            {

                Iniciovacio.sig1 =aux1.GetInicio();
                aux1.GetFinal().sig1 = vacio;
                vacio.sig2 = aux1.GetInicio();
                vacio.sig1 = Finalvacio;

                Pila.setTipo("doble");
                Pila.setInicio(Iniciovacio);
                Pila.setTFinal(Finalvacio);
            }
            else if (aux1.GetTipo()=="doble")
            {
                Iniciovacio.sig1 = aux1.GetInicio();
                aux1.GetFinal().sig1 = Finalvacio;
            
           aux1.GetFinal().sig2 = aux1.GetInicio();

                Pila.setInicio(Iniciovacio);
                Pila.setTFinal(Finalvacio);

            }
            else if (aux1.GetInicio().GetTranscision()=="or" )
            {
                aux1.GetFinal().sig1 = Finalvacio;

                aux1.GetFinal().sig2 = aux1.GetInicio();

                Pila.setInicio(aux1.GetInicio());
                Pila.setTFinal(Finalvacio);

            }



            return Pila;
        }

        
    }
}
