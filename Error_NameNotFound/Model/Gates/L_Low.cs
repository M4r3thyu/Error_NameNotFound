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
    class L_Low : LogicGates
    {
        public Low v_Low;
        public L_Low(int id, Low v_Low) : base(0, 1,id)
        {
            this.v_Low = v_Low;
            output[0] = false;
            for (int i = 0; i < 0; i++)
            {
                this.input[i] = false;
            }
        }
        override protected void ChangeOutput()
        {
            output[0] = false;
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            //v_Low.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}