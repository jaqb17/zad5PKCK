using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("genres", Namespace = "http://www.example.org/types")]
    public class Genres
    {
        [XmlElement("genre", Namespace = "http://www.example.org/types")]
        public List<Genre> genresList { get; set; }
    }
}
