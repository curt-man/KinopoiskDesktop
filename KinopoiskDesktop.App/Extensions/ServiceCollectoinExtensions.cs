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
        

        public static void ConfigureLocalDatabase(this IServiceCollection services)
        {
            // TODO: Change to relative path
            var dbFilePath = @"C:\Projects\KinopoiskDesktop\KinopoiskDesktop.DataAccess\Database\KinopoiskDesktopDatabase.db";
            var connectionString = @$"Data Source={dbFilePath}";

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
        }
    }
}
