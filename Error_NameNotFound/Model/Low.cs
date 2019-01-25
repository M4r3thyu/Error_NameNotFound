using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class Low : LogicGates
    {
        public Low() : base(0, 1)
        {
            output[0] = false;
        }
        override protected void ChangeOutput()
        {
            output[0] = false;
            Output = output;
        }
    }
}
