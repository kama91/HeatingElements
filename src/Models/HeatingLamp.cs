using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using HeatingElements.Annotations;
using HeatingElements.Models.Interfaces;

namespace HeatingElements.Models
{
    public class HeatingLamp : IHeatingLamp
    {
        private int _state;

        public int State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged();
                }
            }
        }

        public PointF Location { get; }

        public HeatingLamp(int state, PointF location)
        {
            State = state;
            Location = location;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
