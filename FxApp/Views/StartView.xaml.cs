using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using BlackBee.Common;
using FxApp.Base.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FxApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartView : Page
    {
        public StartView()
        {
            this.InitializeComponent();
            DataContext = StoreStorage.CreateOrGet<StartViewModel>();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void Fill_OnClick(object sender, RoutedEventArgs e)
        {
            await StartViewModel.GetData();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
    }
}
