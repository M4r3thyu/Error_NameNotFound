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
    class L_FF_JK_c_s_r : LogicGates
    {
        public FF_JK_c_s_r v_FF_JK_c_s_r;
        public L_FF_JK_c_s_r(int id, FF_JK_c_s_r v_FF_JK_c_s_r) : base(5, 2,id) // input 0=J, 1=K, 2=C 3=set 4=reset
        {
            this.v_FF_JK_c_s_r = v_FF_JK_c_s_r;
            for (int i = 0; i < 5; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[4])
            {
                output[0] = true;
                output[1] = !output[0];
            }
            else
            {
                if (input[2])
                {
                    output[0] = false;
                    output[1] = !output[0];
                }
                else
                {
                    if (input[3])
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
                        output[1] = !output[0];
                    }
                }
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_FF_JK_c_ms_s_r.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}