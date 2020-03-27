using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1Compi201807335
{
    class OR
    {
         private ListaThomson aux1;
        private ListaThomson aux2;
        
        public OR (ListaThomson A1, ListaThomson A2)
        {
            this.aux1 = A1;
            this.aux2 = A2;


        }
        public OR(ListaThomson A1)
        {
            this.aux1 = A1;
         


        }
        public ListaThomson UnionI()
        {
            ListaThomson Pila = new ListaThomson();

            NodoThomson Iniciovacio = new NodoThomson("epsilon","or");
            NodoThomson Finalvacio = new NodoThomson("epsilon","fin_or");

            NodoThomson vacio3 = new NodoThomson("epsilon");
            NodoThomson vacio2 = new NodoThomson("epsilon");
            NodoThomson vacio = new NodoThomson("epsilon");

            if (aux1.GetTipo() == "unica" )
            {
                Iniciovacio.sig1 = aux1.GetInicio();
                Iniciovacio.sig2 = vacio3;

                aux1.GetFinal().sig1 = vacio;
                vacio3.sig1 = vacio2;
                vacio.sig1 = Finalvacio;
                vacio2.sig1 = Finalvacio;

            }
            else if (aux1.GetTipo() == "doble")
            {
                Iniciovacio.sig1 = aux1.GetInicio();
                Iniciovacio.sig2 = vacio3;

                aux1.GetFinal().sig1 = Finalvacio;
                vacio3.sig1 = vacio2;
                vacio2.sig1 = Finalvacio;


            }

            Pila.setInicio(Iniciovacio);
            Pila.setTFinal(Finalvacio);
            return Pila;
        }
        public ListaThomson Union()
        {
            ListaThomson Pila = new ListaThomson();

            NodoThomson Iniciovacio = new NodoThomson("epsilon","or");
            NodoThomson Finalvacio = new NodoThomson("epsilon", "fin_or");

            NodoThomson vacio2 = new NodoThomson("epsilon");
            NodoThomson vacio = new NodoThomson("epsilon");
            if (aux1.GetTipo()=="unica" && aux2.GetTipo() == "unica")
            {

                MessageBox.Show("si"+aux1.GetTipo()+aux2.GetTipo());

                Iniciovacio.sig1 = aux1.GetInicio();
   

                Iniciovacio.sig2 = aux2.GetInicio();
            aux1.GetFinal().sig1 = vacio;
            aux2.GetFinal().sig1 = vacio2;
            vacio.sig1 = Finalvacio;
            vacio2.sig1 = Finalvacio;
            Pila.setTipo("doble");
   
            }
            else if (aux1.GetTipo() == "doble" && aux2.GetTipo()=="doble")
            {
                MessageBox.Show("si es doble");
                Iniciovacio.sig1 = aux1.GetInicio();
                Iniciovacio.sig2 = aux2.GetInicio();
                aux1.GetFinal().sig1 = Finalvacio;
                aux2.GetFinal().sig1 = Finalvacio;
                Pila.setTipo("doble");

            }

            else if (aux1.GetTipo() == "doble" && aux2.GetTipo() == "unica")
            {
                MessageBox.Show("unica  y doble");
                Iniciovacio.sig1 = aux1.GetInicio();
                Iniciovacio.sig2 = aux2.GetInicio();
                aux1.GetFinal().sig1 = Finalvacio;
                aux2.GetFinal().sig1 = vacio2;
                vacio.sig1 = Finalvacio;
                Pila.setTipo("doble");

            }
            else if (aux1.GetTipo() == "unica" && aux2.GetTipo() == "doble")
            {
                MessageBox.Show("unica  y doble");
                Iniciovacio.sig1 = aux1.GetInicio();
                Iniciovacio.sig2 = aux2.GetInicio();
                aux1.GetFinal().sig1 = Finalvacio;
                aux2.GetFinal().sig1 = vacio2;
                vacio2.sig1 = Finalvacio;
                Pila.setTipo("doble");

            }
            else if (aux1.GetInicio().GetTranscision() == "or")
            {
                aux1.GetInicio().sig2 = Finalvacio;
                aux1.GetFinal().sig1 = Finalvacio;

                aux1.GetFinal().sig2 = aux1.GetInicio();

                Pila.setInicio(aux1.GetInicio());
                Pila.setTFinal(Finalvacio);
                Pila.setTipo("doble");
            }

            Pila.setInicio(Iniciovacio);

            Pila.setTFinal(Finalvacio);
       

            return Pila;
        }
    }
}

