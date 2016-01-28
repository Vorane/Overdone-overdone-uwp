using overdone_uwp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overdone_uwp.ViewModel
{
    class DesignTimeViewModel : INotifyPropertyChanged
    {
        ObservableCollection<task> _AllTask;
        ObservableCollection<task> AllTasks
        {
            get
            {
                _AllTask = new ObservableCollection<task>();
                _AllTask.Add(new task
                {
                    task_id = 1,
                    task_deadline = DateTime.Now,
                    folder_id = 1,
                    task_details = "",
                    task_favourite = true,
                    task_isroutine = false,
                    task_name = "Task",
                    task_status = false
                });
                _AllTask.Add(new task
                {
                    task_id = 1,
                    task_deadline = DateTime.Now,
                    folder_id = 1,
                    task_details = "",
                    task_favourite = true,
                    task_isroutine = false,
                    task_name = "Task",
                    task_status = false
                });
                _AllTask.Add(new task
                {
                    task_id = 1,
                    task_deadline = DateTime.Now,
                    folder_id = 1,
                    task_details = "",
                    task_favourite = true,
                    task_isroutine = false,
                    task_name = "Task",
                    task_status = false
                });
                _AllTask.Add(new task
                {
                    task_id = 1,
                    task_deadline = DateTime.Now,
                    folder_id = 1,
                    task_details = "",
                    task_favourite = true,
                    task_isroutine = false,
                    task_name = "Task",
                    task_status = false
                });
                _AllTask.Add(new task
                {
                    task_id = 1,
                    task_deadline = DateTime.Now,
                    folder_id = 1,
                    task_details = "",
                    task_favourite = true,
                    task_isroutine = false,
                    task_name = "Task",
                    task_status = false
                });
                return _AllTask;
            }
            set { }
        }

        public DesignTimeViewModel()
        { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
