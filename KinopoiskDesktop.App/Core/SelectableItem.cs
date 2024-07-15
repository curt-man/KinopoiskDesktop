using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.Core
{
    public class SelectableItem<T> : BaseViewModel
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
