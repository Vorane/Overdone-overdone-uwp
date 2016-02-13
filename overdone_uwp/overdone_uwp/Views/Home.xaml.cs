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
        AppViewModel _viewmodel;
        Grid _openContext;
        double _originalHeight;
        public Home()
        {
            DataContext = _viewmodel = AppViewModel.GetViewModel();

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
            try
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
            catch { }
        }

        private void MonthViewScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var calendar_scroll_viewer = (ScrollViewer)sender;

                var height = calendar_scroll_viewer.ActualHeight;

                _originalHeight = height;
                // Uncomment if using 2 weeks in view

                /*
                _viewmodel.ChangeCalendarHeight();\
                */
            }
            catch { }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _calendarGrid = (Grid)sender;
                ChangeCalendarHeight();
            }
            catch { }
        }

        private void FlowCalendar_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _calendar = (CalendarView)sender;
                _calendar.SetDisplayDate(_currentDate = DateTime.Now);
            }
            catch { }
        }

        private void FlowCalendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            try
            {
                sender.SetDisplayDate(_currentDate = sender.SelectedDates.First());
                DateTime SelectedDate = (sender.SelectedDates[0]).LocalDateTime;
                _viewmodel.FilterTasksByDay((sender.SelectedDates[0]).LocalDateTime);
            }
            catch { }
        }

        private void ChangeCalendarHeight()
        {
            try
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
            catch { }
        }
        #endregion

        #region Task listbox logic

        private void TaskItemParent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
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
            catch { }
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (_openContext != null)
                {
                    _openContext.Height = 0;
                }
            }
            catch { }
        }

        #endregion

        protected void SetUpPageAnimation()
        {
            try
            {
                TransitionCollection collection = new TransitionCollection();
                NavigationThemeTransition theme = new NavigationThemeTransition();

                var info = new ContinuumNavigationTransitionInfo();

                theme.DefaultNavigationTransitionInfo = info;
                collection.Add(theme);
                this.Transitions = collection;
            }
            catch { }
        }

        private void AddButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.NavigateTo<EditTaskView>(_currentDate);
            }
            catch { }
        }

        private void DoneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }

        private void EditButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.NavigateTo<EditTaskView>((task)TaskListBox.SelectedItem);
            }
            catch { }
        }

        private void DeleteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.RemoveTask((task)TaskListBox.SelectedItem);
            }
            catch { }
        }
    }
}
