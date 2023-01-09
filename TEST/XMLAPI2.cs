using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TEST.Models;

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

        public void postPokemon(PokemonModel pokemonModel, Trainer trainer)
        {
            XmlDocument xmlDocument = new XmlDocument();
            FileStream fileStream = new FileStream(filepath, FileMode.Open);
            xmlDocument.Load(fileStream);
            XmlElement xmlElementNodeOne = xmlDocument.CreateElement("Trainer");
            xmlElementNodeOne.SetAttribute(trainer.Name, trainer.Age.ToString());
            XmlElement xmlElementNodeTwo = xmlDocument.CreateElement("Pokeman");
            string pokemon = pokemonModel.Name + "," + pokemonModel.Type;
            XmlText natext = xmlDocument.CreateTextNode(pokemon);
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
