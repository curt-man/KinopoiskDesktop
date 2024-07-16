using KinopoiskDesktop.App.Extensions;
using KinopoiskDesktop.App.Services;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Refit;
using KinopoiskDesktop.Integrations.KinopoiskUnofficialApi;
using Microsoft.Extensions.Configuration;
using KinopoiskDesktop.App.Configurations;
using KinopoiskDesktop.App.Views;
using KinopoiskDesktop.App.ViewModels;
using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.Domain.Managers;
using KinopoiskDesktop.DomainImplementation.Managers;
using KinopoiskDesktop.Domain.IManagers;

namespace KinopoiskDesktop.App
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var configuration = context.Configuration;
                    var kinopoiskApiSettings = configuration.GetSection("KinopoiskApi").Get<KinopoiskApiConfigurations>();

                    services.ConfigureLocalDatabase();
                    // TODO: Rethink lifetimes
                    services.AddSingleton<IMovieService, MovieService>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();

                    services.AddSingleton<IMovieManager, MovieManager>();
                    services.AddSingleton<IAuthenticationManager, AuthenticationManager>();

                    services.AddRefitClient<IKinopoiskClient>().ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri(kinopoiskApiSettings.BaseUrl);
                        c.DefaultRequestHeaders.Add("X-API-KEY", kinopoiskApiSettings.ApiKey);
                    });

                    services.AddSingleton<MainView>();
                    services.AddSingleton<HomeView>();
                    services.AddSingleton<UserLibraryView>();
                    services.AddSingleton<MovieDetailsView>();
                    services.AddSingleton<SettingsView>();
                    services.AddSingleton<LoginView>();
                    services.AddSingleton<RegisterView>();
                    services.AddSingleton<FilterView>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<UserLibraryViewModel>();
                    services.AddSingleton<MovieDetailsViewModel>();
                    services.AddSingleton<SettingsViewModel>();
                    services.AddSingleton<LoginViewModel>();
                    services.AddSingleton<RegisterViewModel>();
                    services.AddSingleton<FilterViewModel>();


                    services.AddSingleton<IViewModelFactory, ViewModelFactory>();
                    services.AddSingleton<INavigationService, NavigationService>();
                    services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var mainWindow = AppHost.Services.GetRequiredService<MainView>();
            var navigationService = AppHost.Services.GetRequiredService<INavigationService>();
            navigationService.NavigateTo<HomeViewModel>();
            mainWindow.Show();
        }
        

    }

}
