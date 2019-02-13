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
    class L_Light : LogicGates
    {
        public L_Light(int id) : base(1, 1,id)         //Output 1 = Licht an
        {
            output[0] = input[0];
        }
        override protected void ChangeOutput()
        {
            output[0] = input[0];
            Output = output;
        }
    }
}
