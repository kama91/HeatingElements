using System.ComponentModel;
using HeatingElements.Common;
using HeatingElements.Common.Extensions;
using HeatingElements.HeatingViews;
using HeatingElements.Models.Interfaces;

namespace HeatingElements.Presenters
{
    public class HeatingLampPresenter : PresenterBase<IHeatingLamp, HeatingLampView>
    {
        private int _state;

        public int State
        {
            get => _state;
            private set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged();
                    View.StateColor = _state.ToColor();
                }
            }
        }

        public HeatingLampPresenter(IHeatingLamp model) : base(model)
        {
            View = new HeatingLampView(this);
            Model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            State = Model.State;
        }
    }
}
