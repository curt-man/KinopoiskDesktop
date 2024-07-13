
namespace KinopoiskDesktop.App.Core
{
    public interface IViewModelFactory
    {
        public T CreateViewModel<T>() where T : BaseViewModel;

        public T CreateViewModel<T>(object parameter) where T : BaseViewModel;

    }
}