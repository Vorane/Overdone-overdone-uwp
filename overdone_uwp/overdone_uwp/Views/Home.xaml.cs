using overdone_uwp.Models;
using Windows.UI.Xaml.Controls;
using overdone_uwp.ViewModel;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using System;
using Windows.UI.Xaml.Input;
using System.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace overdone_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        HomeViewModel _presenter;
        Grid _openContext;
        public Home()
        {
            this.InitializeComponent();
            DBTester DBT = new DBTester(); 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameter = e.Parameter as ApplicationViewModel;
            _presenter = new HomeViewModel(this);
        }

        // calendar logic

        private void ExpandCalendar(object sender, RoutedEventArgs e)
        {
            _presenter.ChangeCalendarHeight();

        }

        private void MonthViewScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {

            var calendar_scroll_viewer = (ScrollViewer)sender;

            var height = calendar_scroll_viewer.ActualHeight;

            _presenter.CalendarPanelHeight = height;
            _presenter.original_height = height;

            // Uncomment if using 2 weeks in view

            /*
            _presenter.ChangeCalendarHeight();\
            */
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _presenter._calendar_grid = (Grid)sender;

            _presenter.ChangeCalendarHeight();
            _presenter.ChangeCalendarHeight();
        }

        private void FlowCalendar_Loaded(object sender, RoutedEventArgs e)
        {
            _presenter.SetCalendar((CalendarView)sender);
            ((CalendarView)sender).SetDisplayDate(_presenter.CurrentDate = DateTime.Now);
        }

        private void FlowCalendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            _presenter.CurrentDate = sender.SelectedDates[0];
            sender.SetDisplayDate(_presenter.CurrentDate);
        }



        private void TaskItemParent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid parent = (Grid)sender;
            var children = parent.Children;
        
            Grid contextMenu = (Grid)children.ElementAt(1);
            _openContext = contextMenu;
            if (contextMenu.Height != 0)
            {
                contextMenu.Height = 0;
            }
            else
            {
                contextMenu.Height = Double.NaN;
            }
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_openContext != null)
            {
                _openContext.Height = 0;
            }
        }

        private void Hamburger_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.RootSplitView.IsPaneOpen = !MainPage.RootSplitView.IsPaneOpen;
        }
    }
}
