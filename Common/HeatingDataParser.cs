using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using HeatingElements.Models;
using HeatingElements.Models.Base;

namespace HeatingElements.Common
{
    public static class HeatingDataParser
    {
        public static IReadOnlyCollection<BaseNode> GetParsedItemsFromFile(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var xmlReader = XmlReader.Create(fileName);
            var xmlSerializer = new XmlSerializer(typeof(DiagramNode));
            var diagramNode = (DiagramNode)xmlSerializer.Deserialize(xmlReader);

            var items = new List<BaseNode>();

            foreach (var element in diagramNode.Elements)
            {
                switch (element)
                {
                    case HeatingPanel heatingPanel:
                        items.Add(heatingPanel);
                        break;
                    case HeatingLine heatingLine:
                        items.Add(heatingLine);
                        break;
                    case HeatingSensor heatingSensor:
                        items.Add(heatingSensor);
                        break;
                }
            }

            return items;
        }
    }
}
