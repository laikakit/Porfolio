using System;
using System.IO;
using System.Xml.Serialization;

namespace CashRegister
{
    public class DataSerializer
    {
        public DataSerializer()
        {
        }
        public void Serialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Sales));
            if (File.Exists(filePath)) File.Delete(filePath);
            TextWriter writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, this);
            writer.Close();
        }
        public object Deserialize(Type datatType, string filePath)
        {
            object obj = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Sales));
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            return obj;
        }
    }
}
