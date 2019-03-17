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
    class L_Light : LogicGates
    {
        public Light v_Light;
        public L_Light(int id, Light v_Light) : base(1, 1,id)         //Output 1 = Licht an
        {
            this.v_Light = v_Light;
            for (int i = 0; i < 1; i++)
            {
                this.input[i] = false;
            }
            output[0] = input[0];
        }
        override protected void ChangeOutput()
        {
            output[0] = input[0];
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            //v_Light.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}