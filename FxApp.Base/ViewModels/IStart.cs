using System.Collections.ObjectModel;
using FxApp.Base.ViewModels;

namespace FxApp.Base
{
    internal interface IStart
    {
        ObservableCollection<ItemViewModel> Collection{ get; set; }
    }
}