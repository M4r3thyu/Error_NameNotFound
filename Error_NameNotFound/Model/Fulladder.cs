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
    class Fulladder : LogicGates
    {
        public Fulladder(Point position) : base(3, 2, position) // input 0=a 1=b 2=Cin output 0=S 1=Cout
        { }
        protected override void ChangeOutput()
        {
            if (input[0] && input[1] && input[2])
            {
                output[0] = true;
                output[1] = true;
            }
            if (!input[0] && input[0] && input[2] || input[0] && !input[1] && input[2] || input[0] && input[1] && !input[2])
            {
                output[0] = false;
                output[1] = true;
            }
            if (!input[0] && !input[0] && input[2] || !input[0] && input[1] && !input[2] || input[0] && !input[1] && !input[2])
            {
                output[0] = true;
                output[1] = false;
            }
            if (!input[0] && !input[1] && !input[2])
            {
                output[0] = false;
                output[1] = false;
            }
        }
    }
}
