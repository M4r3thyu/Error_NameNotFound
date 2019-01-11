using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Error_NameNotFound.Model
{
    class Nand : LogicGates
    {
        public Nand(int input, Point position) : base(input, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[0] = !output[1];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            bool merke = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == false)
                    merke = true;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
        }
    }
}
