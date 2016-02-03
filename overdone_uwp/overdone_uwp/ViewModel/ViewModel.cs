using overdone_uwp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace overdone_uwp.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged 
    {
        private static AppViewModel _current;        
        private static MainPage _rootpage ;
        ObservableCollection<task> AllTasks { get; set; }
        ObservableCollection<task> FolderTasks { get; set; }
        ObservableCollection<folder> AllFolders { get; set; }
        DBManager DB = new DBManager();

        private AppViewModel()
        {
            try
            {               
                
                AllTasks = new ObservableCollection<task>();
            }
            catch { }
        }
        public static AppViewModel GetViewModel()
        {
            try
            {
                return _current;
            }
            catch { _current = new AppViewModel();
                return _current;
            }
        }

        internal static void SetRootPage(MainPage mainPage)
        {
            try
            {
                _rootpage = mainPage;   
            } catch { }

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


        public void Navigate(Page RootPage)
        {
            try
            {
                
            }
            catch { }
        }
    }
}
