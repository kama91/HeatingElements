using HeatingElements.Common;

namespace HeatingElements.ViewModels.Base
{
    public class HeatingViewModelBase<T, TVm> : ViewModelBase<T>
        where T : class
    {
        public TVm View { get; protected set; }

        public HeatingViewModelBase(T model) : base(model)
        {
        }
    }
}