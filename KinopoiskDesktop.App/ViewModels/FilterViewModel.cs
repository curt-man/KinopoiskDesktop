using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class FilterViewModel : BaseViewModel
    {
        private readonly IMovieService _movieService;
        private IEnumerable<int>? _countries;
        private IEnumerable<int>? _genres;
        private OrderTypeFilter? _order;
        private MovieTypeFilter? _type;
        private double? _ratingFrom;
        private double? _ratingTo;
        private int? _yearFrom;
        private int? _yearTo;
        private string? _imdbId;
        private string? _keyword;

        public IEnumerable<int>? Countries
        {
            get => _countries;
            set { _countries = value; OnPropertyChanged(); }
        }

        public IEnumerable<int>? Genres
        {
            get => _genres;
            set { _genres = value; OnPropertyChanged(); }
        }

        public OrderTypeFilter? Order
        {
            get => _order;
            set { _order = value; OnPropertyChanged(); }
        }

        public MovieTypeFilter? Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged(); }
        }

        public double? RatingFrom
        {
            get => _ratingFrom;
            set { _ratingFrom = value; OnPropertyChanged(); }
        }

        public double? RatingTo
        {
            get => _ratingTo;
            set { _ratingTo = value; OnPropertyChanged(); }
        }

        public int? YearFrom
        {
            get => _yearFrom;
            set { _yearFrom = value; OnPropertyChanged(); }
        }

        public int? YearTo
        {
            get => _yearTo;
            set { _yearTo = value; OnPropertyChanged(); }
        }

        public string? ImdbId
        {
            get => _imdbId;
            set { _imdbId = value; OnPropertyChanged(); }
        }

        public string? Keyword
        {
            get => _keyword;
            set { _keyword = value; OnPropertyChanged(); }
        }

        public ICommand ApplyFiltersCommand { get; set; }

        public FilterViewModel(IMovieService movieService)
        {
            _movieService = movieService;
            ApplyFiltersCommand = new RelayCommand(async _ => await applyFiltersDelegate(this), _ => true);
        }

        
        public Func<FilterViewModel, Task> applyFiltersDelegate;

    }

}
