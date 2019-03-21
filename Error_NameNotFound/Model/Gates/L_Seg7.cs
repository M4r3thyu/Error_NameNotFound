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
    class L_Seg7 : LogicGates
    {                                                                   // Output[] 1 = Licht an
        private Seg7 v_Seg7;
        public L_Seg7(int id, Seg7 v_Seg7) : base(7, 7,id)              //   0_
        {                                                               // 1|2_|3
            this.v_Seg7 = v_Seg7;
            output = input;                                             // 4|5_|6
            for (int i = 0; i < 7; i++)
            {
                this.input[i] = false;
            }
        }
        override protected void ChangeOutput()
        {
            output = input;
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_Seg7.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}
