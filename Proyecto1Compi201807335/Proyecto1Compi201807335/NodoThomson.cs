using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class NodoThomson
    {
        private string tipo;
        public  NodoThomson sig1;
        public NodoThomson sig2;
        private string Transicion;
        private int Estado;
        public static int cont = 0;
   
        public NodoThomson()
        {
            cont++;
            this.Estado = cont;
            this.tipo = " ";
        }
        public NodoThomson(string t)
        {
            this.tipo = " ";
            this.Transicion = t;
            cont++;
            this.Estado = cont;

        }
        // 2 nodos uno inicio or , fin or 
        // inicio.sig1 = listaParametro.getInicio(); 
        /// <summary>
        /// / listaParametro.getUltimo = finOr
        /// public clasJuanDiego( lista e1 , lista e2 , "OR"){ construirOr( );}

        public NodoThomson(string tra,  string Tipo )
        {
            this.Transicion = tra;
            this.tipo = Tipo;
            cont++;
            this.Estado = cont;

        }

        public int GetEstado()
        {
            return Estado;

        }
        public string GetTranscision()
        {
            return Transicion;

        }
        public string GetTipo()
        {
            return tipo;

        }
        public void SetEstado(int Estado)
        {
            this.Estado = Estado;
        }
        public void SetTrans(string Transicion)
        {
            this.Transicion=Transicion;
        }
        public void SetTipo(string Tipo)
        {
            this.tipo=Tipo;
        }
         
    }
  
}
