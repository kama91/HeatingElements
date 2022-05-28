using System.ComponentModel;

namespace HeatingElements.Common
{
    public interface IPresenter<out TM, out TV> : INotifyPropertyChanged
    {
        TM Model { get; }

        TV View { get; }
    }
}
