using System.Xml.Serialization;

namespace _5
{

    [XmlRoot("metacritic_rating", Namespace = "http://www.example.org/types")]
    public class MetacriticRating
    {
        [XmlText]
        public string Value { get; set; }
    }
}