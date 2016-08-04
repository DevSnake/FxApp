namespace FxApp.Base.ViewModels
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using System.Collections.ObjectModel;
    using BlackBee.Common;

    public class StartViewModel:XBlackObject,
        IStart,IStartMethods, IStartCommands
    {

        private ObservableCollection<ItemViewModel> _collection;

        public IStartMethods StartMethods { get; }

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
            StartMethods = new StartLogic(this);
        }
        public static async Task GetData()
        {
            using (var bc = new BussinessContext(AppMode.Instance))
            {
                var list = await bc.GetTicks();

                foreach (var item in list)
                {
                    StoreStorage.CreateOrGet<StartViewModel>().Collection.Add(
                        new ItemViewModel()
                        {
                            Name = item.Symbol,
                            ActualDateTime = item.Timestamp,
                            FieldGreen1 = item.Levels.Single(x => x.Type == PriceTypeModel.Ask).Price,
                            FieldGreen2 = item.Levels.Single(x => x.Type == PriceTypeModel.Ask).Volume,

                            FieldRed1 =  item.Levels.Single(x => x.Type == PriceTypeModel.Bid).Price,
                            FieldRed2 = item.Levels.Single(x => x.Type == PriceTypeModel.Bid).Volume
                        });
                }
            }
        }
    }
}
