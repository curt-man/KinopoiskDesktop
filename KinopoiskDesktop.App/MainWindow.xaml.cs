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
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;
            //var httpClient = new System.Net.Http.HttpClient();
            //httpClient.DefaultRequestHeaders.Add("X-API-KEY", "94c93b33-bf4a-4cdf-82f1-43d184671905");
            //Api = new KinopoiskAPI(httpClient);

            //Films = new ObservableCollection<Film>();
        }

    }
}
