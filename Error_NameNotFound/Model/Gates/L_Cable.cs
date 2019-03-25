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
    class L_Cable : LogicGates
    {
        public Cable v_cable;
        public L_Cable(int id,Cable v_cable):base(1, 1, id)
        {
            this.v_cable = v_cable;
            this.input[0] = false;
            this.output = this.input;
        }
        protected override void ChangeOutput()
        {
            output[0] = input[0];
            ChangeColor();
        }
        public override void ChangeColor()
        {
            v_cable.ChangeColorInOut();
        }
        public void del()
        {
            output[0] = false;
            ChangeColor();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}
