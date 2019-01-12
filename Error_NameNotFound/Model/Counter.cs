using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class Counter : LogicGates
    {
        public Counter(int input, int output, Point position) : base(input, output, position) // input 0=C, 1=M, 2=R
        {
        }
        protected override void ChangeOutput()
        {
            if (input[2])
            {
                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = false;
                }
            }
            else
            {
                if (input[0])
                {
                    if (!input[1])
                    {
                        for (int i = 0; i < output.Length - 1; i++)
                        {
                            if (output[i] == true)
                                output[i] = false;
                            else
                            {
                                output[i] = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 3; i < input.Length; i++)
                        {
                            output[i - 3] = input[i];
                        }
                    }
                }
            }
        }
    }
}
