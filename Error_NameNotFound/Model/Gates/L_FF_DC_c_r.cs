﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Error_NameNotFound.ViewModel;

namespace Error_NameNotFound.Model
{
    class L_FF_DC_c_r : LogicGates
    {
        public FF_DC_c_r v_FF_DC_c_r;
        public L_FF_DC_c_r(int id, FF_DC_c_r v_FF_DC_c_r) : base(3, 2, id) // input 0=D, 1=C 2=reset
        {
            this.v_FF_DC_c_r = v_FF_DC_c_r;
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            for (int i = 0; i < 3; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[2])
            {
                output[0] = false;
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
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_FF_DC_c_r.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}