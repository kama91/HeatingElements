using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HeatingElements.Properties;

namespace HeatingElements.Common
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModelBase<T> : ViewModelBase, IViewModel<T>
        where T : class
    {
        public T Model { get; protected set; }

        public ViewModelBase(T model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
