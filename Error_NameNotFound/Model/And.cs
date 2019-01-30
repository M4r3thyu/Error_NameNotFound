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
        public AND v_AND;
        public And(int input, int id, AND v_AND) : base(input, 2, id)      //Output[0] = Normal [1] = Negiert
        {
            this.v_AND = v_AND;
            output[0] = !output[1];                              //output[0] = Q output[1] = !Q
            for (int i = 0; i < input; i++)
            {
                this.input[i] = true;
            }
        }
        override protected void ChangeOutput()
        {
            bool merke = true;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == false)
                {
                    merke = false;
                    break;
                }
            }
            output[0] = merke;
            output[1] = !output[0];
            v_AND.ChangeColorInOut();
            for (int i = 0; i < connections.Count; i += 4)
            {
                if (connections[i] == id)
                    gates_logic[connections[i + 2]].Inputset(output[connections[i + 1]], connections[i + 3]);
            }
        }
        public override void ChangeColor()
        {
            v_AND.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = true;
            ChangeOutput();
        }
    }
}