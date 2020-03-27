using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1Compi201807335
{
    class Punto_Concatenacion
    {
       private ListaThomson hijo1;
       private ListaThomson hijo2;
       
        public Punto_Concatenacion(ListaThomson H1 , ListaThomson H2)
        {// . a b
            this.hijo1 = H1;
            this.hijo2 = H2;
        }
        public  ListaThomson junta()
        {// .a-.    . = nodo     letras = transiciones  si me entendes eso ? 

            ListaThomson Pila = new ListaThomson();
            
            NodoThomson nulo = new NodoThomson("epsilon");
            hijo1.GetFinal().sig1 = hijo2.GetInicio();
            hijo2.GetFinal().sig1 = nulo;
            NodoThomson aux = hijo1.GetInicio(); 
           
            /*    // apuntaste una lista string cada vez que recorro la lista 
                //------a
                //------a 
                // a ---------b
              */
            Pila.setInicio(hijo1.GetInicio());
            Pila.setTFinal(nulo);
            Pila.setTipo("doble");
            MessageBox.Show(Pila.GetInicio().GetTranscision());

            return Pila;

        }



    }
}
