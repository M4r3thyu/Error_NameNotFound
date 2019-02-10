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
    class l_Button : LogicGates
    {
        public LogicButton v_button;
        public l_Button(int id,LogicButton _button) : base(1, 1,id)            //Input 1 = Taster getrueckt
        {
            this.v_button = _button;
            output[0] = false;
        }
        override protected void ChangeOutput()
        {
            output[0] = !output[0];
            ChangeColor();
            prozessnr = MainWindow.prozessid;
            Prozesstoken start = new Prozesstoken(MainWindow.prozessid);
            MainWindow.prozessid++;
        }
        public override void ChangeColor()
        {
            v_button.ChangeColorInOut();
        }
    }
}
