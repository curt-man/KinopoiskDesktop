using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
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
        Task<IEnumerable<AppUserMovie>> GetFavoritesByFilterAsync(MovieFilter? filter = null);

        Task MarkAsWatchedAsync(AppUserMovie movie);
        Task MarkAsUnwatchedAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync();

        Task RateMovieAsync(AppUserMovie movie);

        Task SyncWithApiAsync();

        List<Country> GetCountries();
        List<Genre> GetGenres();

    }
}
