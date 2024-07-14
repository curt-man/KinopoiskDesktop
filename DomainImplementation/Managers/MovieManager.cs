using KinopoiskDesktop.DataAccess;
using KinopoiskDesktop.Domain.Managers;
using KinopoiskDesktop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainImplementation.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IApplicationDbContext _context;

        public MovieManager(IApplicationDbContext context)
        {
            _context = context;
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

        public Task<IEnumerable<AppUserMovie>> GetMoviesAsync(IEnumerable<Movie> apiMovies, Guid userId)
        {
            var existingMovies = _context.Movies.Where(x => apiMovies.Contains(x)).Include(x => x.MovieAppUsers.Where(x => x.AppUserId == userId));

            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUserMovie>> GetMoviesAsync(IEnumerable<Movie> apiMovies)
        {
            throw new NotImplementedException();
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

        public Task SyncMoviesWithApiAsync(IEnumerable<Movie> apiMovies)
        {
            var moviesToUpdate = _context.Movies.Intersect(apiMovies);
            var moviesToInsert = apiMovies.Except(moviesToUpdate);
            _context.Movies.UpdateRange(moviesToUpdate);
            _context.Movies.AddRange(moviesToInsert);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
