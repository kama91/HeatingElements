using System.Drawing;
using HeatingElements.Common;
using HeatingElements.HeatingViews;
using HeatingElements.Models;
using HeatingElements.Models.Interfaces;

namespace HeatingElements.Presenters
{
    public class HeatingPanelPresenter : PresenterBase<HeatingPanel, HeatingPanelView>
    {

        public PointF Location
        {
            get => Model.Location;
            set
            {
                Model.Location = value;
                OnPropertyChanged();
            }
        }

        public double Temperature => Model.Temperature;

        public bool IsAlarm => Model.IsInAlarm;

        public IHeatingLamp IsEntryAutomateOnLamp => Model.IsEntryAutomateOnLamp;

        public IHeatingLamp IsNetworkOnLamp => Model.IsNetworkOnLamp;

        public IHeatingLamp IsPowerOnLamp => Model.IsPowerOnLamp;

        public IHeatingLamp IsOnUpsLamp => Model.IsOnUpsLamp;


        public HeatingPanelPresenter(HeatingPanel model) : base(model)
        {
            View = new HeatingPanelView(this);
        }
    }
}
