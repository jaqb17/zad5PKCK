using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("album_track_count", Namespace = "http://www.example.org/types")]
    public class AlbumTrackCount
    {
        [XmlText]
        public string Value { set; get; }
    }
}
