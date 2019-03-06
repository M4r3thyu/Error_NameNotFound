using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_NameNotFound.Model
{
    class Outputbutton_vm
    {
        public static bool Output_Click(int id, int outnr)
        {
            //switch (LogicGates.in_or_out)
            //{
            //    case 0:
                    LogicGates.outid = id;
                    LogicGates.outnr = outnr;
                    LogicGates.in_or_out = 1;
                    return true;
                //output0.Background = System.Windows.Media.Brushes.Yellow;
                //break;
            //    case 2:
            //        LogicGates.outid = id;
            //        LogicGates.outnr = outnr;
            //        var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid);
            //        if (temp != null)
            //        {
            //            bool ant = temp.Connection();

            //            LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
            //        }
            //        LogicGates.in_or_out = 0;
            //        break;
            //    default:
            //        LogicGates.in_or_out = 0;
            //        LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
            //        LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
            //        break;
            //}
            //return false;
        }
    }
}