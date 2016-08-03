using System.Linq;
using System.Threading.Tasks;
using FxApp.Data;
using FxApp.Data.Models;

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

                foreach (var item in list)
                {
                    //if (item.Levels != null)
                    //{
                    //    if (item.Levels.Any(x=>x.Type ==PriceType.Ask))
                    //    {
                    //        decimal value1 = item.Levels.Single(x => x.Type == PriceType.Ask).Price;
                    //    }
                        
                    //}
                    StoreStorage.CreateOrGet<StartViewModel>().Collection.Add(
                        new ItemViewModel()
                        {
                            Name = item.Symbol,
                            ActualDateTime = item.Timestamp,
                            FieldGreen1 = item.Levels.Single(x => x.Type == PriceType.Ask).Price,
                            FieldGreen2 = item.Levels.Single(x => x.Type == PriceType.Ask).Volume,

                            FieldRed1 =  item.Levels.Single(x => x.Type == PriceType.Bid).Price,
                            FieldRed2 = item.Levels.Single(x => x.Type == PriceType.Bid).Volume
                        });
                }
            }
        }
    }
}
