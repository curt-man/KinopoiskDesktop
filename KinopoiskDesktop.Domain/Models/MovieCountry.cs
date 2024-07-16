using Microsoft.EntityFrameworkCore;

namespace KinopoiskDesktop.Domain.Models
{
    [PrimaryKey(nameof(MovieId), nameof(CountryId))]
    public class MovieCountry
    {
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
