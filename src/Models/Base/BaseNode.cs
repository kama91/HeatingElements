using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using HeatingElements.Common.Extensions;
using HeatingElements.Properties;

namespace HeatingElements.Models.Base
{
    [Serializable]
    public abstract class BaseNode : INotifyPropertyChanged
    {
        private string _name;
        private PointF _location;
        private double _temperature;

        [XmlAttribute("Id")]
        public int Id { get; }
        
        [XmlAttribute("Name")]
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlIgnore]
        public PointF Location
        {
            get => _location;
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlAttribute("Location")]
        public string LocationAsString
        {
            get => string.Join(";", Location.X, Location.Y);
            set
            {
                var tokens = value.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                if (float.TryParse(tokens.First(), out var x) && float.TryParse(tokens.Last(), out var y))
                {
                    Location = new PointF(x, y);
                }
            }
        }

        [XmlAttribute("Temperature")]
        public double Temperature
        {
            get => _temperature;
            set
            {
                if (!_temperature.DoubleEquals(value))
                {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }

        protected BaseNode()
        {
        }

        protected BaseNode(BaseNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            Id = node.Id;
            Name = node.Name;
            LocationAsString = node.LocationAsString;
            Temperature = node.Temperature;
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Location + " " + Temperature;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
