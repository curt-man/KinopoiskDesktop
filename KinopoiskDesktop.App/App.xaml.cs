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
using System.Reflection;

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

                    services.AddScoped<IMovieService, MovieService>();
                    services.AddScoped<IAuthenticationService, AuthenticationService>();

                    services.AddScoped<IMovieManager, MovieManager>();
                    services.AddScoped<IAuthenticationManager, AuthenticationManager>();

                    services.AddScoped<IViewModelFactory, ViewModelFactory>();
                    services.AddSingleton<INavigationService, NavigationService>();

                    services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

                    services.AddRefitClient<IKinopoiskClient>().ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri(kinopoiskApiSettings.BaseUrl);
                        c.DefaultRequestHeaders.Add("X-API-KEY", kinopoiskApiSettings.ApiKey);
                    });

                    var types = Assembly.GetExecutingAssembly().GetTypes();
                    var viewsAndViewModels = types.Where(x => x.Name.EndsWith("ViewModel") || x.Name.EndsWith("View"));
                    foreach (var type in viewsAndViewModels)
                    {
                        services.AddSingleton(type);
                    }

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
