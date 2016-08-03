using System.Threading.Tasks;
using FxApp.Data;

namespace FxApp.Base.ViewModels
{
    using System.Collections.ObjectModel;
    using BlackBee.Common;
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

        public StartViewModel()
        {
            _collection=new ObservableCollection<ItemViewModel>();
        }
        public static async Task GetData()
        {
            using (var bc = new BussinessContext(AppMode.Instance))
            {
                //await bc.CreateDatabase();

                //await bc.CreateTick("EURUSD");

                //await bc.CreateTick("USDCNH");


                var list = await bc.GetTicks();

                //foreach (var x in list)
                //{
                //    StoreStorage.CreateOrGet<StartViewModel>().Collection.Add(
                //        new ItemViewModel()
                //        {
                //            Name = x.Symbol,
                //            ActualDateTime = x.TimeStamp
                //        });
                //}
            }
        }
    }
}
