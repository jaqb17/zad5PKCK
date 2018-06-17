using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _5
{
    [XmlRoot("chart", Namespace = "http://www.example.org/types")]
    public class Chart
    {
        [XmlElement("album", Namespace = "http://www.example.org/types")]
        public ObservableCollection<Album> albums { set; get; }
    }
}
