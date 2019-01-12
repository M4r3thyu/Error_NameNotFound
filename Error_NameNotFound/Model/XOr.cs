﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;


namespace Error_NameNotFound.Model
{
    class Xor : LogicGates
    {
        public Xor(int input, Point position) : base(2, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            if (input[0] != input[1])
                output[0] = true;
            else
                output[0] = false;
            output[1] = !output[0];
            Output = output;
        }
    }
}