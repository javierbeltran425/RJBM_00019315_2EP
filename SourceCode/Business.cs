using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCode
{
    class Business
    {
        private int idbusiness;
        private string name;
        private string description;

        public Business()
        {
        }

        public int Idbusiness
        {
            get => idbusiness;
            set => idbusiness = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }
    }
}
