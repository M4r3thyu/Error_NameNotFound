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
        private static List<string> connections = new List<string>();
        protected int id; //inputid;
        protected ObservableCollection<bool> input;
        protected ObservableCollection<bool> output;
        protected List<int> inportid, outportnr, inportnr;
        public LogicGates(int input, int output, int id)
        {
            //inputid = new int[input];
            inportid = new List<int>();
            outportnr = new List<int>();
            inportnr = new List<int>();
            // inputid = 0;
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
        public void Inputset(bool input, int id)
        {
            this.input[id] = input;
            ChangeOutput();

            NotifyPropertyChanged("Input");
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
        public void Connection(int inportid, int inportnr, int outportnr)
        {
            this.inportid.Add(inportid);
            this.inportnr.Add(inportnr);
            this.outportnr.Add(outportnr);
            string save = "| " + id + " " + inportid + " " + inportnr + " " + outportnr + " ";
            bool check = true;
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i].Contains(" " + inportid + " " + inportnr))
                {
                    connections[i] = save;
                    check = false;
                }
            }
            if (check)
                connections.Add(save);
            ChangeOutput();
        }
        public static string Connections
        {
            get
            {
                string allconnections = "| ouputid  inportid inportnr outportnr ";
                for (int i = 0; i < connections.Count; i++)
                {
                    allconnections = allconnections + connections[i];
                }
                return allconnections;
            }
        }
        abstract protected void ChangeOutput();
    }
}