﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class FF_DC_c_s : LogicGates
    {
        public FF_DC_c_s(int id) : base(3, 2,id) // input 0=D, 1=C 2=set
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
        }
        protected override void ChangeOutput()
        {
            if (input[2])
            {
                output[0] = true;
                output[1] = !output[0];
            }
            else
            {
                if (input[1])
                {
                    if (input[0])
                        output[0] = true;
                    else
                        output[0] = false;
                    output[1] = !output[0];
                }
            }
        }
    }
}