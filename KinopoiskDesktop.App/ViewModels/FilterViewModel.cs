using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class FilterViewModel : BaseViewModel
    {
        private readonly IMovieService _movieService;

        public FilterViewModel(IMovieService movieService)
        {
            _movieService = movieService;
            ApplyFiltersCommand = new RelayCommand(async _ => await applyFiltersDelegate(this), _ => true);
            LoadCountriesAndGenres();
            PopulateEnums();
        }

        public ICommand ApplyFiltersCommand { get; set; }
        public Func<FilterViewModel, Task> applyFiltersDelegate { get; set; }

        public ObservableCollection<SelectableItem<Country>> Countries { get; set; } = new ObservableCollection<SelectableItem<Country>>();
        public ObservableCollection<SelectableItem<Genre>> Genres { get; set; } = new ObservableCollection<SelectableItem<Genre>>();
        public ObservableCollection<OrderTypeFilter> OrderTypes { get; set; } = new ObservableCollection<OrderTypeFilter>();
        public ObservableCollection<MovieTypeFilter> MovieTypes { get; set; } = new ObservableCollection<MovieTypeFilter>();

        // Just noticed, that API temporarily doens't support multiple countries and genres
        public ObservableCollection<int> SelectedCountries => new ObservableCollection<int>(Countries.Where(c => c.IsSelected).Select(c => c.Item.Id));
        public ObservableCollection<int> SelectedGenres => new ObservableCollection<int>(Genres.Where(g => g.IsSelected).Select(g => g.Item.Id));
        public OrderTypeFilter? SelectedOrder { get; set; }
        public MovieTypeFilter? SelectedType { get; set; }

        public double? RatingFrom { get; set; }
        public double? RatingTo { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public string ImdbId { get; set; }
        public string Keyword { get; set; }

        private void LoadCountriesAndGenres()
        {
            var countries = _movieService.GetCountries();
            var genres =  _movieService.GetGenres();

            foreach (var country in countries)
            {
                Countries.Add(new SelectableItem<Country>(country));
            }

            foreach (var genre in genres)
            {
                Genres.Add(new SelectableItem<Genre>(genre));
            }
        }

        private void PopulateEnums()
        {
            foreach (OrderTypeFilter orderType in Enum.GetValues(typeof(OrderTypeFilter)))
            {
                OrderTypes.Add(orderType);
            }

            foreach (MovieTypeFilter movieType in Enum.GetValues(typeof(MovieTypeFilter)))
            {
                MovieTypes.Add(movieType);
            }
        }
    }
}
