using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("artist", Namespace = "http://www.example.org/types")]
    public class Artist
    {
        [XmlAttribute("artist_id")]
        public string artistID { get; set; }

        [XmlText]
        public string Value { set; get; }

    }
}
