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
    class L_FF_DC_c_ms_s_r : LogicGates
    {
        public FF_DC_c_ms_s_r v_FF_DC_c_ms_s_r;
        private bool ms;
        public L_FF_DC_c_ms_s_r(int id, FF_DC_c_ms_s_r v_FF_DC_c_ms_s_r) : base(4, 2,id) // input 0=D, 1=C 2=set 3=reset
        {
            this.v_FF_DC_c_ms_s_r = v_FF_DC_c_ms_s_r;
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
            for (int i = 0; i < 4; i++)
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
                if (input[2])
                {
                    output[0] = false;
                    output[1] = !output[0];
                }
                else
                {
                    if (input[1])
                        ms = true;
                    else
                    {
                        if (ms)
                        {
                            if (input[0])
                                output[0] = true;
                            else
                                output[0] = false;
                            ms = false;
                            output[1] = !output[0];
                        }
                    }
                }
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            //v_FF_DC_c_ms_s_r.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}