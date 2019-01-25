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
    class High : LogicGates
    {
        public High() : base(0, 1)
        {
            output[0] = true;
        }
        override protected void ChangeOutput()
        {
            output[0] = true;
            Output = output;
        }
    }
}
