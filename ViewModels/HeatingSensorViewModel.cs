using System.Drawing;
using HeatingElements.Common.Extensions;
using HeatingElements.HeatingViews;
using HeatingElements.Models;
using HeatingElements.ViewModels.Base;

namespace HeatingElements.ViewModels
{
    public class HeatingSensorViewModel : HeatingViewModelBase<HeatingSensor, HeatingSensorView>
    {
        public Color StateColor => Model.State.ToColor();
        
        public double Temperature => Model.Temperature;

        public PointF Location
        {
            get => Model.Location;
            set
            {
                Model.Location = value;
                OnPropertyChanged();
            }
        }

        public HeatingSensorViewModel(HeatingSensor model) : base(model)
        {
            View = new HeatingSensorView(this);
        }
    }
}
