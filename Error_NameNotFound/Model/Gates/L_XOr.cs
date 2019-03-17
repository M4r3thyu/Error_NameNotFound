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
    class L_Xor : LogicGates
    {
        public XOR v_Xor;
        public L_Xor(int input, int id, XOR v_Xor) : base(2, 2,id)      //Output[0] = Normal [1] = Negiert
        {
            this.v_Xor = v_Xor;
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
            for (int i = 0; i < 2; i++)
            {
                this.input[i] = false;
            }
        }
        override protected void ChangeOutput()
        {
            if (input[0] != input[1])
                output[0] = true;
            else
                output[0] = false;
            output[1] = !output[0];
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_Xor.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}
