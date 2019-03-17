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
    class L_Halfadder : LogicGates
    {
        public Halfadder v_Halfadder;
        public L_Halfadder(int id, Halfadder v_Halfadder) : base(2, 2,id) // input 0=a 1=b output 0=S 1=Cout
        {
            this.v_Halfadder = v_Halfadder;
            for (int i = 0; i < 2; i++)
            {
                this.input[i] = false;
            }
        }
        protected override void ChangeOutput()
        {
            if (input[0] && input[1])
            {
                output[0] = false;
                output[1] = true;
            }
            if (!input[0] && input[1] || input[0] && !input[1])
            {
                output[0] = true;
                output[1] = false;
            }
            if (!input[0] && !input[1])
            {
                output[0] = false;
                output[1] = false;
            }
            ChangeColor();
        }
        public override void ChangeColor()
        {
            //v_Halfadder.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}