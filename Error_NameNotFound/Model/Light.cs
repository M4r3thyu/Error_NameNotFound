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
    class Light : LogicGates
    {
        public Light(Point position) : base(1, 1, position)         //Output 1 = Licht an
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
