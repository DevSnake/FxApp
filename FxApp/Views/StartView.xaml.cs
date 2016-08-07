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
            SplitViewFrame.Navigate(typeof(TicksView));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void Fill_OnClick(object sender, RoutedEventArgs e)
        {
            //await StartViewModel.GetData();
        }


        private void OnHomeButtonChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                SplitViewFrame.Navigate(typeof(TicksView));

        }

        private void OnAcccountButtonChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                SplitViewFrame.Navigate(typeof(AccountView));

        }
    }
}
