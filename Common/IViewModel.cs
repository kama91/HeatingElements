using System.ComponentModel;

namespace HeatingElements.Common
{
    public interface IViewModel<T> : INotifyPropertyChanged
    {
       T Model { get; }  
    }
}
