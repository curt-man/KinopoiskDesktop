using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using KinopoiskDesktop.Integrations.KinopoiskUnofficialApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.Services.IService
{
    public interface IMovieService
    {
        Task<IEnumerable<AppUserMovie>> GetMoviesByFilterAsync(MovieFilter? filter = null);

        Task AddToFavoritesAsync(AppUserMovie movie);
        Task RemoveFromFavoritesAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetFavoritesAsync();

        Task MarkAsWatchedAsync(AppUserMovie movie);
        Task MarkAsUnwatchedAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync();

        Task RateMovieAsync(AppUserMovie movie);

        Task SyncWithApiAsync();


        // Here should be more methods. Method to find movie by filters. Create a filter class and pass it as a parameter.
    }
}
