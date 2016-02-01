using overdone_uwp.Models;
using Windows.UI.Xaml.Controls;
using overdone_uwp.ViewModel;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace overdone_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        HomeViewModel _viewModel;
        public Home()
        {
            this.InitializeComponent();
            DBTester DBT = new DBTester(); 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter as ApplicationViewModel;
            _viewModel = new HomeViewModel(this);
        }

    }
}
