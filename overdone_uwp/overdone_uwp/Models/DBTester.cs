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
            //UpdateTaskTest();
            //DeleteTaskTest();
            //FolderTest();
            //UpdateFolder();
            //DeleteFolder();
                
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
        public void UpdateTaskTest()
        {
            task t = new task();
            t.task_id = 2;
            t.task_deadline = DateTime.Now;
            t.task_details = "Task 222";
            t.task_favourite = true;
            t.task_isroutine = false;
            t.task_status = false;
            t.task_remindtime = DateTime.Now;

            DB1.UpdateTask(t);
            ObservableCollection<task> alltasks = DB1.GetAllTasks();
        }
        public void DeleteTaskTest()
        {
            ObservableCollection<task> alltasks = DB1.GetAllTasks();
            task t = new task();
            t.task_id = 4;
            t.task_deadline = DateTime.Now;
            t.task_details = "Task 222";
            t.task_favourite = true;
            t.task_isroutine = false;
            t.task_status = false;
            t.task_remindtime = DateTime.Now;

            DB1.DeleteTask(t);
            alltasks = DB1.GetAllTasks();
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
        public void UpdateFolder()
        {

            folder f = new folder();
            f.folder_id = 2; 
            f.folder_name = "Toodo App";
            f.folder_color = 0xFFFFA500;

            DB1.UpdateFolder(f);
            ObservableCollection<folder> Allfolders = DB1.GetAllFolders();
        }
        public void DeleteFolder()
        {
            ObservableCollection<folder> Allfolders = DB1.GetAllFolders();
            folder f = new folder();
            f.folder_id = 2;

            DB1.DeleteFolder(f);
            Allfolders = DB1.GetAllFolders();

        }
    }
}
