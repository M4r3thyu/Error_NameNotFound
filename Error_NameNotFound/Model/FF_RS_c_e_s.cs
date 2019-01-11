﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class FF_RS_c_e_s : LogicGates
    {
        private bool ms;
        public FF_RS_c_e_s(Point position) : base(5, 2, position) // input 0=S, 1=R, 2=C 3=set
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
           
            if (input[3])
            {
                output[0] = false;
                output[1] = !output[0];
            }
            else
            {
                if (input[1] && input[2])
                {
                    output[0] = false;
                    output[1] = false;
                }
                else
                {
                    if (input[2])
                    {
                        if (!ms)
                        {
                            if (input[1])
                            {
                                output[0] = false;
                            }
                            else
                            {
                                if (input[0])
                                    output[0] = true;
                            }
                            ms = true;
                            output[1] = !output[0];
                        }
                    }
                    else
                    {
                        if (ms)
                            ms = false;
                    }
                }
            }
        }
    }
}
