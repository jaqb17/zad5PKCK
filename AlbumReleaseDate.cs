using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("album_release_date", Namespace = "http://www.example.org/types")]
    public class AlbumReleaseDate
    {
        [XmlText]
        public string Value { get; set; }
    }
}
