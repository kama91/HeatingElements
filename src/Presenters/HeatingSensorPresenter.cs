using System.Drawing;
using HeatingElements.Common;
using HeatingElements.Common.Extensions;
using HeatingElements.HeatingViews;
using HeatingElements.Models;

namespace HeatingElements.Presenters
{
    public class HeatingSensorPresenter : PresenterBase<HeatingSensor, HeatingSensorView>
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

        public HeatingSensorPresenter(HeatingSensor model) : base(model)
        {
            View = new HeatingSensorView(this);
        }
    }
}
