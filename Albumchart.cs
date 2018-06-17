using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("albumchart", Namespace = "http://www.example.org/types")]
    public class Albumchart
    {
        [XmlElement("chartauthor", Namespace = "http://www.example.org/types")]
        public Chartauthor chartauthor { get; set; }

        [XmlElement("artists", Namespace = "http://www.example.org/types")]
        public Artists artists { get; set; }

        [XmlElement("genres", Namespace = "http://www.example.org/types")]
        public Genres genres { set; get; }

        [XmlElement("chart", Namespace = "http://www.example.org/types")]
        public Chart chart { get; set; }

    }
}
