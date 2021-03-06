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
    class L_FF_DC_c : LogicGates
    {
        public FF_DC_c v_FF_DC_c;
        public L_FF_DC_c(int id, FF_DC_c v_FF_DC_c) : base(2, 2,id) // input 0=D, 1=C
        {
            this.v_FF_DC_c = v_FF_DC_c;
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            for (int i = 0; i < 2; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[1])
            {
                if (input[0])
                    output[0] = true;
                else
                    output[0] = false;
                output[1] = !output[0];
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_FF_DC_c.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}
