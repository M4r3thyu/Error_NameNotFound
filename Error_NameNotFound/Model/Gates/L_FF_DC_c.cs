using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class L_FF_DC_c : LogicGates
    {
        public L_FF_DC_c(int id) : base(2, 2,id) // input 0=D, 1=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
        }
        protected override void ChangeOutput()
        {
            if (input[1])
            {
                if (input[0])
                    output[0] = true;
                else
                    output[0] = false;
                output[1] = !output[0];
            }
        }
    }
}
