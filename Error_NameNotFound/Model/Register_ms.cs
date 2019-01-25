using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class Register_ms : LogicGates
    {
        private bool ms;
        public Register_ms(int input, int output) : base(input, output) // input 0=C, 1=M, 2=R 3=1D
        {
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[2])
            {
                for (int i = 0; i < output.Count; i++)
                {
                    output[i] = false;
                }
            }
            else
            {
                if (input[0])
                {
                    if (ms)
                    {
                        if (!input[1])
                        {
                            for (int i = 0; i < output.Count - 1; i++)
                            {
                                output[i + 1] = output[i];
                            }
                            output[0] = input[3];
                        }
                        else
                        {
                            for (int i = 3; i < input.Count; i++)
                            {
                                output[i - 3] = input[i];
                            }
                        }
                        ms = false;
                    }
                    else
                    {
                        ms = true;
                    }
                }
            }
        }
    }
}
