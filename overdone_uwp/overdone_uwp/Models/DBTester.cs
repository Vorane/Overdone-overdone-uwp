using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overdone_uwp.Models
{
    public class DBTester
    {
        //a class to test if the db manager class works without the help of other classes
        DBManager DB1 = new DBManager();

        public DBTester()
        {
            //TaskTest();
            FolderTest();
        }
        public void TaskTest()
        {
            task t = new task() ;            
            t.task_deadline = DateTime.Now;
            t.task_details = "asdfasd";
            t.task_favourite = true;
            t.task_isroutine = false;
            t.task_status = false;
            t.task_remindtime = DateTime.Now;

            DB1.AddTask(t);
            DB1.AddTask(t);
            DB1.AddTask(t);
            DB1.AddTask(t);

            ObservableCollection<task> alltasks = DB1.GetAllTasks();
            
        }
        public void FolderTest()
        {
            folder f = new folder();            
            f.folder_name = "regular";
            f.folder_color = 0xFFFFA500;

            DB1.AddFolder(f);
            DB1.AddFolder(f);
            DB1.AddFolder(f);
            DB1.AddFolder(f);

            ObservableCollection<folder> Allfolders = DB1.GetAllFolders();
        }
    }
}
