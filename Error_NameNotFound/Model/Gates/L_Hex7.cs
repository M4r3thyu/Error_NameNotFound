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
    class L_Hex7 : LogicGates
    {                                           // Output[] 1= Licht an Input[] wertichkeit -> 2^0/1/2/3/4
        public L_Hex7(int id) : base(4, 7,id)              //  0_
        {                                       // 1|2_|3
            output = input;                     // 4|5_|6
        }
        override protected void ChangeOutput()
        {
            int merke = 0;
            if (input[0] == false && input[1] == false && input[2] == false && input[3] == false)
                merke = 0;
            if (input[0] == true && input[1] == false && input[2] == false && input[3] == false)
                merke = 1;
            if (input[0] == false && input[1] == true && input[2] == false && input[3] == false)
                merke = 2;
            if (input[0] == true && input[1] == true && input[2] == false && input[3] == false)
                merke = 3;
            if (input[0] == false && input[1] == false && input[2] == true && input[3] == false)
                merke = 4;
            if (input[0] == true && input[1] == false && input[2] == true && input[3] == false)
                merke = 5;
            if (input[0] == false && input[1] == true && input[2] == true && input[3] == false)
                merke = 6;
            if (input[0] == true && input[1] == true && input[2] == true && input[3] == false)
                merke = 7;
            if (input[0] == false && input[1] == false && input[2] == false && input[3] == true)
                merke = 8;
            if (input[0] == true && input[1] == false && input[2] == false && input[3] == true)
                merke = 9;
            if (input[0] == false && input[1] == true && input[2] == false && input[3] == true)
                merke = 10;
            if (input[0] == true && input[1] == true && input[2] == false && input[3] == true)
                merke = 11;
            if (input[0] == false && input[1] == false && input[2] == true && input[3] == true)
                merke = 12;
            if (input[0] == true && input[1] == false && input[2] == true && input[3] == true)
                merke = 13;
            if (input[0] == false && input[1] == true && input[2] == true && input[3] == true)
                merke = 14;
            if (input[0] == true && input[1] == true && input[2] == true && input[3] == true)
                merke = 15;
            switch (merke)
            {
                case 0:
                    output[0] = true;
                    output[1] = true;
                    output[2] = false;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 1:
                    output[0] = false;
                    output[1] = false;
                    output[2] = false;
                    output[3] = true;
                    output[4] = false;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 2:
                    output[0] = true;
                    output[1] = false;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = false;
                    break;
                case 3:
                    output[0] = true;
                    output[1] = false;
                    output[2] = true;
                    output[3] = true;
                    output[4] = false;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 4:
                    output[0] = false;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = false;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 5:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = false;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 6:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 7:
                    output[0] = true;
                    output[1] = false;
                    output[2] = false;
                    output[3] = true;
                    output[4] = false;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 8:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 9:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = false;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 10:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 11:
                    output[0] = false;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 12:
                    output[0] = true;
                    output[1] = true;
                    output[2] = false;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = false;
                    break;
                case 13:
                    output[0] = false;
                    output[1] = false;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 14:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = false;
                    break;
                case 15:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = false;
                    output[6] = false;
                    break;
                default:
                    break;
            }
            Output = output;
        }
    }
}