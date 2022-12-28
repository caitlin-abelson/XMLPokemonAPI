using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace TEST
{
    public class XMLAPI2
    {
        string filepath = "C:\\Users\\cabelson\\PokemonXML.xml";

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

        public void postPokemon(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            FileStream fileStream = new FileStream(filepath, FileMode.Open);
            xmlDocument.Load(fileStream);
            XmlElement xmlElementNodeOne = xmlDocument.CreateElement("Trainer");
            xmlElementNodeOne.SetAttribute("Name", "Red");
            XmlElement xmlElementNodeTwo = xmlDocument.CreateElement("Pokeman");
            XmlText natext = xmlDocument.CreateTextNode("Geodude,Ground");
            //Appending the text to the second node {Pokeman.AppendChild("Geodude")}
            xmlElementNodeTwo.AppendChild(natext);
            //Appending the first node to the second node {Trainer.AppendChild("Pokeman")}
            xmlElementNodeOne.AppendChild(xmlElementNodeTwo);
            //Appending the first node to the parent {Pokemon.AppendChild(Trainer)}
            xmlDocument.DocumentElement.AppendChild(xmlElementNodeOne);
            fileStream.Close();
            xmlDocument.Save(filepath);
        }
    }
}
