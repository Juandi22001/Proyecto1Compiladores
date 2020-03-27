using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1Compi201807335
{
    class Tokens
    {
        public enum Tipo


        {
            IdConj,
            ComillasSimples,
            LLaveAbierta,
            LlaveCerrada,
            Digito,
            Letra,
            ComentarioDeLinea,
            Comentario,
            Concatenacion,
            OR,
            Interroga,
            Asterisco,
            Mas,
            DosPuntos,
            Conjunto,
            PuntoyComa,
            Id,

            Comillas,
            Flecha,
            Coma,
            Vocales,
            Otras,
            Abecedario,
            Operaciones,
            Expresion,
            Punto,
            FinComentario,
            ConjuntoT,
            Intervalo,
            Diferente,
            Numeral,
            Dollar,
            Porcentaje,
            Y,
            ParentesisAbierto,
            ParentesisCerrado,
            Division,
            PuntoYComa,
            Mayor,
            Igual,
            Menor,
            Arroba,
            BarraInvertida,
            CorcheteAbierto,
            CorcheteCerrado,
            Elevado,
            Guio,
            Tilde
                

        }
        public Tipo tipo;

        string Lexema;
        int fila;
        int columna;
        int IdToken;

        public Tokens(string Lexema,int columna,int fila,int IdToken,Tipo tipo)
          
            {    
                this.Lexema = Lexema;
                this.columna = columna;
                this.fila = fila;
                this.tipo = tipo;
            this.IdToken = IdToken;    
            }

            public int getIdToken()
        {
            return this.IdToken;
        }
        public String getLexema()
        {
            return this.Lexema;
        }
        public int geTfila()
        {
            return this.fila;
        }
        public int getcolumna()
        {
            return this.columna;
        }
        public string GetTipo()

        {

            switch (tipo)
            {
                case Tipo.Arroba:
                    return "Simbolo @";


                case Tipo.Asterisco:
                    return "Cerradura *";

                case Tipo.BarraInvertida:
                    return "Token Barra Invertida ";

                case Tipo.Coma:
                    return "Simbolo ,";

                case Tipo.Comentario:
                    return "Comentario MultiLinea";

                case Tipo.ComentarioDeLinea:
                    return "Comentario De una Linea";

                case Tipo.Comillas:
                    return "Comillas";

                case Tipo.ComillasSimples:
                    return "Comillas Simples";

                case Tipo.Concatenacion:
                    return "Concatenacion .";

                case Tipo.Conjunto:
                    return "Palabra Reservada Conjunto ";

                case Tipo.CorcheteAbierto:
                    return "Token [";

                case Tipo.CorcheteCerrado:
                    return "Token ]";

                case Tipo.Diferente:
                    return "Token !";

                case Tipo.Digito:
                    return " Digitos 324234213";

                case Tipo.Division:
                    return "Token /";

                case Tipo.Dollar:
                    return "Token $";

                case Tipo.DosPuntos:
                    return "Token :";

                case Tipo.Elevado:
                    return "Token ^";

                case Tipo.FinComentario:
                    return "!>";
                case Tipo.Flecha:
                    return "->";
                case Tipo.Guio:
                    return "Token _";
                case Tipo.Id:
                    return "Token ID";
                case Tipo.Igual:
                    return "Token =";
                case Tipo.Interroga:
                    return "Cerradura ?";
          
                case Tipo.Letra:
                    return "Letra";
                case Tipo.LLaveAbierta:
                    return "Token {";
                case Tipo.LlaveCerrada:
                    return "Token }";
                case Tipo.Mas:
                    return "Cerradura  +";
                case Tipo.Mayor:
                    return "Token >";
                case Tipo.Menor:
                    return "Token <";
                case Tipo.Numeral:
                    return "Token #";
                case Tipo.OR:
                    return "OR |";
                case Tipo.ParentesisAbierto:
                    return "Token (";
                case Tipo.ParentesisCerrado:
                    return "Token )";
                case Tipo.Porcentaje:
                    return "Token %";
                case Tipo.PuntoYComa:
                    return "Token ;";
                case Tipo.Tilde:
                    return "Token ´ ";
                case Tipo.Y:
                    return "&";

                case Tipo.Expresion:
                    return "Palabra Reservada Expresion";

                case Tipo.Intervalo:
                     return " Conjunto ~";
                case Tipo.IdConj:
                    return " idConjunto";

                default:
                    return "Desconocido";
             }
        }

            }
        }
