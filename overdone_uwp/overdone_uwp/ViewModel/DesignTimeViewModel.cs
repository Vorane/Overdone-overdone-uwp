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
        public ObservableCollection<task> AllTasks
        {
            get
            {
                _AllTask = new ObservableCollection<task>();
                _AllTask.Add(new task
                {
                    task_id = 1,
                    task_deadline = DateTime.Now,

                    folder_id = 1,
                    task_details = "Task Details",
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
                    task_details = "Task Details",
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
                    task_details = "Task Details",
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
                    task_details = "Task Details",
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
                    task_details = "Task Details",
                    task_favourite = true,
                    task_isroutine = false,
                    task_name = "Task",
                    task_status = false
                });
                return _AllTask;
            }
            set { }
        }

        public ObservableCollection<task> FolderTasks
        {
            get
            {
                _AllTask = new ObservableCollection<task>();
                _AllTask.Add(new task
                {
                    task_id = 1,
                    task_deadline = DateTime.Now,

                    folder_id = 1,
                    task_details = "Task Details",
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
                    task_details = "Task Details",
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
                    task_details = "Task Details",
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
                    task_details = "Task Details",
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
                    task_details = "Task Details",
                    task_favourite = true,
                    task_isroutine = false,
                    task_name = "Task",
                    task_status = false
                });
                return _AllTask;
            }
        }
        public ObservableCollection<folder> AllFolders
        {
            get
            {
                ObservableCollection<folder> allFolders = new ObservableCollection<folder>();

                allFolders.Add(new folder
                {
                    folder_name = "Folder 1",


                });

                allFolders.Add(new folder
                {
                    folder_name = "Folder 2",


                });

                allFolders.Add(new folder
                {
                    folder_name = "Folder 3",


                });

                allFolders.Add(new folder
                {
                    folder_name = "Folder 4",


                });
                return allFolders;
            }
        }
        public folder CurrentFolder { get; set; }
        public DesignTimeViewModel()
        { }
        private task _current_task;
        public task CurrentTask
        {
            get
            {
                _current_task = new task();
                _current_task.task_name = "some new task";
                _current_task.folder_id = 1;
                _current_task.task_deadline = DateTime.Now;
                _current_task.task_details = "bla bla bla";
                return _current_task;
            }
            set { }
        }
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
