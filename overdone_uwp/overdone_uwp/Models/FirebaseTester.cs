using System;
using System.Collections.Generic;
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
                folder_id = 213,
                folder_name = "Regular",
                folder_color = 324234324
            };

            task t = new task
            {
                folder_id = 213,
                task_name = "My task",
                task_id = 2,
                task_deadline = DateTime.Now
            };


            _adapter.PushUser(user);


            _adapter.PushFolder(f, user);
            _adapter.PushTask(t, user);
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
        }
    }

}
