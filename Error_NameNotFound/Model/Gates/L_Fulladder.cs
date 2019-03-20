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
    class L_Fulladder : LogicGates
    {
        public Fulladder v_Fulladder;
        public L_Fulladder(int id, Fulladder v_Fulladder) : base(3, 2,id) // input 0=a 1=b 2=Cin output 0=S 1=Cout
        {
            this.v_Fulladder = v_Fulladder;
            for (int i = 0; i < 3; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[0] && input[1] && input[2])
            {
                output[0] = true;
                output[1] = true;
            }
            if (!input[0] && input[0] && input[2] || input[0] && !input[1] && input[2] || input[0] && input[1] && !input[2])
            {
                output[0] = false;
                output[1] = true;
            }
            if (!input[0] && !input[0] && input[2] || !input[0] && input[1] && !input[2] || input[0] && !input[1] && !input[2])
            {
                output[0] = true;
                output[1] = false;
            }
            if (!input[0] && !input[1] && !input[2])
            {
                output[0] = false;
                output[1] = false;
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_Fulladder.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}