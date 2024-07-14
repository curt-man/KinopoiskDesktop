using KinopoiskDesktop.App.Helpers;
using KinopoiskDesktop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.Extensions
{
    public static class ServiceCollectoinExtensions
    {
        public static void AddFormFactory<TForm>(this IServiceCollection services) where TForm : class
        {
            services.AddTransient<TForm>();
            services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>());
            services.AddSingleton<IAbstractFactory<TForm>, AbstractFactory<TForm>>();
        }

        public static void ConfigureLocalDatabase(this IServiceCollection services)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "../KinopoiskDesktop.DataAccess/Database");
            var dbFilePath = Path.Combine(directory, "KinopoiskDesktopDatabase.db");
            var connectionString = @$"Data Source={dbFilePath}";

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
        }
    }
}
