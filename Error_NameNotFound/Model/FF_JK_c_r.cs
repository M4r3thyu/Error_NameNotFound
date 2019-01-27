﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class FF_JK_c_r : LogicGates
    {
        public FF_JK_c_r(int id) : base(4, 2,id) // input 0=J, 1=K, 2=C 3=reset
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
        }
        protected override void ChangeOutput()
        {
            if (input[4])
            {
                output[0] = true;
                output[1] = !output[0];
            }
            else
            {
                if (input[2])
                {
                    if (input[0] && input[1])
                        output[0] = output[1];
                    else
                    {
                        if (input[1])
                            output[0] = false;
                        if (input[0])
                            output[0] = true;
                    }
                    output[1] = !output[0];
                }
            }
        }
    }
}
