using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class L_FF_T_c_ms_e_s_r : LogicGates
    {
        private bool ms;
        public L_FF_T_c_ms_e_s_r(int id) : base(3, 2,id) // input 0=T 1=set 2=Reset
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[2])
            {
                output[0] = true;
                output[1] = !output[0];
            }
            else
            {
                if (input[1])
                {
                    output[0] = false;
                    output[1] = !output[0];
                }
                else
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
                }
            }
        }
    }
}
