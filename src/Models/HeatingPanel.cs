using System;
using System.Drawing;
using System.Xml.Serialization;
using HeatingElements.Models.Base;
using HeatingElements.Models.Interfaces;

namespace HeatingElements.Models
{
    [Serializable]
    public class HeatingPanel : BaseNode
    {
        private bool _isInAlarm;
        private int _isEntryAutomateOn;
        private int _isNetworkOn;
        private int _isPowerOn;
        private int _isOnUps;

        [XmlAttribute("IsInAlarm")]
        public bool IsInAlarm
        {
            get => _isInAlarm;
            set
            {
                if (_isInAlarm != value)
                {
                    _isInAlarm = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlAttribute("IsEntryAutomateOn")]
        public int IsEntryAutomateOn
        {
            get => _isEntryAutomateOn;
            set
            {
                if (_isEntryAutomateOn != value)
                {
                    _isEntryAutomateOn = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlAttribute("IsNetworkOn")]
        public int IsNetworkOn
        {
            get => _isNetworkOn;
            set
            {
                if (_isNetworkOn != value)
                {
                    _isNetworkOn = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlAttribute("IsPowerOn")]
        public int IsPowerOn
        {
            get => _isPowerOn;
            set
            {
                if (_isPowerOn != value)
                {
                    _isPowerOn = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlAttribute("IsOnUps")]
        public int IsOnUps
        {
            get => _isOnUps;
            set
            {
                if (_isOnUps != value)
                {
                    _isOnUps = value;
                    OnPropertyChanged();
                }
            }
        }

        [XmlIgnore]
        public IHeatingLamp IsOnUpsLamp { get; }

        [XmlIgnore]
        public IHeatingLamp IsPowerOnLamp { get; }

        [XmlIgnore]
        public IHeatingLamp IsNetworkOnLamp { get; }

        [XmlIgnore]
        public IHeatingLamp IsEntryAutomateOnLamp { get; }

        public HeatingPanel()
        {
            IsOnUpsLamp = new HeatingLamp(IsOnUps, new PointF(210F, 165F));
            IsPowerOnLamp = new HeatingLamp(IsPowerOn, new PointF(210F, 130F));
            IsNetworkOnLamp = new HeatingLamp(IsNetworkOn, new PointF(210F, 90F));
            IsEntryAutomateOnLamp = new HeatingLamp(IsEntryAutomateOn, new PointF(210F, 50F));
        }

        public override string ToString()
        {
            return IsInAlarm + " " + IsEntryAutomateOn + " " + IsNetworkOn + " " + IsPowerOn + " " + IsOnUps;
        }
    }
}