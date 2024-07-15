using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.Managers
{
    public interface IMovieManager
    {
        Task<IEnumerable<AppUserMovie>> GetUserMoviesForApi(IEnumerable<Movie> apiMovies);
        Task<IEnumerable<AppUserMovie>> GetUserMoviesByFilter(MovieFilter filter);
        Task<AppUserMovie> GetMovieByIdAsync(int id);
        Task<AppUserMovie> GetMovieByNameAsync(string name);

        Task MarkAsFavoriteAsync(AppUserMovie movie);
        Task RemoveFromFavoritesAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetFavoritesAsync();

        Task MarkAsWatchedAsync(AppUserMovie movie);
        Task RemoveFromWatchedAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync();

        Task RateMovieAsync(AppUserMovie movie);
        Task SyncMoviesWithApiAsync(IEnumerable<Movie> apiMovies);
        Task SyncWithApiAsync<TEntity, TId>(IEnumerable<TEntity> apiCountries) where TEntity : BaseEntity<TId>, ISyncableEntity<TId>;

        List<Country> GetCountries();
        List<Genre> GetGenres();
    }
}
