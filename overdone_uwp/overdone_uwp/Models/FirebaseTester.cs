using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overdone_uwp.Models
{
    public class FirebaseTester
    {
        FireBaseAdapter _adapter;
        public FirebaseTester()
        {

            _adapter = new FireBaseAdapter("9g17kqFUHkAwmQLbWEc1KkNWLGJTAXT0GmaG446D", "https://burning-torch-4827.firebaseio.com/");
            GetTest();
        }


        public void PushTest()
        {
            User user = new User
            {
                Email = "erico@yahoo.com",
                Password = "dfdsfdsfdsf"
            };

            folder f = new folder
            {
                folder_id = 23,
                folder_name = "Regular",
                folder_color = 324234324
            };

            task t = new task
            {
                folder_id = 2,
                task_name = "My task",
                task_id = 2,
                task_deadline = DateTime.Now
            };


            /* _adapter.PushUser(user); */

            /*
            for(int i = 0; i < 5; i++)
            {
                folder fold = new folder { 
                    folder_id = DateTime.Now.Second + DateTime.Now.Minute + i,
                    folder_name = DateTime.Now.Second + " - " + DateTime.Now.Minute + i,
                    folder_color = 324234324
                };
            _adapter.PushFolder( fold, user);
            }
            */
            

            /*_adapter.PushFolder(f, user);*/
            /*_adapter.PushTask(t, user); */
        }

        public void GetTest()
        {
            User user = new User
            {
                Email = "erico@yahoo.com",
                Password = "dfdsfdsfdsf"
            };

            folder f = _adapter.GetFolder(213, user);

            User u = _adapter.GetUser("sdfsdfs");
            try
            {
                var test = _adapter.GetAllFolders(user);
            }
            catch
            {

            }

            try
            {
                ObservableCollection<task> test3 = _adapter.GetAllFolderTasks(user, 2);
            }
            catch
            {

            }

            try
            {
                var tes2 = _adapter.GetAllTasks(user);
            }
            catch
            {

            }
            
        }
    }

}
