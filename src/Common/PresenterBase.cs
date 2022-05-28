using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HeatingElements.Properties;

namespace HeatingElements.Common
{
    public class PresenterBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PresenterBase<TM, TV> : PresenterBase, IPresenter<TM,TV>
        where TM : class
        where TV : class
    {
        public TM Model { get; protected set; }

        public TV View { get; protected set; }

        public PresenterBase(TM model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            // Для использования под DI достаточно раскомментировать и добавить параметр во все конструкторы
            //View = view ?? throw new ArgumentNullException(nameof(view));
        }
    }
}
