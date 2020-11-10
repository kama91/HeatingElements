using System.ComponentModel;
using System.Drawing;
using HeatingElements.Common.Extensions;
using HeatingElements.HeatingViews;
using HeatingElements.Models;
using HeatingElements.ViewModels.Base;

namespace HeatingElements.ViewModels
{
    public class HeatingLineViewModel : HeatingViewModelBase<HeatingLine, HeatingLineView>
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

        public HeatingLineViewModel(HeatingLine heatingLine) : base(heatingLine)
        {
            View = new HeatingLineView(this);
            Model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Model.Temperature))
            {
                OnPropertyChanged(nameof(Temperature));
            }

            if (e.PropertyName == nameof(Model.State))
            {
                View.BackColor = Model.State.ToColor();
            }
        }
    }
}
