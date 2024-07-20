using KinopoiskDesktop.App.Core;

namespace KinopoiskDesktop.App.Services.IService
{
    /// <summary>
    /// Serbice for navigation between views
    /// </summary>
    public interface INavigationService 
    {
        ViewModelBase CurrentView { get; }
        void NavigateTo<T>() where T : ViewModelBase;
        void NavigateTo<T>(object parameter) where T : ViewModelBase;
        void NavigateTo(ViewModelBase viewModel);
    }
}
