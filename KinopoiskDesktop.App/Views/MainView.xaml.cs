using KinopoiskDesktop.App.ViewModels;
using System.Windows;

namespace KinopoiskDesktop.App
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }

    }
}
