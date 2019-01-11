using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class FF_T_c_e_s_r : LogicGates
    {
        private bool ms;
        public FF_T_c_e_s_r(Point position) : base(3, 2, position) // input 0=T 1=set 2=Reset
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
                        if (!ms)
                        {
                            ms = true;
                            output[0] = output[1];
                            output[1] = !output[0];
                        }
                        else
                            ms = false;
                }
            }
        }
    }
}
