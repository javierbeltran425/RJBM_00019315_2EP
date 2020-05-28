using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    class Product
    {
        private int idproduct;
        private int idbusiness;
        private string name;

        public Product()
        {
        }

        public int Idproduct
        {
            get => idproduct;
            set => idproduct = value;
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
    }
}
