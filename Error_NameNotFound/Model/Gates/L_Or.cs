﻿using System;
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
    class L_Or : LogicGates
    {
        private OR v_OR;
        public L_Or(int input, int id, OR v_OR) : base(input, 2,id)      //Output[0] = Normal [1] = Negiert
        {
            this.v_OR = v_OR;
            output[1] = !output[0];                           //output[0] = Q output[1] = !Q
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
                if (input[i] == true)
                    merke = true;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_OR.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}
