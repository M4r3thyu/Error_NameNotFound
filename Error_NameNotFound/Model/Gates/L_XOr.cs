using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Error_NameNotFound.ViewModel;

namespace Error_NameNotFound.Model
{
    class Xor : LogicGates
    {
        public ViewModel.XOR v_XOR;
        public Xor(int input, int id, ViewModel.XOR v_XOR) : base(2, 2,id)      //Output[0] = Normal [1] = Negiert
        {
            this.v_XOR = v_XOR;
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
