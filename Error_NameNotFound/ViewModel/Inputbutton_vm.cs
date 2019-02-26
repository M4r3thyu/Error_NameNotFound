using Error_NameNotFound.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Error_NameNotFound.ViewModel
{
    class Inputbutton_vm
    {
        public Inputbutton_vm() { }
        public static bool Input_Click(int id, int innr)
        {
            switch (LogicGates.in_or_out)
            {
                case 0:
                    LogicGates.inid = id;
                    LogicGates.innr = innr;
                    if (!LogicGates.Inenabled(innr, id))
                    {
                        LogicGates.in_or_out = 2;
                        return true;
                        //input0.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    break;
                case 1:                 //output id             inportid  inportnr  ouportnr     
                    if (!LogicGates.Inenabled(innr, id))
                    {
                        LogicGates.inid = id;
                        LogicGates.innr = innr;
                        var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid);
                        if (temp != null)
                        {
                            temp.Connection();
                        }
                    }
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    LogicGates.in_or_out = 0;
                    break;
                default:
                    LogicGates.in_or_out = 0;
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
                    break;
            }
            return false;
        }
        private void DelConnection_Input()
        {
            //    LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 0);
        }
    }
}
