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
    class L_Not : LogicGates
    {
        public NOT v_Not;
        public L_Not(int id, NOT v_Not) : base(1, 1,id)
        {
            this.v_Not = v_Not;
            output[0] = !input[0];                                  //output[0] = Q output[1] = !Q
            for (int i = 0; i < 1; i++)
            {
                this.input[i] = false;
            }
        }
        override protected void ChangeOutput()
        {
            output[0] = !input[0];
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_Not.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}