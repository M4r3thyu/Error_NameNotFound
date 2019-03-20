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
    class L_FF_JK_c_ms_r : LogicGates
    {
        public FF_JK_c_ms_r v_FF_JK_c_ms_r;
        private bool ms;
        public L_FF_JK_c_ms_r(int id, FF_JK_c_ms_r v_FF_JK_c_ms_r) : base(5, 2,id) // input 0=J, 1=K, 2=C 3=reset
        {
            this.v_FF_JK_c_ms_r = v_FF_JK_c_ms_r;
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
            for (int i = 0; i < 5; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[3])
            {
                output[0] = true;
                output[1] = !output[0];
            }
            else
            {
                if (ms)
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
                    ms = false;
                    output[1] = !output[0];
                }
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_FF_JK_c_ms_r.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}