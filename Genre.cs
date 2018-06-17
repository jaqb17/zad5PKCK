using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("genre", Namespace = "http://www.example.org/types")]
    public class Genre
    {
        [XmlAttribute("genre_id")]
        public string genreID { get; set; }

        [XmlText]
        public string Value { set; get; }
    }
}
