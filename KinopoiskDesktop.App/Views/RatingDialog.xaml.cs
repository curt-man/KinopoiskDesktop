using System.Windows;

namespace KinopoiskDesktop.App.Views
{
    public partial class RatingDialog : Window
    {
        public double? Rating { get; private set; }

        public RatingDialog()
        {
            InitializeComponent();
        }

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            Rating = RatingSlider.Value;
            DialogResult = true;
            Close();
        }
    }
}
