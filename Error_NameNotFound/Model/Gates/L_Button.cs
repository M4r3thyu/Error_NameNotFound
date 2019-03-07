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
    class L_Button : LogicGates
    {
        public LogicButton v_button;
        public L_Button(int id,LogicButton _button) : base(1, 1,id)            //Input 1 = Taster getrueckt
        {
            this.v_button = _button;
            output[0] = false;
        }
        override protected void ChangeOutput()
        {
            output[0] = !output[0];
            ChangeColor();
            prozessnr = MainWindow.Prozessid;
            MainWindow.Prozessid++;
            Prozesstoken start = new Prozesstoken(prozessnr);
        }
        public override void ChangeColor()
        {
            v_button.ChangeColorInOut();
        }
    }
}
