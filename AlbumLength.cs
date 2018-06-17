using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("album_lenght", Namespace = "http://www.example.org/types")]
    public class AlbumLength
    {
        [XmlAttribute("units")]
        public string Units { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
