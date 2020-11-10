using System;
using System.Xml.Serialization;
using HeatingElements.Common;
using HeatingElements.Models.Base;

namespace HeatingElements.Models
{
    [Serializable]
    public class HeatingLine : BaseNode
    {
        private State _state;

        [XmlAttribute("ParentId")] 
        public int ParentId { get; set; }

        [XmlAttribute("State")]
        public State State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        public HeatingLine()
        {
        }

        public override string ToString()
        {
            return ParentId + " " + State;
        }
    }
}