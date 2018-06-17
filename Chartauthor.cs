using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("chartauthor", Namespace = "http://www.example.org/types")]

    public class Chartauthor
    {
        [XmlElement("author", Namespace = "http://www.example.org/types")]
        public List<Author> authors { get; set; }
    }
}
