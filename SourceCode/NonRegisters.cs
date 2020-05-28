using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceCode
{
    public class NonRegisters : Exception
    {
        public NonRegisters(string message) : base(message)
        {
        }
    }
}
