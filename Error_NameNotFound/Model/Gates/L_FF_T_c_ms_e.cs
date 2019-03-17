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
    class L_FF_T_c_ms_e : LogicGates
    {
        public FF_T_c_ms_e v_FF_T_c_ms_e;
        private bool ms;
        public L_FF_T_c_ms_e(int id, FF_T_c_ms_e v_FF_T_c_ms_e) : base(1, 2,id) // input 0=T
        {
            this.v_FF_T_c_ms_e = v_FF_T_c_ms_e;
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
            for (int i = 0; i < 1; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[0])
                ms = true;
            else
            {
                if (ms)
                {
                    ms = false;
                    output[0] = output[1];
                    output[1] = !output[0];
                }
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            //v_FF_T_c_ms_e.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}