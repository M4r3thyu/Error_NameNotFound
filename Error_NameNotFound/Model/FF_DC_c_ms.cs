using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class FF_DC_c_ms : LogicGates
    {
        private bool ms;
        public FF_DC_c_ms(Point position) : base(2, 2, position) // input 0=D, 1=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
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
        }
    }
}
