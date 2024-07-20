namespace KinopoiskDesktop.App.Core
{
    public class SelectableItem<T> : ViewModelBase
    {
        private bool _isSelected;

        public SelectableItem(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }

}
