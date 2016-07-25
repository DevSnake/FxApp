using System.Collections.ObjectModel;
using BlackBee.Common;

namespace FxApp.Base.ViewModels
{
    public class StartViewModel:XBlackObject,
        IStart
    {
        private ObservableCollection<ItemViewModel> _collection;

        public ObservableCollection<ItemViewModel> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                NotifyPropertyChanged();
            }
        }
    }
}
