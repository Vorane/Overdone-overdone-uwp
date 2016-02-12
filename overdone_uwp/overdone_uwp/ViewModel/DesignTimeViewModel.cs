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

        public ObservableCollection<task> FolderTaskList
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
                ObservableCollection<folder> allFolders = new ObservableCollection<folder> ();

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
