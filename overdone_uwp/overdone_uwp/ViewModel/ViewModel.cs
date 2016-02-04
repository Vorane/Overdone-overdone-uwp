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
    public class AppViewModel : INotifyPropertyChanged 
    {
        private static AppViewModel _current;        
        public ObservableCollection<task> AllTasks { get; set; }
        ObservableCollection<task> FolderTasks { get; set; }
        ObservableCollection<folder> AllFolders { get; set; }
        DBManager DB = new DBManager();
        static MainPage _rootpage;

        private AppViewModel()
        {
            try
            {               
                AllTasks = new ObservableCollection<task>();
                AllTasks = DB.GetAllTasks();
            }
            catch { }
        }
        public static AppViewModel GetViewModel()
        {

            return _current = _current == null ? new AppViewModel() : _current;
            

        }

        #region RootPage and Navigation
        public static void SetRootPage(MainPage mainpage)
        {
            _rootpage = mainpage;
        }

        public void NavigateTo<T>()
        {
            _rootpage.NavigateTo<T>();
        }

        public void NavigateTo<T>(object e)
        {
            _rootpage.NavigateTo<T>(e);
        }

        public void NavigateBack()
        {
            _rootpage.NavigateBack();
        }
        #endregion

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
        //function: remove and deleta a task
        public void RemoveTask(task RemovedTask)
        {
            try
            {
                try
                {
                    AllTasks.Remove(RemovedTask);
                    NotifyPropertyChanged("AllTasks");
                }
                catch { }
                try
                {
                    FolderTasks.Remove(RemovedTask);
                    NotifyPropertyChanged("FolderTasks");
                }
                catch { }

                

                DB.DeleteTask(RemovedTask);

            }
            catch
            { }
        }
        #endregion

        #region Folder Managers
        //function: add a new folder
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
        //function: update a specific folder
        public void UpdateFolder(folder UpdatedFolder)
        {
            try
            {
                folder FoundFolder = (folder)AllFolders.Where(x => x.folder_id == UpdatedFolder.folder_id).FirstOrDefault();
                FoundFolder = UpdatedFolder;
                NotifyPropertyChanged("AllFolders");
                DB.UpdateFolder(UpdatedFolder);
            }
            catch
            { }
        }
        //function: remove and delete 
        public void RemoveFolder(folder RemovedFolder)
        {
            try
            {
                try
                {
                    AllFolders.Remove(RemovedFolder);
                    NotifyPropertyChanged("AllFolders");

                }
                catch
                { }

                DB.DeleteFolder(RemovedFolder);
            } catch { }
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
