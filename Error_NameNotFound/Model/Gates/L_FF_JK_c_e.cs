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
    class L_FF_JK_c_e : LogicGates
    {
        public FF_JK_c_e v_FF_JK_c_e;
        private bool ms;
        public L_FF_JK_c_e(int id, FF_JK_c_e v_FF_JK_c_e) : base(3, 2,id) // input 0=J, 1=K, 2=C
        {
            this.v_FF_JK_c_e = v_FF_JK_c_e;
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
            for (int i = 0; i < 3; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[2])
            {
                if (!ms)
                {
                    if (input[0] && input[1])
                        output[0] = output[1];
                    else
                    {
                        if (input[1])
                            output[0] = false;
                        if (input[0])
                            output[0] = true;
                    }
                    ms = true;
                    output[1] = !output[0];
                }
                else
                {
                    ms = false;
                }
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_FF_JK_c_e.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}