using System.ComponentModel;
using System.Drawing;

namespace HeatingElements.Models.Interfaces
{
    public interface IHeatingLamp : INotifyPropertyChanged
    {
        int State { get; set; }

        PointF Location { get; }
    }
}
