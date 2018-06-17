using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("type", Namespace = "http://www.example.org/types")]
    public class Type
    {
        [XmlIgnore]
        public string Value { get; set; }

        [XmlAttribute("genre_id")]
        public string Genre { set; get; }
    }
}
