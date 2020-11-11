using System.Drawing;
using HeatingElements.HeatingViews;
using HeatingElements.Models;
using HeatingElements.ViewModels.Base;

namespace HeatingElements.ViewModels
{
    public class HeatingPanelViewModel : HeatingViewModelBase<HeatingPanel, HeatingPanelView>
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

        public bool IsAlarm => Model.IsAlarm;

        public int IsEntryAutomateOn => Model.IsEntryAutomateOn;

        public int IsNetworkOn => Model.IsNetworkOn;

        public int IsPowerOn => Model.IsPowerOn;

        public int IsOnUps => Model.IsOnUps;

        public HeatingPanelViewModel(HeatingPanel model) : base(model)
        {
            View = new HeatingPanelView(this);
        }
    }
}
