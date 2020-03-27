using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class ListaThomson
    {
        public static LinkedList<ListaThomson> a;
        private NodoThomson Fin;
        private NodoThomson Inicio;
        private string tipo;


        public static LinkedList<string> lista_terminal = new LinkedList<string>();

        public static LinkedList<NodoThomson> lista_mov = new LinkedList<NodoThomson>();
        public static LinkedList<ListaEstados> ESTADOS = new LinkedList<ListaEstados>();
        public static LinkedList<NodoThomson> lista_transiciones = new LinkedList<NodoThomson>();
        public static LinkedList<NodoThomson> lista_auxestados = new LinkedList<NodoThomson>();
        public static LinkedList<NodoThomson> lista_ceradura = new LinkedList<NodoThomson>();
        public static LinkedList<NodoThomson> lista_lineal_nodos = new LinkedList<NodoThomson>();
        // tipo = 0  lista simple 
        // tipo = 1 listaCompuesta 
        // tipo = 2 Lista OR pura 

        public ListaThomson()
        {
            NodoThomson Fin = null;
            NodoThomson Inicio = null;

        }
        public ListaThomson(NodoThomson nuevo)
        {
            this.Fin = nuevo;
            this.Inicio = nuevo;
            this.tipo = "unica";
        }
        // new NodoTHomson("transicion", id) ;
        public void crearTerminales(NodoThomson nuevo)
        {
            this.Fin = nuevo;
            this.Inicio = nuevo;
            this.tipo = "unica";
        }
        public ListaThomson(ListaThomson e1, string tipo)
        {


        }
        public void imprimir()
        {

            int x = 1;
            NodoThomson aux = this.Inicio;


            while (aux != null)
            {
                Console.Write("siuuuu");



                if (aux.GetTipo().CompareTo("or") == 0)
                {// necesito imprimir por debajo
                    Console.WriteLine(x + "." + " ID: " + aux.GetEstado() + " nombrePuntero:" + aux.GetTranscision());
                    if (aux.sig2 != null)
                    {
                        Console.Write("ESTE NODO TIENE 2 PUNTEROS.-.-.-.-.--.-.-.-.-.-.-.-.-.-.-.");
                        imprimirPorDebajo(aux.sig2);
                    }
                }
                Console.WriteLine(x + "." + " ID: " + aux.GetEstado() + " nombrePuntero:" + aux.GetTranscision());
                x++;
                aux = aux.sig1;
            }
            Console.WriteLine("********");
            Console.WriteLine();
        }
        public void imprimirPorDebajo(NodoThomson aux)
        {
            while (aux.sig1.GetTipo().CompareTo("fin_or") != 0)
            {
                if (aux.GetTipo().CompareTo("or") == 0)
                {
                    Console.WriteLine("OR_ANIADO" + " ID: " + aux.GetEstado() + " nombrePuntero:" + aux.GetTranscision());
                    if (aux.sig2 != null)
                    {

                        // imprimirPorDebajo(aux.sig2);
                    }
                }
                Console.WriteLine("-->" + " ID: " + aux.GetEstado() + " nombrePuntero:" + aux.GetTranscision());
                aux = aux.sig1;
            }
        }


        public void AgregarTerminal(ListaThomson aux1, ListaThomson aux2, string Tipo)
        {
            ListaThomson L = new ListaThomson();

        }

        public void AgregarDeUltimo()
        {
            NodoThomson NodoT = new NodoThomson();
            if (Inicio == null)
            {
                NodoT = Inicio;
                Inicio = Fin;
            }
            else
            {
                Fin.sig1 = NodoT;
                NodoT = Fin;
            }


        }
        public NodoThomson GetInicio()
        {
            return Inicio;

        }
        public string GetTipo()
        {
            return tipo;

        }
        public NodoThomson GetFinal()
        {
            return Fin;

        }

        public void setInicio(NodoThomson Inicio) //  XY   
        {
            this.Inicio = Inicio;

        }
        public void setTFinal(NodoThomson Final) //  XY   
        {
            this.Fin = Final;

        }
        public void setTipo(string t) //  XY   
        {
            this.tipo = t;

        }
        //FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
        public static bool repetido(int id)
        {
            foreach (NodoThomson nodo in lista_lineal_nodos)
            {
                if (id == nodo.GetEstado())
                {
                    return true;
                }
            }
            return false;
        }
        public LinkedList<NodoThomson> llenaListaLineal()
        {
            lista_lineal_nodos = new LinkedList<NodoThomson>();
            NodoThomson aux = this.Inicio;
            while (aux != null)
            {
                if (repetido(aux.GetEstado()) != true)
                {
                    lista_lineal_nodos.AddLast(aux);
                }

                if (aux.GetTipo().CompareTo("or") == 0)
                {// tengo otra lista hacia otro lado 
                    if (aux.sig2 != null && repetido(aux.sig2.GetEstado()) != true)
                    {
                        llenaListaLineal(aux.sig2);
                    }
                }
                aux = aux.sig1;
            }


            return lista_lineal_nodos;
        }

        public void llenaListaLineal(NodoThomson aux) // sobrecarga de metodo 
        {
            while (aux != null)
            {
                if (repetido(aux.GetEstado()) != true)
                {
                    lista_lineal_nodos.AddLast(aux);
                }

                if (aux.GetTipo().CompareTo("or") == 0)
                {// tengo otra lista hacia otro lado 
                    if (aux.sig2 != null && repetido(aux.sig2.GetEstado()) != true)
                    {
                        llenaListaLineal(aux.sig2);
                    }
                }
                aux = aux.sig1;
            }

        }
        public string getGraphviz()
        {
            CompararE();
            LLenar();
            string ju = "digraph G {" + "\n";


            ju += " rankdir = LR;  node[color = blue]";
            foreach (NodoThomson alv in lista_lineal_nodos)
            {
                if (alv.sig1 != null)
                {
                    ju += "E" + alv.GetEstado() + "->" + "E" + alv.sig1.GetEstado() + "[label=\"" + alv.GetTranscision() + "\"]" + "\n";


                }
                if (alv.sig2 != null)
                {
                    ju += "E" + alv.GetEstado() + "->" + "E" + alv.sig2.GetEstado() + "[label=\"" + alv.GetTranscision() + "\"]" + "\n";
                }
            }
            ju += "\n" + "}";
            return ju;
        }

        public void LLenar()
        {

            foreach (string alv in lista_terminal)
            {

                Console.WriteLine(alv);


            }


        }
        public static bool repetido2(string e)
        {
            foreach (string nodo in lista_terminal)
            {
                if (e.Equals(nodo))
                {
                    return true;
                }
            }
            return false;
        }
        public void CompararE()
        {
            Console.WriteLine("siuu");
            foreach (NodoThomson alv in lista_lineal_nodos)
            {

                //s
                if (alv.sig1 != null)
                {
                    if (repetido2(alv.GetTranscision()) != true && !alv.GetTranscision().Equals("epsilon"))
                    {
                        lista_terminal.AddLast(alv.GetTranscision());

                    }


                }



                if (alv.sig2 != null)
                {

                    if (repetido2(alv.GetTranscision()) != false && !alv.GetTranscision().Equals("epsilon"))
                    {
                        lista_terminal.AddLast(alv.GetTranscision());
                    }
                }


            }
        }

        public void RecursivoCerr(NodoThomson n, string trans)
        {
            lista_ceradura.AddLast(n);


            if (n.sig1 != null)
            {
                if (n.GetTranscision().Equals(trans))
                {

                    RecursivoCerr(n.sig1, trans);
                }


            }
            if (n.sig2 != null)
            {

                if (n.GetTranscision().Equals(trans))
                {
                    RecursivoCerr(n.sig2, trans);
                }


            }


        }

        public void RecursivoMov(NodoThomson N, string Trans)
        {

            foreach (NodoThomson alv in lista_ceradura)
            {
                if (alv.sig1 != null)
                {
                    if (alv.GetTranscision().Equals(Trans))
                    {
                        lista_mov.AddLast(alv.sig1);
                        RecursivoMov(N.sig1, Trans);

                    }

                }
                if (alv.sig2 != null)
                {

                    if (alv.GetTranscision().Equals(Trans))
                    {
                        lista_mov.AddLast(alv.sig2);

                        RecursivoMov(N.sig2, Trans);
                    }
                }
            }
        }
        public void RecursivoE()
        {

            foreach (NodoThomson alv in lista_mov)


            {
                if (alv.sig1 != null)
                {
                    RecursivoCerr(alv.sig1, alv.GetTranscision());

                }
                if (alv.sig2 != null)
                {

                    RecursivoCerr(alv.sig2, alv.GetTranscision());

                }
            }

        }
        public bool repetido3(LinkedList<ListaEstados> L)
        {
            if (ESTADOS.Count == L.Count)
            {

                return CompararListas(ESTADOS, L);

            }
            else {
                return false;
            }
        }

        public  bool CompararListas (LinkedList<ListaEstados> L , LinkedList<ListaEstados> L2)
        {
            bool aux = false;
            foreach (ListaEstados Aux1 in L)
            {
                foreach (ListaEstados AUX2 in L2)
                {
                    if (Aux1.GetEstado()==AUX2.GetEstado())
                    {
                        aux = true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return aux;
}
        public void Union()
        {


            ListaEstados L = new ListaEstados(lista_ceradura);

            RecursivoCerr(lista_lineal_nodos.First(), "epsilon");
            ESTADOS.AddLast(L);
            lista_ceradura = new LinkedList<NodoThomson>();

            foreach (NodoThomson alv in L.GetLista())
            {
                foreach (string alvTrans in lista_terminal)
                {
                    RecursivoMov(alv, alvTrans);
                    foreach (NodoThomson item in lista_mov)
                    {
                        RecursivoCerr(item, "epsilon");
                        foreach (ListaEstados AUX in ESTADOS)
                        {
                            

                        }
                    }
                }
           
            }
         

                


        }
    }

  
}




