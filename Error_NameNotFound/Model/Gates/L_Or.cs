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
    class L_Or : LogicGates
    {
        public L_Or(int input, int id) : base(input, 2,id)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            bool merke = false;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == true)
                    merke = true;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
        }
    }
}
