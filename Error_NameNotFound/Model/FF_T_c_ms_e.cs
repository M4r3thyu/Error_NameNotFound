﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class FF_T_c_ms_e : LogicGates
    {
        private bool ms;
        public FF_T_c_ms_e(Point position) : base(1, 2, position) // input 0=T
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[0])
                ms = true;
            else
            {
                if (ms)
                {
                    ms = false;
                    output[0] = output[1];
                    output[1] = !output[0];
                }
            }
        }
    }
}
