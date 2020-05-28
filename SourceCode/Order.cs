using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceCode
{
    class Order
    {
        private int idorder;
        private DateTime date;
        private int idproduct;
        private int idaddress;

        public Order()
        {
        }

        public int Idorder
        {
            get => idorder;
            set => idorder = value;
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public int Idproduct
        {
            get => idproduct;
            set => idproduct = value;
        }

        public int Idaddress
        {
            get => idaddress;
            set => idaddress = value;
        }
    }
}
