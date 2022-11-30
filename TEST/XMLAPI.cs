using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TEST
{
    public class XMLAPI
    {
        string filepath = "C:\\Users\\cabelson\\Pokemon.xml";

        public void makePokemonFile()
        {
            XmlTextWriter xmlTextWriter;
            xmlTextWriter = new XmlTextWriter(filepath, Encoding.UTF8);
            xmlTextWriter.WriteStartDocument();
            //The name of the file that we are writing to
            xmlTextWriter.WriteStartElement("Pokemon");
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.Close();
        }

        //Rename this later for better reference
        public void getPokemon()
        {
            XmlDocument xmlDocument = new XmlDocument();
            FileStream fileStream = new FileStream(filepath, FileMode.Open);
            xmlDocument.Load(fileStream);
            XmlElement xmlElementNodeOne = xmlDocument.CreateElement("Trainer");
            xmlElementNodeOne.SetAttribute("Name", "Red");
            XmlElement xmlElementNodeTwo = xmlDocument.CreateElement("Pokeman");
            XmlText natext = xmlDocument.CreateTextNode("Geodude,Ground");
            //Appending the text to the node
            xmlElementNodeTwo.AppendChild(natext);
            //Appending the first node to the second node
            xmlElementNodeOne.AppendChild(xmlElementNodeTwo);
            xmlDocument.DocumentElement.AppendChild(xmlElementNodeOne);
            fileStream.Close();
            xmlDocument.Save(filepath);
        }



    }
}
