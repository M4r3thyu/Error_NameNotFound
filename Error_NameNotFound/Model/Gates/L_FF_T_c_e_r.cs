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
    class L_FF_T_c_e_r:LogicGates
    {
        public FF_T_c_e_r v_FF_T_c_e_r;
        private bool ms;
        public L_FF_T_c_e_r(int id, FF_T_c_e_r v_FF_T_c_e_r) : base(2, 2,id) // input 0=T 1=Reset
        {
            this.v_FF_T_c_e_r = v_FF_T_c_e_r;
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
            {
                output[0] = false;
                output[1] = !output[0];
            }
            else
            {
                if (input[0])
                    if (!ms)
                    {
                        ms = true;
                        output[0] = output[1];
                        output[1] = !output[0];
                    }
                    else
                        ms = false;
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            //v_FF_T_c_e_r.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}