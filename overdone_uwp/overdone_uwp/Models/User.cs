using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overdone_uwp.Models
{
    public class User
    {
        private String _email;
        private String _password;

        public String Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

    }
}
