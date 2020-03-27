using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Proyecto1Compi201807335
{
    class ReporteTokens
    {

        XmlDocument doc;
        string rutaXml;

        public void _crearXml(string ruta, string nodoRaiz)
        {

            this.rutaXml = ruta;
            doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

            XmlNode root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);


            XmlNode element1 = doc.CreateElement(nodoRaiz);
            doc.AppendChild(element1);
            doc.Save(ruta);
         }

        public void _Añadir(string id)
        {
            doc.Load(rutaXml);

            XmlNode empleado = _Crear_Token(id);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(empleado, nodoRaiz.LastChild);

            doc.Save(rutaXml);


        }

        private XmlNode _Crear_Token(string id)
        {

            XmlNode empleado = doc.CreateElement("Token");


            XmlElement xid = doc.CreateElement("Lexema");
            xid.InnerText = id;
            empleado.AppendChild(xid);


            return empleado;
        }
    }
}
 
