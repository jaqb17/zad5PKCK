using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("author", Namespace = "http://www.example.org/types")]
    public class Author
    {
        [XmlText]
        public string Value { get; set; }
    }
}
