using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCode
{
    public class User
    {
        private int iduser;
        private string fullname;
        private string username;
        private string password;
        private bool usertype;

        public User()
        {
        }

        public int Iduser
        {
            get => iduser;
            set => iduser = value;
        }

        public string Fullname
        {
            get => fullname;
            set => fullname = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public bool Usertype
        {
            get => usertype;
            set => usertype = value;
        }
    }
}
