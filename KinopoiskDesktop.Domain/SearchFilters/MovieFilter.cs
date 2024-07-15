using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.SearchFilters
{
    public class MovieFilter
    {
        public IEnumerable<int>? Countries { get; set; }
        public IEnumerable<int>? Genres { get; set; }
        public OrderTypeFilter? Order { get; set; }
        public MovieTypeFilter? Type { get; set; }
        public double? RatingFrom { get; set; }
        public double? RatingTo { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public string? ImdbId { get; set; }
        public string? Keyword { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }

    public enum OrderTypeFilter
    {
        RATING = 0,
        NUM_VOTE = 1,
        YEAR = 2,
    }

    public enum MovieTypeFilter
    {
        FILM = 0,
        TV_SHOW = 1,
        TV_SERIES = 2,
        MINI_SERIES = 3,
        ALL = 4,
    }
}
