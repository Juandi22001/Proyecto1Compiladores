using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class Asterisco
    {
        private ListaThomson hijounico;

        public Asterisco(ListaThomson hijounico)
        {
            this.hijounico = hijounico;

        }

        public ListaThomson Unir()
        { NodoThomson vacio = new NodoThomson("epsilon");
            NodoThomson Iniciovacio = new NodoThomson("epsilon");

            ListaThomson Pila = new ListaThomson();
            NodoThomson Finalvacio = new NodoThomson("epsilon");
            if (hijounico.GetTipo()== "unica")
            {


                Iniciovacio.sig1 = hijounico.GetInicio();
            hijounico.GetFinal().sig1 = vacio;
            vacio.sig2 = hijounico.GetInicio();
            vacio.sig1 = Finalvacio;
            Iniciovacio.sig2 = Finalvacio;
                Pila.setTipo("doble");
            Pila.setInicio(Iniciovacio);
            Pila.setTFinal(Finalvacio);
                }
            else if (hijounico.GetTipo()=="doble")
            {
                Iniciovacio.sig1 = hijounico.GetInicio();
                hijounico.GetFinal().sig2 = hijounico.GetInicio();
             hijounico.GetFinal().sig1 = vacio;
     
               Iniciovacio.sig2 = vacio;
                Pila.setInicio(Iniciovacio);
                Pila.setTFinal(vacio);
            }
            else if (hijounico.GetInicio().GetTranscision() == "or")
            {
                Iniciovacio.sig1 = hijounico.GetInicio();

                Iniciovacio.sig2 = Finalvacio;
                hijounico.GetInicio().sig2 = Finalvacio;
                hijounico.GetFinal().sig1 = Finalvacio;

                hijounico.GetFinal().sig2 = hijounico.GetInicio();

                Pila.setInicio(Iniciovacio);
                Pila.setTFinal(Finalvacio);

            }
            return Pila;
        }
    }
}
