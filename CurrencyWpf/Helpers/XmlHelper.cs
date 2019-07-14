using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyWpf.Helpers
{
    public static class XmlHelper
    {
        public static TModel DeserialiseXml<TModel>(XmlNode xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TModel));
            using (var sr = new StringReader(xml.OuterXml))
            {
                return (TModel)serializer.Deserialize(sr);
            }
        }
    }
}
