using FireSharp;
using FireSharp.Config;
using FireSharp.Exceptions;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using Newtonsoft;
using Newtonsoft.Json;

namespace overdone_uwp.Models
{
    public class FireBaseAdapter
    {
        public IFirebaseClient _client;
        public FireBaseAdapter(String secret, String basepath)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = secret,
                BasePath = basepath
            };
            IFirebaseClient client = new FirebaseClient(config);
            _client = client;

        }

        #region Pushing Methods
        public bool PushUser(User u)
        {
            try
            {

                SetResponse response = _client.Set("/data/users/"+ RemoveEmailCharacters( u.Email) +"/", u);

                string Body  = response.Body;
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }

        }

        public bool PushTask(task t, User u)
        {
            try
            {

                _client.Set("/data/users/"+ RemoveEmailCharacters(u.Email) + "/folders/"+t.folder_id+"/tasks/"+t.task_id, t);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }

        public bool PushFolder(folder f, User u)
        {
            try
            {

                _client.Set("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + f.folder_id, f);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }

        #endregion

        #region Update Methods
        public bool UpdateFolder(folder f, User u)
        {
            try
            {

                _client.Update("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + f.folder_id, f);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }

        public bool UpdateTask(task t, User u)
        {
            try
            {
                _client.Update("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + t.folder_id + "/tasks/" + t.task_id, t);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }

        #endregion

        #region Deleting Task and overloads
        public bool DeleteTask(task t, User u)
        {
            try
            {
                _client.Delete("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + t.folder_id + "/tasks/" + t.task_id);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }

        public bool DeleteTask(int task_id, int folder_id, User u)
        {
            try
            {
                _client.Delete("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + folder_id + "/tasks/" + task_id);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }

        public bool DeleteTask(int task_id, folder f, User u)
        {
            try
            {
                _client.Delete("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + f.folder_id + "/tasks/" + task_id);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }
        #endregion

        #region Deleting Folder and Overloads
        public bool DeleteFolder(folder f, User u)
        {
            try
            {
                _client.Delete("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + f.folder_id);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }

        public bool DeleteFolder(int folder_id, User u)
        {
            try
            {
                _client.Delete("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + folder_id);
                return true;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return false;
            }
        }
        #endregion

        #region GetUser and overloads
        public User GetUser(String email)
        {

            try
            {
                FirebaseResponse response = _client.Get("/data/users/" + RemoveEmailCharacters(email) );

                /* convert the response from JSON to task */
                User user = JsonConvert.DeserializeObject<User>(response.Body);

                return user;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return null;
            }
        }

        public User GetUser(User user)
        {

            try
            {
                FirebaseResponse response = _client.Get("/data/users/" + RemoveEmailCharacters(user.Email) );

                /* convert the response from JSON to task */
                user = JsonConvert.DeserializeObject<User>(response.Body);

                return user;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return null;
            }
        }

        #endregion

        #region GetTask and overloads
        public task GetTask( task t, User u)
        {
            try
            {
                FirebaseResponse response = _client.Get("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + t.folder_id + "/tasks/" + t.task_id);

                /* convert the response from JSON to task */
                t = JsonConvert.DeserializeObject<task>(response.Body);

                return t;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return null;
            }
        }

        public task GetTask(int task_id, int folder_id, User u)
        {
            try
            {
                FirebaseResponse response = _client.Get("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + folder_id + "/tasks/" + task_id);

                /* convert the response from JSON to task */
                task t = JsonConvert.DeserializeObject<task>(response.Body);

                return t;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return null;
            }
        }

        public task GetTask(int task_id, folder f, User u)
        {
            try
            {
                FirebaseResponse response = _client.Get("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + f.folder_id + "/tasks/" + task_id);

                /* convert the response from JSON to task */
                task t = JsonConvert.DeserializeObject<task>(response.Body);

                return t;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return null;
            }
        }


        #endregion

        #region GetFolder and overloads
        public folder GetFolder(int id, User u)
        {
            try
            {
                FirebaseResponse response = _client.Get("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + id);

                /* convert the response from JSON to task */
                folder f = JsonConvert.DeserializeObject<folder>(response.Body);
                return f;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return null;
            }
        }

        public folder GetFolder(folder f, User u)
        {
            try
            {
                FirebaseResponse response = _client.Get("/data/users/" + RemoveEmailCharacters(u.Email) + "/folders/" + f.folder_id);

                /* convert the response from JSON to task */
                f = JsonConvert.DeserializeObject<folder>(response.Body);
                
                return f;
            }
            catch (FirebaseException e)
            {
                e.ToString();
                return null;
            }
        }

        #endregion

        #region Exist methods

        public bool UserExists(String email)
        {
            return GetUser(email) == null ? false : true;
        }

        public bool UserExists(User user)
        {
            return GetUser(user) == null ? false : true;
        }

        #endregion

        public void Delete(String path)
        {
            _client.Delete(path);
        }

        private String RemoveEmailCharacters(String email)
        {
    
            return email.Replace('@', '_').Replace('.','_');
        } 
    }
}
