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
        #endregion
    }
}
