using BlackBee.Common;
using FxApp.Base.ViewModels;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FxApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TicksView : Page
    {
        public TicksView()
        {
            this.InitializeComponent();
            DataContext = StoreStorage.CreateOrGet<StartViewModel>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await Task.Delay(3);
            StoreStorage.CreateOrGet<StartViewModel>().Collection = await StartViewModel.GetData();
        }
    }
}
