using overdone_uwp.Models;
using overdone_uwp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace overdone_uwp.UserControls
{
    public sealed partial class CalendarControl : CalendarView
    {
        CalendarView _calendar;
        Grid _calendarGrid;
        DateTimeOffset _currentDate;
        AppViewModel _viewmodel;
        Grid _openContext;
        double _originalHeight;
        public CalendarControl()
        {
            DataContext = _viewmodel = AppViewModel.GetViewModel();
            _currentDate = DateTime.Now;
            this.InitializeComponent();
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

        private void ChangeCalendarHeight()
        {
            try
            {
                if (_calendarGrid.ActualHeight == _originalHeight || _originalHeight == Double.NaN)
                {
                    _calendarGrid.Height = _originalHeight / 4;
                    _calendar.NumberOfWeeksInView = 2;

                    _calendar.SetDisplayDate(_currentDate);
                }
                else
                {
                    _calendarGrid.Height = _originalHeight;
                    _calendar.NumberOfWeeksInView = 4;
                    _calendar.SetDisplayDate(_currentDate);
                }
            }
            catch { }
        }
        #endregion
    }
}
