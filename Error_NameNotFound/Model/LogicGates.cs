using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using Error_NameNotFound.ViewModel;
using System.Collections.ObjectModel;

namespace Error_NameNotFound.Model
{
    abstract class LogicGates : Basemodel
    {
        public static List<LogicGates> gates_logic = new List<LogicGates>();
        public static List<int> connections = new List<int>();
        public static int outid = 0, outnr = 0, inid = 0, innr = 0, in_or_out = 0;
        private static bool muell = false; 
        public bool in0, in1, in2, in3, in4, in5, in6, in7;
        public int id, prozessnr;
        protected ObservableCollection<bool> input;
        protected ObservableCollection<bool> output;
        public LogicGates(int input, int output, int id)
        {
            prozessnr = 0;
            in0 = false;
            in1 = false;
            in2 = false;
            in3 = false;
            in4 = false;
            in5 = false;
            in6 = false;
            in7 = false;
            this.id = id;
            this.input = new ObservableCollection<bool>();
            this.output = new ObservableCollection<bool>();
            for (int i = 0; i < input; i++)
            {
                this.input.Add(false);
            }
            for (int i = 0; i < output; i++)
            {
                this.output.Add(false);
            }
        }
        public ObservableCollection<bool> Input
        {
            get => input;
            set
            {
                input = value;
                NotifyPropertyChanged();
                ChangeOutput();
            }
        }
        public void Inputset(bool input, int inr)
        {
            if (this.input[inr] != input)
            {
                this.input[inr] = input;
                ChangeOutput();
                NotifyPropertyChanged("Input");
            }

        }
        public ObservableCollection<bool> Output
        {
            get => output;
            set
            {
                output = value;
                //gates_logic[connectorid].Input[inputid] = output[outputid];
                NotifyPropertyChanged();
            }
        }

        public bool Connection()
        {
            bool merke = true;
            for (int i = 2; i < connections.Count; i += 4)
            {
                if (connections[i] == inid && connections[i + 1] == innr)
                {
                    merke = false;
                    break;
                }
            }
            if (merke)
            {
                Inenabled(innr, inid) = true;
                connections.Add(outid);
                connections.Add(outnr);
                connections.Add(inid);
                connections.Add(innr);
                ChangeOutput();
                return true;
            }
            ChangeColor();
            return false;
        }
        public static ref bool Inenabled(int innr,int inid)
        {
            switch (innr)
            {
                case 0:
                    return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in0;
                case 1:
                   return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in1;
                case 2:
                    return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in2;
                case 3:
                    return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in3;
                case 4:
                    return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in4;
                case 5:
                    return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in5;
                case 6:
                    return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in6;
                case 7:
                    return ref LogicGates.gates_logic.FirstOrDefault(c => c.id == inid).in7;
                default:
                    return ref muell;
            }
        }

        public void DelConnections(int iid, int inr)
        {
            for (int i = 2; i < connections.Count; i += 4)
            {
                if (connections[i] == iid && connections[i + 1] == inr)
                {
                    switch (innr)
                    {
                        case 0:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in0 = false;
                            break;
                        case 1:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in1 = false;
                            break;
                        case 2:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in2 = false;
                            break;
                        case 3:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in3 = false;
                            break;
                        case 4:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in4 = false;
                            break;
                        case 5:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in5 = false;
                            break;
                        case 6:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in6 = false;
                            break;
                        case 7:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == iid).in7 = false;
                            break;
                        default:
                            break;
                    }
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    basevalue(inr);
                    break;
                }
            }
        }

        //protected void Connectedset(int id)
        //{
        //    for (int i = 0; i < connections.Count; i += 4)
        //    {
        //        //connections.Add(id);
        //        //connections.Add(onr);
        //        //connections.Add(iid);
        //        //connections.Add(inr);
        //        //var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == i);
        //        //if (temp!=null)
        //        if (connections[i] == id)
        //        {
        //            var temp1 = LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]);
        //            var temp2 = LogicGates.gates_logic.FirstOrDefault(c => c.id == id);
        //            if (temp1.Input[connections[i + 3]] != output[connections[i + 1]])
        //            {
        //                temp1.Inputset(temp2.output[connections[i + 1]], connections[i + 3]);
        //            }
        //        }
        //    }
        //}

        public static string Get_Connections
        {
            get
            {
                string allconnections = "| ouputid  outportnr inputid inportnr ";
                for (int i = 0; i < connections.Count; i++)
                {
                    if (i % 4 == 0)
                        allconnections = allconnections + " | ";
                    allconnections = allconnections + connections[i] + " ";
                }
                return allconnections;
            }
        }
        public static void Remove_connections(int id)
        {
            for (int i = 0; i < connections.Count-3; i += 4)
            {
                if (id == connections[i])
                {
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i+2]).basevalue(connections[i+3]);
                    switch (innr)
                    {
                        case 0:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in0 = false;
                            break;
                        case 1:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in1 = false;
                            break;
                        case 2:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in2 = false;
                            break;
                        case 3:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in3 = false;
                            break;
                        case 4:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in4 = false;
                            break;
                        case 5:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in5 = false;
                            break;
                        case 6:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in6 = false;
                            break;
                        case 7:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i + 2]).in7 = false;
                            break;
                        default:
                            break;
                    }
                    connections.RemoveAt(i);
                    connections.RemoveAt(i);
                    connections.RemoveAt(i);
                    connections.RemoveAt(i);
                    i -= 4;
                }
            }
            for (int i = 2; i < connections.Count; i += 4)
            {
                if (id == connections[i])
                {
                    switch (innr)
                    {
                        case 0:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in0 = false;
                            break;
                        case 1:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in1 = false;
                            break;
                        case 2:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in2 = false;
                            break;
                        case 3:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in3 = false;
                            break;
                        case 4:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in4 = false;
                            break;
                        case 5:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in5 = false;
                            break;
                        case 6:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in6 = false;
                            break;
                        case 7:
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).in7 = false;
                            break;
                        default:
                            break;
                    }
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == connections[i]).basevalue(connections[i+1]);
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    i -= 4;
                }
            }
        }
        virtual public void ChangeColor()
        { }
        virtual protected void basevalue(int inr)
        { }
        abstract protected void ChangeOutput();
    }
}