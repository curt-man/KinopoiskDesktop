﻿using KinopoiskDesktop.App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.Services.IService
{
    public interface INavigationService 
    {
        BaseViewModel CurrentView { get; }
        void NavigateTo<T>() where T : BaseViewModel;
        void NavigateTo<T>(object parameter) where T : BaseViewModel;
        void NavigateTo(BaseViewModel viewModel);
    }
}
