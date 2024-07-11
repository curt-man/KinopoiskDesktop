using KinopoiskApi;
using KinopoiskDesktop.Integrations;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KinopoiskDesktop.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IKinopoiskClient Api { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", "94c93b33-bf4a-4cdf-82f1-43d184671905");
            Api = new KinopoiskAPI(httpClient);

            Films = new ObservableCollection<Film>();
        }

        public ObservableCollection<Film> Films { get; set; }

        private async void FilmsButton_Click(object sender, RoutedEventArgs e)
        {
            var response = await Api.Films2Async(countries: [1], genres: [1], null, null, null, null, null, null, null, null, null);
            var movieListItems = response.Items;
            var movieList = movieListItems.Select(x => new Film()
            {
                NameOriginal = x.NameOriginal,
                Year = (int)x.Year,
                Genres = x.Genres,
            });
            foreach (var item in movieList)
            {
                Films.Add(item);
            }
        }
    }
}
