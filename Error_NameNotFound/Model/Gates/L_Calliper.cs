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
    class L_Calliper : LogicGates
    {
        public Calliper v_Calliper;
        public L_Calliper(int id, Calliper v_Calliper) : base(1, 1,id)          //Input 1 = Taster getrueckt
        {
            this.v_Calliper = v_Calliper;
            output[0] = input[0];
        }
        override protected void ChangeOutput()
        {
            output[0] = input[0];
            ChangeColor();
            prozessnr = MainWindow.Prozessid;
            MainWindow.Prozessid++;
            Prozesstoken start = new Prozesstoken(prozessnr);
        }
        public override void ChangeColor()
        {
            v_Calliper.ChangeColorInOut();
        }
    }
}
