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
        private readonly IServiceProvider _serviceProvider;

        public ViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel
        {
            return ActivatorUtilities.CreateInstance<TViewModel>(_serviceProvider);
        }

        public TViewModel CreateViewModel<TViewModel>(object? parameter) where TViewModel : BaseViewModel
        {
            return ActivatorUtilities.CreateInstance<TViewModel>(_serviceProvider, parameter);
        }
    }

}
