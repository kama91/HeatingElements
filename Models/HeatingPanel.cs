using System;
using System.Xml.Serialization;
using HeatingElements.Models.Base;

namespace HeatingElements.Models
{
    [Serializable]
    public class HeatingPanel : BaseNode
    {
        private bool _isAlarm;
        private int _isEntryAutomateOn;
        private int _isNetworkOn;
        private int _isPowerOn;
        private int _isOnUps;

        [XmlAttribute("IsInAlarm")]
        public bool IsAlarm
        {
            get => _isAlarm;
            set
            {
                _isAlarm = value;
                OnPropertyChanged();
            }
        }

        [XmlAttribute("IsEntryAutomateOn")]
        public int IsEntryAutomateOn
        {
            get => _isEntryAutomateOn;
            set
            {
                _isEntryAutomateOn = value;
                OnPropertyChanged();
            }
        }

        [XmlAttribute("IsNetworkOn")]
        public int IsNetworkOn
        {
            get => _isNetworkOn;
            set
            {
                _isNetworkOn = value;
                OnPropertyChanged();
            }
        }

        [XmlAttribute("IsPowerOn")]
        public int IsPowerOn
        {
            get => _isPowerOn;
            set
            {
                _isPowerOn = value;
                OnPropertyChanged();
            }
        }

        [XmlAttribute("IsOnUps")]
        public int IsOnUps
        {
            get => _isOnUps;
            set
            {
                _isOnUps = value;
                OnPropertyChanged();
            }
        }

        public HeatingPanel()
        {
        }

        public override string ToString()
        {
            return IsAlarm + " " + IsEntryAutomateOn + " " + IsNetworkOn + " " + IsPowerOn + " " + IsOnUps;
        }
    }
}