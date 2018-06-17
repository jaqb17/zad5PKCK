using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("album_rating", Namespace = "http://www.example.org/types")]
    public class AlbumRating
    {
        [XmlElement("rym_rating", Namespace = "http://www.example.org/types")]
        public RymRating rymRating { get; set; }

        [XmlElement("metacritic_rating", Namespace = "http://www.example.org/types")]
        public MetacriticRating metacriticRating { get; set; }
    }
}
