using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.Core
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider serviceProvider;

        public ViewModelFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel
        {
            using var serviceScope = serviceProvider.CreateScope();
            var viewModel = serviceScope.ServiceProvider.GetService(typeof(TViewModel));
            return viewModel != null ? (TViewModel)viewModel : throw new ArgumentNullException(nameof(viewModel));
        }

        public TViewModel CreateViewModel<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            using var serviceScope = serviceProvider.CreateScope();
            var viewModel = ActivatorUtilities.CreateInstance(serviceScope.ServiceProvider, typeof(TViewModel), new object[] { parameter });
            return viewModel != null ? (TViewModel)viewModel : throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
