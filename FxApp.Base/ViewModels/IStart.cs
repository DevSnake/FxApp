

namespace FxApp.Base
{
    using System.Collections.ObjectModel;
    using ViewModels;

    internal interface IStart
    {
        ObservableCollection<ItemViewModel> Collection{ get; set; }
    }
}