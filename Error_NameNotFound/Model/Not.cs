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
    class Not : LogicGates
    {
        public Not() : base(1, 1)
        {
            output[0] = !input[0];                                  //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            output[0] = !input[0];
            Output = output;
        }
    }
}
