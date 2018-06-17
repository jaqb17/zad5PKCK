using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("album_name", Namespace = "http://www.example.org/types")]
   public class AlbumName
    {
        [XmlText]
        public string Value { get; set; }
    }
}
