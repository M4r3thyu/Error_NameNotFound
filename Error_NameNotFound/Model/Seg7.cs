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
    class Seg7 : LogicGates
    {                                                                   // Output[] 1 = Licht an
        public Seg7(int id) : base(7, 7,id)              //   0_
        {                                                               // 1|2_|3
            output = input;                                             // 4|5_|6
        }
        override protected void ChangeOutput()
        {
            output = input;
            Output = output;
        }
    }
}
