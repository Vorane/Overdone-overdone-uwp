using overdone_uwp.Models;
using Windows.UI.Xaml.Controls;
using overdone_uwp.ViewModel;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using System;
using Windows.UI.Xaml.Input;
using System.Linq;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace overdone_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        CalendarView _calendar;
        Grid _calendarGrid;
        DateTimeOffset _currentDate;
        AppViewModel _presenter;
        Grid _openContext;
        double _originalHeight;
        public Home()
        {
            DataContext = _presenter =  AppViewModel.GetViewModel();

            this.InitializeComponent();
            DBTester DBT = new DBTester();
            SetUpPageAnimation();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        #region Calendar Navigation Logic

        private void ExpandCalendar(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            /*
            Storyboard sb = ((RotateTransform)button.RenderTransform).Angle > 0? (Storyboard)this.Resources["CloseRotateAnimation"] : (Storyboard) this.Resources["OpenRotateAnimation"];
            //Storyboard sb = this.FindResource("PlayAnimation") as Storyboard;
            Storyboard.SetTarget(sb, (Button) sender);
            sb.Begin();
            */
            ChangeCalendarHeight();
        }

        private void MonthViewScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {

            var calendar_scroll_viewer = (ScrollViewer)sender;

            var height = calendar_scroll_viewer.ActualHeight;

            _originalHeight = height;
            // Uncomment if using 2 weeks in view

            /*
            _presenter.ChangeCalendarHeight();\
            */
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {         
            _calendarGrid = (Grid)sender;
            ChangeCalendarHeight();

        }

        private void FlowCalendar_Loaded(object sender, RoutedEventArgs e)
        {
            _calendar = (CalendarView)sender;
            _calendar.SetDisplayDate(_currentDate =  DateTime.Now);
        }

        private void FlowCalendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            sender.SetDisplayDate(_currentDate = sender.SelectedDates.First());
        }

        private void ChangeCalendarHeight()
        {
            if (_calendarGrid.ActualHeight == _originalHeight || _originalHeight == Double.NaN)
            {
                _calendarGrid.Height = _originalHeight / 6;
                _calendar.NumberOfWeeksInView = 2;

                _calendar.SetDisplayDate(_currentDate);
            }
            else
            {
                _calendarGrid.Height = _originalHeight;
                _calendar.NumberOfWeeksInView = 6;
                _calendar.SetDisplayDate(_currentDate);
            }
        }
        #endregion

        #region Task listbox logic

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

        #endregion

        protected  void SetUpPageAnimation()
        {
            TransitionCollection collection = new TransitionCollection();
            NavigationThemeTransition theme = new NavigationThemeTransition();

            var info = new ContinuumNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            this.Transitions = collection;
        }

        private void AddButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _presenter.NavigateTo<EditTaskView>();
        }
    }
}
