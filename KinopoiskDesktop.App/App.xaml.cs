using KinopoiskDesktop.App.Extensions;
using KinopoiskDesktop.App.Services;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using Refit;

using KinopoiskDesktop.Integrations.KinopoiskUnofficialApi;
using Microsoft.Extensions.Configuration;
using KinopoiskDesktop.App.Configurations;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace KinopoiskDesktop.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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
                    var path = Path.GetFullPath("KinopoiskDesktopDatabase.db");
                    var connectionString = @$"Data Source={path}";

                    services.AddDbContext<KinopoiskDbContext>(options=>
                    {
                        options.UseSqlite(connectionString);
                    });

                    services.AddScoped<IMovieService, MovieService>();
                    services.AddScoped<IUserService, UserService>();


                    services.AddRefitClient<IKinopoiskClient>().ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri(kinopoiskApiSettings.BaseUrl);
                        c.DefaultRequestHeaders.Add("X-API-KEY", kinopoiskApiSettings.ApiKey);
                    });

                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
        

    }

}
