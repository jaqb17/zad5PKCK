
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("rym_rating", Namespace = "http://www.example.org/types")]
    public class RymRating
    {
        [XmlText]
        public string Value { get; set; }
    }
}