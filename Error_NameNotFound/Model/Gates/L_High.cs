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
    class L_High : LogicGates
    {
        public High v_High;
        public L_High(int id, High v_High) : base(0, 1,id)
        {
            this.v_High = v_High;
            output[0] = true;
            for (int i = 0; i < 0; i++)
            {
                this.input[i] = false;
            }
        }
        override protected void ChangeOutput()
        {
            output[0] = true;
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            //v_High.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}