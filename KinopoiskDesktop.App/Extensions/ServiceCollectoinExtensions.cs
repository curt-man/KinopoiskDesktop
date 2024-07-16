using KinopoiskDesktop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace KinopoiskDesktop.App.Extensions
{
    public static class ServiceCollectoinExtensions
    {
        /// <summary>
        /// Configures local database for the application
        /// </summary>
        /// <param name="services">DI service collection</param>
        public static void ConfigureLocalDatabase(this IServiceCollection services)
        {
            var directory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\KinopoiskDesktop.DataAccess\Database"));
            var dbFilePath = Path.Combine(directory, "KinopoiskDesktopDatabase.db");
            var connectionString = @$"Data Source={dbFilePath}";

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
        }
    }
}
