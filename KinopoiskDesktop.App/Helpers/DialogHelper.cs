using KinopoiskDesktop.App.Views;

namespace KinopoiskDesktop.App.Helpers
{
    public class DialogHelper
    {
        /// <summary>
        /// Shows a dialog for rating a movie
        /// </summary>
        /// <returns></returns>
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
