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
    class L_FF_DC_c_ms_e : LogicGates
    {
        public FF_DC_c_ms_e v_FF_DC_c_ms_e;
        private bool ms;
        public L_FF_DC_c_ms_e(int id, FF_DC_c_ms_e v_FF_DC_c_ms_e) : base(2, 2, id) // input 0=D, 1=C
        {
            this.v_FF_DC_c_ms_e = v_FF_DC_c_ms_e;
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
            for (int i = 0; i < 2; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
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
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_FF_DC_c_ms_e.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}