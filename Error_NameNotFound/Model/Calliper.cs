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
    class Calliper : LogicGates
    {
        public Calliper(int id) : base(1, 1,id)          //Input 1 = Taster getrueckt
        {
            output = input;
        }
        override protected void ChangeOutput()
        {
            output = input;
            Output = output;
        }
    }
}
