

namespace FxApp.Base
{
    using System.Collections.ObjectModel;
    using ViewModels;

    public interface IStart
    {
        IStartMethods StartMethods { get; }
        ObservableCollection<ItemViewModel> Collection{ get; set; }
    }
}