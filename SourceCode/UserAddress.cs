using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCode
{
    class UserAddress
    {
        private int idaddress;
        private int iduser;
        private string address;
        public UserAddress()
        {
        }

        public int Idaddress
        {
            get => idaddress;
            set => idaddress = value;
        }

        public int Iduser
        {
            get => iduser;
            set => iduser = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }
    }
}
