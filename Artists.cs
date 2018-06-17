using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("artists", Namespace = "http://www.example.org/types")]
    public class Artists
    {
        [XmlElement("artist", Namespace = "http://www.example.org/types")]
        public List<Artist> artistList { get; set; }
    }
}
