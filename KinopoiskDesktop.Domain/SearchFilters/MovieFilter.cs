namespace KinopoiskDesktop.Domain.SearchFilters
{
    /// <summary>
    /// Represents a filter for searching movies.
    /// </summary>
    public class MovieFilter
    {
        /// <summary>
        /// The list of country IDs to filter movies by.
        /// </summary>
        public IEnumerable<int>? Countries { get; set; }

        /// <summary>
        /// The list of genre IDs to filter movies by.
        /// </summary>
        public IEnumerable<int>? Genres { get; set; }

        /// <summary>
        /// The order type for sorting the search results.
        /// </summary>
        public OrderTypeFilter? Order { get; set; }

        /// <summary>
        /// The type of movie to filter by.
        /// </summary>
        public MovieTypeFilter? Type { get; set; }

        /// <summary>
        /// The minimum rating to filter movies by.
        /// </summary>
        public double? RatingFrom { get; set; }

        /// <summary>
        /// The maximum rating to filter movies by.
        /// </summary>
        public double? RatingTo { get; set; }

        /// <summary>
        /// The starting year to filter movies by.
        /// </summary>
        public int? YearFrom { get; set; }

        /// <summary>
        /// The ending year to filter movies by.
        /// </summary>
        public int? YearTo { get; set; }

        /// <summary>
        /// The IMDb ID to filter movies by.
        /// </summary>
        public string? ImdbId { get; set; }

        /// <summary>
        /// The keyword to search movies by.
        /// </summary>
        public string? Keyword { get; set; }

        /// <summary>
        /// Indicates if the filter should include only favorite movies.
        /// </summary>
        public bool? IsFavorite { get; set; }

        /// <summary>
        /// Indicates if the filter should include only movies for the current user.
        /// </summary>
        public bool? ForCurrentUser { get; set; }

        /// <summary>
        /// The page number for paginated results.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// The page size for paginated results.
        /// </summary>
        public int? PageSize { get; set; }
    }

    /// <summary>
    /// Represents the order type for sorting movie search results.
    /// </summary>
    public enum OrderTypeFilter
    {
        /// <summary>
        /// Order by rating.
        /// </summary>
        RATING = 0,

        /// <summary>
        /// Order by number of votes.
        /// </summary>
        NUM_VOTE = 1,

        /// <summary>
        /// Order by year.
        /// </summary>
        YEAR = 2,
    }

    /// <summary>
    /// Represents the type of movie to filter by.
    /// </summary>
    public enum MovieTypeFilter
    {
        /// <summary>
        /// Filter by film.
        /// </summary>
        FILM = 0,

        /// <summary>
        /// Filter by TV show.
        /// </summary>
        TV_SHOW = 1,

        /// <summary>
        /// Filter by TV series.
        /// </summary>
        TV_SERIES = 2,

        /// <summary>
        /// Filter by mini series.
        /// </summary>
        MINI_SERIES = 3,

        /// <summary>
        /// Filter by all types.
        /// </summary>
        ALL = 4,
    }

}
