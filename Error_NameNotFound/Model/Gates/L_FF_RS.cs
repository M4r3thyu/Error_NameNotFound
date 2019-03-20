using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Error_NameNotFound.ViewModel;

namespace Error_NameNotFound.Model
{
    class L_FF_RS : LogicGates
    {
        public FF_RS v_FF_RS;
        public L_FF_RS(int id, FF_RS v_FF_RS) : base(2, 2,id) // input 0=S, 1=R
        {
            this.v_FF_RS = v_FF_RS;
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
            for (int i = 0; i < 2; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[1] && input[2])
            {
                output[0] = false;
                output[1] = false;
            }
            else
            {
                if (input[1])
                {
                    output[0] = false;
                }
                else
                {
                    if (input[0])
                        output[0] = true;
                }
                output[1] = !output[0];
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_FF_RS.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}