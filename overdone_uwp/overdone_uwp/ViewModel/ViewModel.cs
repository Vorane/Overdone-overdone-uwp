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
    class ViewModel : INotifyPropertyChanged 
    {
        ObservableCollection<task> AllTasks { get; set; }
        ObservableCollection<task> FolderTasks { get; set; }
        ObservableCollection<folder> AllFolders { get; set; }
        DBManager DB = new DBManager();

        public ViewModel()
        {
            try
            {
                AllTasks = new ObservableCollection<task>();
            }
            catch { }
        }


        #region task List managers
        //function: create a new task
        public void AddTask(task NewTask)
        {
            try
            {
                NewTask.PropertyChanged += TaskPropertyChanged;
                AllTasks.Add(NewTask);
                NotifyPropertyChanged("AllTasks");
                DB.AddTask(NewTask);
            }
            catch { }
        }
        //function: update a task
        public void UpdateTask(task SelectedTask)
        {
            try
            {
                
            }
            catch { }
        }
        #endregion

        #region Folder Managers
        public void AddFolder(folder NewFolder)
        {
            try
            {
                AllFolders.Add(NewFolder);
                NotifyPropertyChanged("AllFolders");
                DB.AddFolder(NewFolder);
            }
            catch { }
        }
        #endregion

        #region List Managers
        //function: initialize items of list and property listener
        public void InitializeAllLists()
        {
            try
            {
                AllFolders = DB.GetAllFolders();
                AllTasks = DB.GetPendingTasks();
                foreach (task t in AllTasks)
                {
                    t.PropertyChanged += TaskPropertyChanged;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Notify Event Managers
        //variable: event raised when a class property changes
        public event PropertyChangedEventHandler PropertyChanged;
        //function: default property for to notify property
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //function event handler when a task is modified
        private void TaskPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "task_status")
                {                    
                }
            }
            catch { }
        }
        #endregion



    }
}
