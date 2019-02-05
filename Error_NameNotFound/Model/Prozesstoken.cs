using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Error_NameNotFound.Model
{
    class Prozesstoken
    {
        private Thread t;
        private int timeout, prozessnr;
        public Prozesstoken(int prozessnr)
        {
            this.prozessnr = prozessnr;
            t = new Thread(new ThreadStart(Prozesscycle));
            t.Start();

        }
        public void Prozesscycle()
        {
            timeout = 10;
            while (true)
            {
                var temp2 = LogicGates.gates_logic.FindAll(c => c.prozessnr == prozessnr);
                if (temp2 != null)
                {
                    for (int x = 0; x < temp2.Count; x++)
                    {
                        for (int i = 0; i < LogicGates.connections.Count; i += 4)
                        {
                            //connections.Add(id);
                            //connections.Add(onr);
                            //connections.Add(iid);
                            //connections.Add(inr);
                            //var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == i);
                            //if (temp!=null)
                            if (LogicGates.connections[i] == temp2[x].id)
                            {
                                var temp1 = LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.connections[i + 2]);
                                if (temp1.Input[LogicGates.connections[i + 3]] != temp2[x].Output[LogicGates.connections[i + 1]])
                                {
                                    temp1.Inputset(temp2[x].Output[LogicGates.connections[i + 1]], LogicGates.connections[i + 3]);
                                    temp1.prozessnr = prozessnr;
                                }
                            }
                        }
                        temp2[x].prozessnr = 0;
                    }
                }
                else
                    break;
                Thread.Sleep(timeout);
            }
        }
    }
}