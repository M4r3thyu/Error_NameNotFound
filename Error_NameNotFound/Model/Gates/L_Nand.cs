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
    class L_Nand : LogicGates
    {
        public NAND v_Nand;
        public L_Nand(int input, int id, NAND v_Nand) : base(input, 2,id)      //Output[0] = Normal [1] = Negiert
        {
            this.v_Nand = v_Nand;
            output[0] = !output[1];                        //output[0] = Q output[1] = !Q
            for (int i = 0; i < input; i++)
            {
                this.input[i] = false;
            }
        }
        override protected void ChangeOutput()
        {
            bool merke = false;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == false)
                    merke = true;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_Nand.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}