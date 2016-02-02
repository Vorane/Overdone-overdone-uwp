using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using overdone_uwp.Views;
using Windows.UI.Xaml.Controls;
using overdone_uwp.Models;
using System.Collections.ObjectModel;

namespace overdone_uwp.ViewModel
{
    //class: controls the home view
    class HomeViewModel : BaseViewModel<Home>
    {
        public Grid _calendar_grid;
        double _calendar_panel_height;
        public double original_height;
        public CalendarView calendar;
        private DateTimeOffset _current_date;
        private ObservableCollection<Models.task> _taskList;

        public HomeViewModel(Home view) : base(view)
        {
            TestModel();
            _view.DataContext = this;       
        }

        // function: testing the model, no functional use
        private void TestModel()
        {
            _taskList = new ObservableCollection<task>();

            for(int i = 0; i < 15; i++)
            {
                task _task = new task();
                _task.task_details = i + " testing the model.";
                _task.task_name = i + " test";
                _taskList.Add(_task);
            }
        }

        public ObservableCollection<Models.task> TaskList
        {
            get
            {
                return _taskList;
            }
        }

        public DateTimeOffset CurrentDate
        {
            get
            {
                return _current_date;
            }
            set
            {
                _current_date = value;
            }
        }

        public void SetCalendar(CalendarView _calendar)
        {
            calendar = _calendar;
        }

        public  string Header
        {
            get
            {
                return "Home";
            }
        }
        public double CalendarPanelHeight
        {
            get
            {

                return _calendar_panel_height;
            }
            set
            {
                _calendar_panel_height = value;
                if (_calendar_grid != null)
                    _calendar_grid.Height = value;
              
            }
        }


        /* Calendar Height control stuff */

        public void ChangeCalendarHeight()
        {

            // Uncomment if using 2 weeks in view instead, has animations and much simpler logic
            /*
            if(calendar.NumberOfWeeksInView == 2)
            {
               calendar.NumberOfWeeksInView = 6;
            }
            else
            {
                calendar.NumberOfWeeksInView = 2;
                calendar.SetDisplayDate(_current_date);
            }
            */

            // Use if using 1 week in view, no animations
            if (_calendar_grid.Height == original_height)
            {
                _calendar_grid.Height = original_height / 6;
                calendar.NumberOfWeeksInView = 2;

                calendar.SetDisplayDate(_current_date);
            }
            else
            {
                _calendar_grid.Height = original_height;
                calendar.NumberOfWeeksInView = 6;
                calendar.SetDisplayDate(_current_date);
            }


        }
    }
}
