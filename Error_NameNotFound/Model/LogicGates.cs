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
    abstract class LogicGates : Basemodel //Stuff that still has to be done is Saveing/Loading, Connections between Logicgates (including Grid), MVVM Integration
    {
        public static List<LogicGates> gates_logic = new List<LogicGates>();
        protected static List<int> connections = new List<int>();
        public int id;
        protected ObservableCollection<bool> input;
        protected ObservableCollection<bool> output;
        public LogicGates(int input, int output, int id)
        {
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
        public bool Connection(int iid, int inr, int onr)
        {
            bool merke = true;
            for (int i = 2; i < connections.Count; i += 4)
            {
                if (connections[i] == iid && connections[i + 1] == inr)
                {
                    merke = false;
                    break;
                }
            }
            if (merke)
            {
                connections.Add(id);
                connections.Add(onr);
                connections.Add(iid);
                connections.Add(inr);
                ChangeOutput();
                return true;
            }
            ChangeColor();
            return false;
        }
        public void DelConnections(int iid, int inr)
        {
            for (int i = 2; i < connections.Count; i += 4)
            {
                if (connections[i] == iid && connections[i + 1] == inr)
                {
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    connections.RemoveAt(i - 2);
                    basevalue(inr);
                    break;
                }
            }
        }
        public static string Connections
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
        virtual public void ChangeColor()
        { }
        virtual protected void basevalue(int inr)
        { }
        abstract protected void ChangeOutput();
    }
}