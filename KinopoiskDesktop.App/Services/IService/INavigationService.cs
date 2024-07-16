using KinopoiskDesktop.App.Core;

namespace KinopoiskDesktop.App.Services.IService
{
    /// <summary>
    /// Serbice for navigation between views
    /// </summary>
    public interface INavigationService 
    {
        BaseViewModel CurrentView { get; }
        void NavigateTo<T>() where T : BaseViewModel;
        void NavigateTo<T>(object parameter) where T : BaseViewModel;
        void NavigateTo(BaseViewModel viewModel);
    }
}
