using System.Collections.Generic;
using System.Xml.Serialization;
using HeatingElements.Models.Base;

namespace HeatingElements.Models
{
    [XmlRoot("Diagram")]
    public class DiagramNode
    {
        public DiagramNode() => Elements = new List<BaseNode>();
        
        [XmlArrayItem(typeof(HeatingPanel), ElementName = "HeatingPanel")]
        [XmlArrayItem(typeof(HeatingLine), ElementName = "HeatingLine")]
        [XmlArrayItem(typeof(HeatingSensor), ElementName = "Sensor")]
        public List<BaseNode> Elements { get; set; }
    }
}
