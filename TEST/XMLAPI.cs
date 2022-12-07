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

        public void postPokemon()
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

        public void getPokemon()
        {
            XmlDocument xmlDocument = new XmlDocument();
            FileStream readFile = new FileStream(filepath, FileMode.Open);
            xmlDocument.Load(readFile);
            String trainer;
            //Finding the first node by the tag name 
            XmlNodeList list = xmlDocument.GetElementsByTagName("Trainer");
            //Looping through the nodes by tag and then writing them out to the console
            for (int i = 0; i < list.Count; i++)
            {
                //Gets the outer most node
                XmlElement cl = (XmlElement)xmlDocument.GetElementsByTagName("Trainer")[i];
                Console.WriteLine(cl.OuterXml);
                //Gets the next node
                XmlElement add = (XmlElement)xmlDocument.GetElementsByTagName("Pokeman")[i];
                Console.WriteLine(add.OuterXml);
                //Once the inner most node has the attribute Name that equals Red, this if statement will be true,
                //then the inner text of last node node is added to the string variable
                /*
                 <Trainer Name="Red"><Pokeman>Geodude,Ground</Pokeman></Trainer>
                 <Pokeman>Geodude,Ground</Pokeman>
                 Geodude,Ground
                 */
                if ((cl.GetAttribute("Name")) == "Red")
                {
                    trainer = add.InnerText;
                    Console.WriteLine(trainer);
                    break;
                }
                
            }
            readFile.Close();
            //Console.ReadKey();
        }

        public void updatePokemon()
        {
            XmlDocument xmlDocument = new XmlDocument();
            FileStream up = new FileStream(filepath, FileMode.Open);
            xmlDocument.Load(up);
            XmlNodeList list = xmlDocument.GetElementsByTagName("Trainer");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement trainer = (XmlElement)xmlDocument.GetElementsByTagName("Trainer")[i];
                XmlElement add = (XmlElement)xmlDocument.GetElementsByTagName("Pokeman")[i];
                if (trainer.GetAttribute("Name") == "Red")
                {
                    trainer.SetAttribute("Name", "Blue");
                    add.InnerText = "Charmeleon,Fire";
                    break;
                }
            }
            up.Close();
            xmlDocument.Save(filepath);
        }


        public void deletePokemon()
        {
            FileStream readFile = new FileStream(filepath, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(readFile);
            XmlNodeList list = xmlDocument.GetElementsByTagName("Trainer");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xmlDocument.GetElementsByTagName("Trainer")[i];
                if (cl.GetAttribute("Name") == "Blue")
                {
                    xmlDocument.DocumentElement.RemoveChild(cl);
                }
            }
            readFile.Close();
            xmlDocument.Save(filepath);
        }
    }
}
