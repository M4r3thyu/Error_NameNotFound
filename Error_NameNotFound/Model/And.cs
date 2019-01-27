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
    class And : LogicGates
    {
        private AND v_AND;
        public And(int input,int id, AND v_AND) : base(input, 2,id)      //Output[0] = Normal [1] = Negiert
        {
            this.v_AND = v_AND;
            output[1] = !output[0];                              //output[0] = Q output[1] = !Q
            for (int i = 0; i < input; i++)
            {
                this.input[i]=true;
            }
        }
        override protected void ChangeOutput()
        {
            bool merke = true;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == false)
                    merke = false;
            }
            output[0] = merke;
            output[1] = !output[0];
            v_AND.ChangeColorInOut();
            for (int i = 0; i < inportnr.Count; i++)
            {
                gates_logic[inportid[i]].Inputset(output[outportnr[i]], inportnr[i]);
            }

        }
    }
}
