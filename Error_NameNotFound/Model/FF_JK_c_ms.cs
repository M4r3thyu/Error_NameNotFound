using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;


namespace Error_NameNotFound.Model
{
    class FF_JK_c_ms : LogicGates
    {
        private bool ms;
        public FF_JK_c_ms(int id) : base(3, 2,id) // input 0=J, 1=K, 2=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[2])
                ms = true;
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
        }
    }
}
