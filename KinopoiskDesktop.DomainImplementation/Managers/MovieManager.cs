using KinopoiskDesktop.DataAccess;
using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.IManagers;
using KinopoiskDesktop.Domain.Managers;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.DomainImplementation.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IApplicationDbContext _context;
        private readonly IAuthenticationManager _authenticationManager;
        private Guid? _currentUserId;

        public MovieManager(IApplicationDbContext context, IAuthenticationManager authenticationManager)
        {
            _context = context;
            _authenticationManager = authenticationManager;
            _currentUserId = _authenticationManager.CurrentUser?.Id;
        }

        public async Task<IEnumerable<AppUserMovie>> GetFavoritesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AppUserMovie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUserMovie> GetMovieByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUserMovie>> GetUserMoviesByFilter(MovieFilter filter)
        {
            try
            {
                var filteredMoviesQuery = _context.Movies.AsQueryable();

                if (filter.Countries != null && filter.Countries.Any())
                {
                    filteredMoviesQuery = filteredMoviesQuery.Include(x=>x.Countries).Where(m => m.Countries.Any(c => filter.Countries.Contains(c.CountryId)));
                }

                if (filter.Genres != null && filter.Genres.Any())
                {
                    filteredMoviesQuery = filteredMoviesQuery.Include(x=>x.Genres).Where(m => m.Genres.Any(g => filter.Genres.Contains(g.GenreId)));
                }

                if (filter.Order.HasValue)
                {
                    switch (filter.Order.Value)
                    {
                        case OrderTypeFilter.RATING:
                            filteredMoviesQuery = filteredMoviesQuery.OrderByDescending(m => m.RatingKinopoisk);
                            break;
                        case OrderTypeFilter.NUM_VOTE:
                            filteredMoviesQuery = filteredMoviesQuery.OrderByDescending(m => m.RatingKinopoiskVoteCount);
                            break;
                        case OrderTypeFilter.YEAR:
                            filteredMoviesQuery = filteredMoviesQuery.OrderByDescending(m => m.Year);
                            break;
                    }
                }

                if (filter.Type.HasValue)
                {
                    switch (filter.Type.Value)
                    {
                        case MovieTypeFilter.FILM:
                            filteredMoviesQuery = filteredMoviesQuery.Where(m => m.Type == FilmType.FILM);
                            break;
                        case MovieTypeFilter.TV_SHOW:
                            filteredMoviesQuery = filteredMoviesQuery.Where(m => m.Type == FilmType.TV_SHOW);
                            break;
                        case MovieTypeFilter.TV_SERIES:
                            filteredMoviesQuery = filteredMoviesQuery.Where(m => m.Type == FilmType.TV_SERIES);
                            break;
                        case MovieTypeFilter.MINI_SERIES:
                            filteredMoviesQuery = filteredMoviesQuery.Where(m => m.Type == FilmType.MINI_SERIES);
                            break;
                        case MovieTypeFilter.ALL:
                            break;
                    }
                }

                if (filter.RatingFrom.HasValue)
                {
                    filteredMoviesQuery = filteredMoviesQuery.Where(m =>
                        (m.RatingKinopoisk == null || m.RatingKinopoisk >= filter.RatingFrom )||
                        (m.RatingImdb == null || m.RatingImdb >= filter.RatingFrom )||
                        (m.RatingFilmCritics == null || m.RatingFilmCritics >= filter.RatingTo));
                }

                if (filter.RatingTo.HasValue)
                {
                    filteredMoviesQuery = filteredMoviesQuery.Where(m =>
                        (m.RatingKinopoisk == null || m.RatingKinopoisk <= filter.RatingFrom) ||
                        (m.RatingImdb == null || m.RatingImdb <= filter.RatingFrom) ||
                        (m.RatingFilmCritics == null || m.RatingFilmCritics <= filter.RatingTo));
                }

                if (filter.YearFrom.HasValue)
                {
                    filteredMoviesQuery = filteredMoviesQuery.Where(m =>
                        m.Year == null || m.Year >= filter.YearFrom);
                }

                if (filter.YearTo.HasValue)
                {
                    filteredMoviesQuery = filteredMoviesQuery.Where(m =>
                        m.Year == null || m.Year <= filter.YearFrom);
                }

                if (!string.IsNullOrWhiteSpace(filter.ImdbId))
                {
                    filteredMoviesQuery = filteredMoviesQuery.Where(m =>
                        m.ImdbId == null || m.ImdbId == filter.ImdbId);
                }

                if (!string.IsNullOrWhiteSpace(filter.Keyword))
                {
                    filteredMoviesQuery = filteredMoviesQuery.Where(m => m.NameRu.Contains(filter.Keyword) || m.NameEn.Contains(filter.Keyword) || m.NameOriginal.Contains(filter.Keyword));
                }

                var filteredMovies = await filteredMoviesQuery.ToListAsync();

                var userMovies = filteredMovies.Select(m => new AppUserMovie
                {
                    Movie = m,
                    AppUser = m.MovieAppUsers?.FirstOrDefault()?.AppUser,
                    IsFavorite = m.MovieAppUsers?.FirstOrDefault()?.IsFavorite ?? false,
                    IsWatched = m.MovieAppUsers?.FirstOrDefault()?.IsWatched ?? false,
                    Rating = m.MovieAppUsers?.FirstOrDefault()?.Rating
                }).ToList();

                return userMovies;
            }
            catch (Exception)
            {
                // Log the exception (not implemented here)
                return new List<AppUserMovie>();
            }
        }


        public async Task<IEnumerable<AppUserMovie>> GetUserMoviesForApi(IEnumerable<Movie> apiMovies)
        {
            try
            {
                var apiMovieIds = apiMovies.Select(m => m.KinopoiskId).ToList();

                var movies = _context.Movies.Where(m => apiMovieIds.Contains(m.KinopoiskId))
                                            .Include(m => m.MovieAppUsers.Where(mu => mu.AppUserId == _currentUserId))
                                            .ToList();

                var userMovies = movies.Select(m => new AppUserMovie
                {
                    Movie = m,
                    AppUser = m.MovieAppUsers?.FirstOrDefault()?.AppUser,
                    IsFavorite = m.MovieAppUsers?.FirstOrDefault()?.IsFavorite ?? false,
                    IsWatched = m.MovieAppUsers?.FirstOrDefault()?.IsWatched ?? false,
                    Rating = m.MovieAppUsers?.FirstOrDefault()?.Rating
                });

                return userMovies;
            }
            catch (Exception)
            {
                return new List<AppUserMovie>();
            }
            
        }


        public async Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task MarkAsFavoriteAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task MarkAsWatchedAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task RateMovieAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromFavoritesAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromWatchedAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }



        public async Task SyncWithApiAsync<TEntity, TId>(IEnumerable<TEntity> apiEntities)
            where TEntity : BaseEntity<TId>, ISyncableEntity<TId>
        {
            var apiEntitiesIds = apiEntities.Select(e => e.SyncProperty).ToList();

            var existingEntities = await _context.DbContext.Set<TEntity>()
                .ToListAsync();

            var existingEntityDict = existingEntities
                .Where(e => apiEntitiesIds.Contains(e.SyncProperty))
                .ToDictionary(e => e.SyncProperty);

            var entitiesToUpdate = new List<TEntity>();
            var entitiesToInsert = new List<TEntity>();

            foreach (var apiEntity in apiEntities)
            {
                apiEntity.SyncedAt = DateTime.UtcNow;
                apiEntity.SyncPeriod = TimeSpan.FromMinutes(60);

                if (existingEntityDict.TryGetValue(apiEntity.SyncProperty, out var existingEntity))
                {
                    existingEntity.UpdatedAt = DateTime.UtcNow;
                    entitiesToUpdate.Add(existingEntity);
                }
                else
                {
                    apiEntity.CreatedAt = DateTime.UtcNow;
                    entitiesToInsert.Add(apiEntity);
                }
            }

            _context.DbContext.Set<TEntity>().UpdateRange(entitiesToUpdate);
            _context.DbContext.Set<TEntity>().AddRange(entitiesToInsert);

            await _context.DbContext.SaveChangesAsync();
        }

        public async Task SyncMoviesWithApiAsync(IEnumerable<Movie> apiMovies)
        {
            var apiMovieIds = apiMovies.Select(m => m.KinopoiskId).ToList();

            var existingMovies = await _context.Movies
                .Where(m => apiMovieIds.Contains(m.KinopoiskId))
                .ToListAsync();

            var existingMovieDict = existingMovies.ToDictionary(m => m.KinopoiskId);

            var moviesToUpdate = new List<Movie>();
            var moviesToInsert = new List<Movie>();

            foreach (var apiMovie in apiMovies)
            {
                if (existingMovieDict.TryGetValue(apiMovie.KinopoiskId, out var existingMovie))
                {
                    existingMovie.UpdatedAt = DateTime.UtcNow;
                    existingMovie.SyncedAt = DateTime.UtcNow;
                    existingMovie.SyncPeriod = TimeSpan.FromMinutes(3);
                    moviesToUpdate.Add(existingMovie);
                }
                else
                {
                    apiMovie.SyncedAt = DateTime.UtcNow;
                    apiMovie.SyncPeriod = TimeSpan.FromMinutes(3);
                    apiMovie.CreatedAt = DateTime.UtcNow;
                    moviesToInsert.Add(apiMovie);
                }
            }

            _context.Movies.UpdateRange(moviesToUpdate);
            _context.Movies.AddRange(moviesToInsert);

            await _context.DbContext.SaveChangesAsync();

        }

        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
