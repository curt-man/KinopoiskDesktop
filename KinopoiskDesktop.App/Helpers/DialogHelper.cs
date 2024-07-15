using KinopoiskDesktop.App.Views;
using System.Threading.Tasks;
using System.Windows;

namespace KinopoiskDesktop.App.Helpers
{
    public class DialogHelper
    {
        public async Task<double?> ShowRatingDialogAsync()
        {
            var dialog = new RatingDialog();
            if (dialog.ShowDialog() == true)
            {
                return dialog.Rating;
            }
            else
            {
                return null;
            }
        }
    }
}
