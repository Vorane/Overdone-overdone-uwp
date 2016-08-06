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
using Windows.UI.Core;
using Windows.UI.Popups;

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

            SetUpPageAnimation();
        }


        #region Update Date if There is a task

        private void FlowCalendar_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            bool taskexist = false;

            foreach (task t in _viewmodel.GetPendingTasks())
            {
                if (args.Item.Date.Date.Equals(t.task_deadline.Date))
                {
                    taskexist = true;
                    break;
                }
            }

            if (taskexist)
            {
                args.Item.Style = (Windows.UI.Xaml.Style)Resources["DayItemEventStyle"];
            }


        }
        #endregion

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter != null)
            {
                if (e.Parameter is String)
                {
                    _currentDate = DateTimeOffset.Now;
                    if (FlowCalendar != null)
                        FlowCalendar.SetDisplayDate(_currentDate);
                    return;
                }


                _currentDate = (DateTimeOffset)e.Parameter;
                if (FlowCalendar != null)
                    FlowCalendar.SetDisplayDate(_currentDate);
                return;
            }
            else
            {
                _currentDate = DateTimeOffset.Now;
                if (FlowCalendar != null)
                    FlowCalendar.SetDisplayDate(_currentDate);
            }


        }

        #region Calendar Navigation Logic

        private void FlowCalendar_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _calendar = (CalendarView)sender;
                FlowCalendar.SetDisplayDate(_currentDate);
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

                _viewmodel.SetCurrentTask((task)contextMenu.DataContext);
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


        private void DoneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                task SelectedTask = (task)b.DataContext;
                _viewmodel.CompleteTask(SelectedTask);
            }
            catch { }
        }

        private void EditButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.NavigateTo<EditTaskView>((task)TaskListView.SelectedItem);
            }
            catch { }
        }

        private void DeleteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                _viewmodel.RemoveTask((task)TaskListView.SelectedItem);
            }
            catch { }
        }

        private void PinButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _viewmodel.PinTaskToTaskBarNow((task)TaskListView.SelectedItem);
        }

        private void AllTasksButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _calendar.SetDisplayDate(DateTimeOffset.Now);
                _viewmodel.GetAllPendingTasks();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editTaskControl.Visibility == Visibility.Collapsed)
                {
                    _viewmodel.NavigateTo<EditTaskView>(_currentDate);
                }
                else
                {
                    //focus on the uc
                    _viewmodel.UnSetCurrentTask();
                    editTaskControl.Focus(FocusState.Keyboard);
                }
            }
            catch { }
        }
      
        private void FlowCalendar_CalendarViewDayItemChanging_1(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {

        }

        private async void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {

                //MessageDialog ms = new MessageDialog("key down");
                //await ms.ShowAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void NewTaskTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                if (e.Key == Windows.System.VirtualKey.Enter)
                {
                    task t = new task();
                    t.task_name = NewTaskTextBox.Text;
                    t.task_deadline = (FlowCalendar.SelectedDates[0]).LocalDateTime;
                    t.folder_id = _viewmodel.AllFolders.First().folder_id;
                    _viewmodel.AddTask(t);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
