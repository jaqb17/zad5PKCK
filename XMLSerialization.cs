using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace _5
{
   public class XMLSerialization
    {
        XmlSerializer serializer { get; set; }

        public FileInfo xmlFile { get; set; }
        public FileInfo schemaFile { get; set; }

        public XMLSerialization(string xmlFileName, string schemaFileName)
        {
            xmlFile = new FileInfo(xmlFileName);
            schemaFile = new FileInfo(schemaFileName);
            serializer = new XmlSerializer(typeof(Albumchart));
        }

        public void Serialize(Albumchart albumchart)
        {
            if(xmlFile.Exists)
            {
                xmlFile.Delete();
            }

            FileStream stream = new FileStream(xmlFile.FullName, FileMode.Create);
            serializer.Serialize(stream, albumchart);
            stream.Close();
        }

        public Albumchart Deserialize()
        {
            Albumchart albumchart = null;
            if(xmlFile.Exists)
            {
                using (StreamReader reader = new StreamReader(xmlFile.FullName))
                {
                    albumchart = (Albumchart)serializer.Deserialize(reader);
                }
            }
            else
            {
                throw new IOException();
            }
            return albumchart;
        }

        public bool CheckSchema(Albumchart albumchart)
        {
            SaveCopy(albumchart);

            XmlSchemaSet schemas = new XmlSchemaSet();

            schemas.Add("http://www.example.org/types", schemaFile.FullName);
            XDocument doc = XDocument.Load("copy.xml");
            string msg = "";
            doc.Validate(schemas, (o, e) => {
                msg += e.Message + Environment.NewLine;
            });
            Console.WriteLine(msg == "" ? "Dokument jest poprawny." : "Dokument jest niepoprawny: " + msg);
            if (msg == "")
                return true;
            else
                return false;

        }

        public void SaveCopy(Albumchart albumchart)
        {
            FileInfo tmp = new FileInfo("copy.xml");

            if(tmp.Exists)
            {
                tmp.Delete();
            }

            Stream stream = new FileStream(tmp.FullName, FileMode.Create);
            serializer.Serialize(stream, albumchart);
            stream.Close();
        }
    }
}
