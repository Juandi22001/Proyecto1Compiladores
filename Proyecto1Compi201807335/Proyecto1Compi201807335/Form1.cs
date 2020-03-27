using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Proyecto1Compi201807335
{
    public partial class Form1 : Form
    {    
        ListaThomson Li = new ListaThomson();
        int E = 0;
        ReporteTokens XXml = new ReporteTokens();
        ArrayList PestañasCreadas = new ArrayList(); int Contador1 = 0;
        string[] textos = new string[200];
        string[] textos2 = new string[200];
        int Estado = 0;
        Char c;
        String contadorLexico;
        LinkedList<Tokens> TokensA = new LinkedList<Tokens>();
        LinkedList<ListaThomson> PilaT = new LinkedList<ListaThomson>();
        LinkedList<Nodo> Thomson = new LinkedList<Nodo>();
        LinkedList<ErroresTokens> ErTokens = new LinkedList<ErroresTokens>();
        public int columna = 0;
        public String Expresion = "er";
        public String operaciones = "operaciones";
        public String CONJ = "CONJ";

        public int fila = 0;
        public int idtoken = 0;

        public Form1()
        {


            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Juan Diego Alvarado Salguero  No. CARNE 201807335" + "Compildores 1 ", " Información del Estudiante ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TabPage Nueva = new TabPage("Pestaña " + Contador1);
            PestañasCreadas.Add(Nueva);

            RichTextBox txt1 = new RichTextBox();

            txt1.Dock = DockStyle.Fill;
            Nueva.Controls.Add(txt1);
            tabControl1.TabPages.Add(Nueva);
            Contador1++;
            tabControl1.SelectedTab = Nueva;
            for (int i = 0; i < textos2.Length; i++)
            {
                textos2[i] = "prueba";
            }
        }
        public void Menu()
        {
            
            for (int i = Thomson.Count()-1; i >=0; i--)
            {
                Nodo aux = Thomson.ElementAt(i);


                if (aux.getT() == Nodo.TipoNodo.Terminal)
                {
                    NodoThomson nuevo = new NodoThomson(aux.getDescripcion()); // ya guarda la transicion 
                    ListaThomson li = new ListaThomson(nuevo);
                    li.setTipo("unica");
                    PilaT.AddLast(li);

                }

                else if (aux.getT() == Nodo.TipoNodo.CerraduraA )
                {   ListaThomson aux1 = new ListaThomson();
                    aux1 = PilaT.Last();
                    PilaT.RemoveLast();
                    Asterisco A = new Asterisco(aux1);
                    ListaThomson R=  A.Unir();
                    PilaT.AddLast(R);
                }
                else if (aux.getT() == Nodo.TipoNodo.CerraduraI)
                {
                    ListaThomson aux1 = new ListaThomson();
                    aux1 = PilaT.Last();
                    PilaT.RemoveLast();
                   OR A = new OR(aux1);
                    ListaThomson R = A.UnionI();
                    PilaT.AddLast(R);
                }

                else if (aux.getT() == Nodo.TipoNodo.Concatenacion)
                { // . ab 
                    // sacar los 2 de la cima
                    // meter la lista resultante a la pila y cambiar el tipo 

                    ListaThomson aux1= new ListaThomson();
                    ListaThomson aux2 = new ListaThomson();
                    ListaThomson R= new ListaThomson();
                    aux1 = PilaT.Last();
                    PilaT.RemoveLast();
                    aux2 = PilaT.Last();
                    PilaT.RemoveLast();
                    Punto_Concatenacion concatena = new Punto_Concatenacion(aux1, aux2);
                   ListaThomson resultado =   concatena.junta();
                    PilaT.AddLast(resultado);
                    // lo meto a la pila 

                }
                else if (aux.getT() == Nodo.TipoNodo.OR)
                {
                    ListaThomson aux1 = new ListaThomson();
                    ListaThomson aux2 = new ListaThomson();
                    ListaThomson R = new ListaThomson();
                    aux1 = PilaT.Last();
                    PilaT.RemoveLast();
                    aux2 = PilaT.Last();
                    PilaT.RemoveLast();
                  OR or = new OR(aux1, aux2);

                    R = or.Union();
                   PilaT.AddLast(R);
                }
                else if (aux.getT() == Nodo.TipoNodo.CerraduraP)
                {
                    ListaThomson aux1 = new ListaThomson();
                    ListaThomson aux2 = new ListaThomson();
                    ListaThomson R = new ListaThomson();
                    aux1 = PilaT.Last();
                    PilaT.RemoveLast();
                 

                  Mas mas = new Mas(aux1);
                    R = mas.Union();

                    PilaT.AddLast(R);
                }
                else if (aux.getT() == Nodo.TipoNodo.CerraduraI)
                {
                    ListaThomson aux1 = new ListaThomson();
                    ListaThomson aux2 = new ListaThomson();
                    ListaThomson R = new ListaThomson();
                    aux1 = PilaT.Last();
                    PilaT.RemoveLast();


                    Mas mas = new Mas(aux1);
                    R = mas.Union();

                    PilaT.AddLast(R);
                }

            }



            }

             
        
        public void Leer(string direccion)
        {
            try
            {
                tabControl1.SelectedTab.Controls.Clear();

                tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;

                StreamReader reader = new StreamReader(direccion, Encoding.Default);


                String S = reader.ReadToEnd();
                tabControl1.SelectedTab.Controls.Add(new RichTextBox
                {

                    Text = S,
                    Dock = DockStyle.Fill,
                    Visible = true,
                    ScrollBars = RichTextBoxScrollBars.ForcedBoth,




                }); textos[tabControl1.SelectedIndex] = S;



                reader.Close();
            }


            catch (Exception)
            {
                MessageBox.Show(
                    "ERROR ", "Carga de Archivos Errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);







            }
        }
        public void abrir()
        {
            try
            {



                openFileDialog1.Title = "Archivos para analizar ";
                openFileDialog1.ShowDialog();
                if (File.Exists(openFileDialog1.FileName))
                    Leer(openFileDialog1.FileName);
                textBox1.Text = openFileDialog1.FileName;
                tabControl1.SelectedTab.Text = openFileDialog1.Title;

                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                       "El archivo no se pudo abrir  ", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
        }
        
       
        private void Scan(String E)
        {

            ErTokens = new LinkedList<ErroresTokens>
                ();
            Estado = 0;
            TokensA = new LinkedList<Tokens>();
            Thomson = new LinkedList<Nodo>();
            contadorLexico = "";
            Char c;

            for (int i = 0; i <= E.Length - 1; i++)
            {

                c = E.ElementAt(i);

                switch (Estado)
                {
                   

                    case 0:

                        if (Char.IsLetter(c))
                        {
                            contadorLexico += c;
                            columna++;

                            Estado = 1;
                        }
                        else if (Char.IsDigit(c))
                        {
                            contadorLexico += c;
                            columna++;

                            Estado = 2;

                        }

                        else if (c == ('\u0022'))
                        {

                            columna++;
                            Estado = 3;

                        }

                        else if (Char.IsWhiteSpace(c))
                        {
                            columna++;

                        }
                        else if (c.Equals('\n'))
                        {
                            fila++;
                            MessageBox.Show("salto");
                            columna = 0;
                       
                        }
                        else if (c.Equals('\t'))

                        {
                            columna++;
                        }

                        else if (c == '-')
                        {
                            contadorLexico += c;
                            columna++;

                            Estado = 9;
                        }
                        else if (c == '%')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 3;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Porcentaje);
                        }
                        else if (c == '_')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 4;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Guio);
                        }
                        else if (c == '$')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 5;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Dollar);
                        }

                        else if (c == '!')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 6;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Diferente);
                        }
                        else if (c == '#')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 7;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Numeral);
                        }
                        else if (c == '&')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 8;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Y);
                        }

                        else if (c == '(')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 9;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.ParentesisAbierto);
                        }
                        else if (c == '|')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 9;
                            AgregarNodo(contadorLexico,Nodo.TipoNodo.OR);

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.OR);

                        }
                        else if (c == ')')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 10;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.ParentesisCerrado);
                        }
                        else if ((c == (Char)39))
                        {

                            columna++;

                            Estado = 4;

                        }

                        else if (c == '+')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 11;
                            AgregarNodo(contadorLexico, Nodo.TipoNodo.CerraduraP);

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Mas);
                        }


                        else if (c == '.')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 12;
                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Concatenacion);

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Concatenacion);
                        }
                        else if (c == '/')
                        {
                            columna++;
                            Estado = 5;


                        }

                        else if (c == ':')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 14;

                            AgregarToken2(contadorLexico, columna, fila, idtoken, Tokens.Tipo.DosPuntos);
                            Estado = 1;
                        }
                        else if (c == ';')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 15;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.PuntoYComa);
                        }
                        else if (c == '<')
                        {

                            columna++;
                            Estado = 7;
                        }
                        else if (c == '=')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 16;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Igual);
                        }
                        else if (c == '?')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 16;
                            AgregarNodo(contadorLexico, Nodo.TipoNodo.CerraduraI);

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Interroga);
                        }
                        else if (c == '@')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 17;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Arroba);
                        }
                        else if (c == '^')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 18;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Elevado);
                        }
                        else if (c == '*')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 19;
                            AgregarNodo(contadorLexico, Nodo.TipoNodo.CerraduraA);

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Asterisco);
                        }

                        else if (c == '%')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 20;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Porcentaje);
                        }

                        else if (c == '{')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 23;

                            AgregarToken2(contadorLexico, columna, fila, idtoken, Tokens.Tipo.LLaveAbierta);
                            Estado = 1;

                        }

                        else if (c == '}')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 25;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.LlaveCerrada);
                        }

                        else if (c == ',')
                        {
                            contadorLexico += c;
                            columna++;

                            idtoken = 29;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Coma);
                        }
                        else if (c == '~')
                        {

                            contadorLexico += c;
                            columna++;

                            idtoken = 29;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.ConjuntoT);


                        }
                        else
                        {
                            contadorLexico += c;
                            ErToken(contadorLexico, "Simbolo no reconocido por el sistema", columna, fila);

                        }
                        break;
                    case 1:


                        if (Char.IsLetter(c))
                        {
                            Estado = 1;
                            contadorLexico += c;

                            columna++;
                        }
                        else if (c == '~')
                        {

                            contadorLexico += c;

                            Estado = 10;

                        }
                        else if (Expresion.ToLower().Equals(contadorLexico.ToLower()))
                        {

               
                            if (Char.IsDigit(c))
                            {

                        
                                contadorLexico += c;
                                idtoken = 20;
                                AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Expresion);
                                i--;
                            }
                            else
                            {
                                contadorLexico += c;
                                ErToken(contadorLexico, "se esperaba digito", columna, fila);

                            }



                        }
                        else if (operaciones.Equals(contadorLexico.ToLower()))
                        {
              

                            contadorLexico += c;
                            idtoken = 22;
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Operaciones);
                            i--;
                        }


                        


                        else if (CONJ.ToLower().Equals(contadorLexico.ToLower()))
                        {
                            contadorLexico += c;
                     

                            idtoken = 21;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Conjunto);
                            i--;

                        }

                        else if (c == '}')
                        {
                            AgregarToken3(c.ToString(), columna, fila, idtoken, Tokens.Tipo.LlaveCerrada);

                            columna++;

                            idtoken = 26;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);


                            Estado = 0;
                            contadorLexico = "";
                        }
                        else if (c == ' ')
                        {
                           

                   

                            idtoken = 29;

                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Terminal);
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);

                            Estado = 0;
                            contadorLexico = "";
                        }
                        else if (c == ',')
                        {
                            columna++;

                            idtoken = 29;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);
                        }
                        else if (c == '+')
                        {
                            AgregarToken3(c.ToString(), columna, fila, idtoken, Tokens.Tipo.Mas);
                            AgregarNodo(c.ToString(), Nodo.TipoNodo.CerraduraP);
                            columna++;

                            idtoken = 29;

                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Terminal);
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);
                        }
                        else if (c == '|')
                        {
                            AgregarToken3(c.ToString(), columna, fila, idtoken, Tokens.Tipo.OR);
                            AgregarNodo(c.ToString(), Nodo.TipoNodo.OR);
                        
                        columna++;

                            idtoken = 29;
                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Terminal);
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);
                        }
                        else if (c == '*')
                        {
                            AgregarToken3(c.ToString(), columna, fila, idtoken, Tokens.Tipo.Asterisco);
                            AgregarNodo(c.ToString(), Nodo.TipoNodo.CerraduraA);


                            idtoken = 29;

                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Terminal);
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);
                        }
                        else if (c == '.')
                        {
                            AgregarToken3(c.ToString(), columna, fila, idtoken, Tokens.Tipo.Punto);
                            AgregarNodo(c.ToString(), Nodo.TipoNodo.Concatenacion);
          

                            idtoken = 29;

                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Terminal);
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);
                        }
                        else if (c == '?')
                        {
                            AgregarToken3(c.ToString(), columna, fila, idtoken, Tokens.Tipo.Interroga);
                            AgregarNodo(c.ToString(), Nodo.TipoNodo.CerraduraI);
                

                            idtoken = 29;

                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Terminal);
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Id);
                        }
                     

                        else
                        {

                            contadorLexico += c;
                            ErToken(contadorLexico, "no van letras aca", columna, fila);

                        }
                        break;

                    case 2:




                        if (char.IsDigit(c))
                        {

                            contadorLexico += c;



                            Estado = 2;

                        }



                        else
                        {
                            idtoken = 27;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Digito);
                            i--;




                        }
                        break;


                    case 3:

                        if ((c == ('\u0022')) && contadorLexico.Length >= 1)
                        {


                            idtoken = 28;
                            AgregarNodo(contadorLexico, Nodo.TipoNodo.Terminal);
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Comillas);
                            contadorLexico = "";
                            Estado = 0;




                        }
                        else
                        {
                            contadorLexico += c;
                            columna++;
                            Estado = 3;
                        }


                        break;


                    case 4:
                        if ((c == (Char)39) && contadorLexico.Length > 1)

                        {


                            idtoken = 29;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.ComillasSimples);

                        }
                        else
                        {
                       
                            contadorLexico += c;

                        }
                        break;
                    case 5:
                        if (c == '/')
                        {

            
                            Estado = 6;
                        }
                        else
                        {

                            MessageBox.Show("error");

                        }
                        break;

                    case 6:

                        if (c == '\n')
                        {
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.ComentarioDeLinea);


                        }
                        else
                        {

                            contadorLexico += c;

                            Estado = 6;
                            columna++;
                        }
                        break;

                    case 7:

                        if (c == '!')
                        {
                            Estado = 8;
                        }
                        else
                        {
                            ErToken("!", "falto terminal !", columna, fila);


                        }


                        break;
                    case 8:
                        if (c == '!')
                        {
                            Estado = 8;

                        }

                        else if (c == '>')

                        {
                            MessageBox.Show("si");
                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Comentario);

                        }
                        else
                        {
                            contadorLexico += c;
                            columna++;
                            Estado = 8;
                        }
                        break;


                    case 9:
                        if (c == '>')
                        {
                        


                            idtoken = 30;

                            AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.Flecha);
                            Estado = 0;
                            contadorLexico = "";
                        }
                        break;

                    case 10:
                        if (Char.IsLetter(c))
                        {

                            contadorLexico += c;
                        AgregarToken(contadorLexico, columna, fila, idtoken, Tokens.Tipo.ConjuntoT);
                        }
                        break;
                }
            }   XML(TokensA);
            ErrorXML(ErTokens);
        }

        private void XML(LinkedList<Tokens> TtTokenes)

        {
            SaveFileDialog GuardarXML = new SaveFileDialog();
            GuardarXML.Filter = "XML|*.xml";
            if (GuardarXML.ShowDialog() == DialogResult.OK)
            {  
                string direccion = GuardarXML.FileName;
                StreamWriter pagina = new StreamWriter(direccion);

                String codigoHtml = "<Lista de Tokens>" + "\n";
                foreach (Tokens T in TokensA)
                {
                     
                
                    codigoHtml+="<Token>" + "\n" +
                    "<Nombre>" + "<" + T.getLexema()+">" + "<Nombre/>"+ "\n"+
                        "<Valor>" + "<" + T.GetTipo() + ">" + "<Valor/>" + "\n" +
                        "<Columna>" + "<" + T.getcolumna() + ">" + "<columna/>" + "\n" +
                        "<fila>" + "<" + T.geTfila() + ">" + "<fila/>" + "\n" 
                             + "Token/>" + "\n" + "\n" + "\n" 


                         ;
                }

                pagina.Write(codigoHtml);
                pagina.Close();


            }

        }
        private void ErrorXML(LinkedList<ErroresTokens> TtTokenes)

        {
            SaveFileDialog GuardarXML = new SaveFileDialog();
            GuardarXML.Filter = "XML|*.xml";
            if (GuardarXML.ShowDialog() == DialogResult.OK)
            {
                string direccion = GuardarXML.FileName;
                StreamWriter pagina = new StreamWriter(direccion);

                String codigoHtml = "<Lista de Tokens>" + "\n";
                foreach (ErroresTokens T in ErTokens)
                {


                    codigoHtml += "<ErroresToken>" + "\n" +
                    "<Nombre>" + "<" + T.getLexema() + ">" + "<Nombre/>" + "\n" +
                        "<Descripcion>" + "<" + T.getDescripcion() + ">" + "<Descripcion/>" + "\n" +
                        "<Columna>" + "<" + T.getColumna() + ">" + "<columna/>" + "\n" +
                        "<fila>" + "<" + T.getFila() + ">" + "<fila/>" + "\n"
                             + "Token/>" + "\n" + "\n" + "\n"


                         ;
                }

                pagina.Write(codigoHtml);
                pagina.Close();


            }

        }
        private void AgregarNodo(string Descripcion, Nodo.TipoNodo Tipo)
        {
            Thomson.AddLast(new Nodo(Descripcion,Tipo));
        }

        private void AgregarToken(string Lexema, int columna, int fila, int IdToken, Tokens.Tipo tipo)
        {
            TokensA.AddLast(new Tokens(Lexema, columna, fila, IdToken, tipo));
            contadorLexico = "";
            Estado = 0;
        }
        private void AgregarToken2(string Lexema, int columna, int fila, int IdToken, Tokens.Tipo tipo)
        {
            TokensA.AddLast(new Tokens(Lexema, columna, fila, IdToken, tipo));
            contadorLexico = "";
        }
        private void AgregarToken3(string Lexema, int columna, int fila, int IdToken, Tokens.Tipo tipo)
        {
            TokensA.AddLast(new Tokens(Lexema, columna, fila, IdToken, tipo));

        }

        private void ErToken(string Lexema, String Descripcion, int columna, int fila)
        {
            ErTokens.AddLast(new ErroresTokens(Lexema, Descripcion, columna, fila));
            contadorLexico = "";
            Estado = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        


            string Entrada = textos[tabControl1.SelectedIndex];
            
            Scan(Entrada);
          foreach (var Nodo in Thomson)
            {




                Console.WriteLine(Nodo.getDescripcion()+"---"+Nodo.getTipo()+ '\n');
            }  /*  
            foreach (var Token in TokensA)
            {




                Console.WriteLine(Token.getLexema() + "____" + Token.GetTipo() + '\n');
            }*/
    
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Menu();


            
        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < textos2.Length; i++)
            {

                Console.WriteLine(textos2[i]);

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        { // vaciar la pila sino se chinga 
            // tener una lista para los AFN los cuales son de tipo lsitathomson 
         PilaT.ElementAt(0).imprimir();
            
         ListaThomson.lista_lineal_nodos = PilaT.ElementAt(0).llenaListaLineal();

            Console.WriteLine(PilaT.ElementAt(0).getGraphviz());


            graficador gr = new graficador();
            gr.graficar(PilaT.ElementAt(0).getGraphviz());
        }
    }
    class graficador
    {
        String ruta;
        StringBuilder grafica;
        public graficador()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }
        private void generarDot(String rdot, String rpng)
        {
            File.WriteAllText(rdot, grafica.ToString());
            String comandoDot = " dot -Tpng \"" + rdot + "\" -o \"" + rpng + "\"";
            var comando = String.Format(comandoDot);
            var procesoStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var procedimiento = new System.Diagnostics.Process();
            procedimiento.StartInfo = procesoStart;
            procedimiento.Start();
            procedimiento.WaitForExit();

        }

        public void graficar(String texto)
        {

            grafica = new StringBuilder();
            String rdot = ruta + "\\imagen.dot";
            String rpng = ruta + "\\imagen.png ";
            grafica.Append(texto);
            this.generarDot(rdot, rpng);

        }



    }


}
