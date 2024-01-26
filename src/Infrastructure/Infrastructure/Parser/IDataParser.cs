using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructure.Parser
{
    /*public abstract class Parser<T>
    {
        // JSON parse işlemi için abstract metot
        public abstract T ParseJson(string json);

        // XML parse işlemi için abstract metot
        public abstract T ParseXml(string xml);
    }

    // Concrete sınıf tanımı
    public class MyParser<T> : Parser<T> where T : class, new()
    {
        // JSON parse işlemi
        public override T ParseJson(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        // XML parse işlemi
        public override T ParseXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }*/
}
