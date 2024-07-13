using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.Services
{
    public class MovieService : IMovieService
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
