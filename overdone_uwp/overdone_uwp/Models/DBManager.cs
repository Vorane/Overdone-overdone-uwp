using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace overdone_uwp.Models
{
    public class DBManager
    {
        //path to the file and GLobal SQLITe connection variable
        private static string DBPath { get; set; }
        private static SQLite.Net.SQLiteConnection DBConn { get; set; }

        public DBManager()
        {
            DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "overdone.sqlite");
            DBConn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath);

            if (!CheckTable())
            {
                Debug.WriteLine("Unable to Create tables");
            }
        }


        #region Table Managers
        //@evans
        //function: check that all tables exist
        private bool CheckTable()
        {
            try
            {
                DBConn.CreateTable<task>();
                DBConn.CreateTable<folder>();
                DefaultFolder();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //function: ensure there is always a default folder
        private void DefaultFolder()
        {
            try
            {
                folder f = new folder();
                f.folder_id = 1;
                f.folder_name = "regular";
                f.folder_color = 0xFFFFA500;
                var existingfolder = DBConn.Query<folder>("SELECT * FROM folder where folder_id = " + f.folder_id).FirstOrDefault(); ;
                if (existingfolder == null)
                {
                    DBConn.Insert(f);
                }
            }
            catch { }
        }
        #endregion

        #region Task Handlers
        //function: add a new task
        public void AddTask(task NewTask)
        {
            try
            {
                DBConn.Insert(NewTask);
            }
            catch
            {
            }

        }
        //function: get a list of all tasks
        public task GetSpecificTask(int TaskId)
        {
            try
            {
                return DBConn.Table<task>().Where(x => x.task_id == TaskId).FirstOrDefault();

            }
            catch { return null; }
        }
        //function: get list of all task
        public ObservableCollection<task> GetAllTasks()
        {
            try
            {
                return new ObservableCollection<task>(DBConn.Table<task>());
            }
            catch
            {
                return null;
            }
        }
        //function: get tasks whose status is false
        public ObservableCollection<task> GetPendingTasks()
        {
            try
            {
                return new ObservableCollection<task>(DBConn.Table<task>().Where(x => x.task_status == false));
            }
            catch { return null; }
        }
        //function: get tasks by folder
        public ObservableCollection<task> GetTasksByFolder(folder SelectedFolder)
        {
            try
            {
                return new ObservableCollection<task>(DBConn.Table<task>().Where(x => x.folder_id == SelectedFolder.folder_id));
            }
            catch { return null; }
        }
        //function: get Task due by a date
        public ObservableCollection<task> GetTaskByDate(DateTime SelectedDate)
        {
            try
            {
                return new ObservableCollection<task>(DBConn.Table<task>().Where(x => x.task_deadline.Date == SelectedDate.Date));
            }
            catch
            {
                return null; 
            }
        }
        //function: get pending tasks by a due date
        public ObservableCollection<task> GetPendingTasksByDate(DateTime SelectedDate)
        {
            try
            {
                return new ObservableCollection<task>(DBConn.Table<task>().Where((x => (x.task_deadline.Date == SelectedDate.Date) && (x.task_status == false))));
            }
            catch { return null;  }
        }
        //function: get tasks that are routines
        public ObservableCollection<task> GetRoutiens()
        {
            try
            {
                return new ObservableCollection<task>(DBConn.Table<task>().Where(x => x.task_isroutine == true));
            }
            catch { return null; }
        }
        //function: update task
        public void UpdateTask(task UpdatedTask)
        {
            try
            {
                task ExistingTask = DBConn.Query<task>("SELECT * FROM task WHERE task_id = " + UpdatedTask.task_id).FirstOrDefault();
                if (ExistingTask != null)
                {
                    DBConn.Update(UpdatedTask);
                }
            }
            catch { }
        }
        //function: Delete task
        public void DeleteTask(task DeletedTask)
        {
            try
            {
                DBConn.Delete(DeletedTask);
            }
            catch { }
        }
        //function: Delete All tasks
        public void DeleteAllTasks()
        {
            try
            {
                DBConn.DropTable<task>();
                DBConn.CreateTable<task>();
            }
            catch
            {
            }
        }
        #endregion

        #region Folder Handlers
        //function: Adds a new folder
        public void AddFolder(folder NewFolder)
        {
            try
            {
                DBConn.Insert(NewFolder);
            }
            catch
            {

            }
        }
        //function: Gets list of all folders
        public ObservableCollection<folder> GetAllFolders()
        {
            try
            {
                return new ObservableCollection<folder>(DBConn.Table<folder>());
            }
            catch
            {
                return null;
            }
        }
        //function: Update Folder
        public void UpdateFolder(folder UpdatedFolder)
        {
            try
            {
                DBConn.Update(UpdatedFolder);
            }
            catch { }
        }
        //function: Delete Folder
        public void DeleteFolder(folder DeletedFolder)
        {
            try
            {
                DBConn.Delete(DeletedFolder);
            }
            catch { }

        }
        //function: Delete All Folders
        public void DeleteAllFolders()
        {
            try
            {
                DBConn.DropTable<folder>();
                DBConn.CreateTable<folder>();
                DefaultFolder();
            }
            catch { }
        }
        #endregion
    }
}
