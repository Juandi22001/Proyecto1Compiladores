using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class ErroresTokens
    {

        private String Lexema;
        private int IdToken;
        private int linea;
        private int columna;
        private string descripcion;
        private int fila;
        private int indice;

        public ErroresTokens(String Lexema, int idToken, int fila, int columna,string Descripcion)


        {
            this.descripcion = Descripcion;
            this.Lexema = Lexema;
            this.IdToken = idToken;
            this.columna = columna;
            this.fila = fila;
        }

        public ErroresTokens(string lexema, string descripcion, int columna, int fila)
        {
            Lexema = lexema;
            this.descripcion = descripcion;
            this.columna = columna;
            this.fila = fila;
        }

        public String getLexema()
        {
            return this.Lexema;
        }

        public String getDescripcion()
        {
            return this.descripcion;
        }


        public int getIdToken()
        {
            return this.IdToken;
        }
        public int getColumna()
        {
            return this.columna;

        }
        public int getFila()
        {
            return this.fila;

        }
    }
}
