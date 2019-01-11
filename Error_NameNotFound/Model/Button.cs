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
    class Button : LogicGates
    {
        public Button(Point position) : base(1, 1, position)            //Input 1 = Taster getrueckt
        {
            output[0] = false;
        }
        override protected void ChangeOutput()
        {
            if (output[0] == true)
                output[0] = false;
            else
                output[0] = true;
            Output = output;
        }
    }
}
