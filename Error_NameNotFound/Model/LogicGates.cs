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
        protected ObservableCollection<bool> input;
        protected ObservableCollection<bool> output;
        private int inputid, connectorid, outputid;
        public LogicGates(int input, int output/*,Point position*/)
        {
            //this.position = position;
            inputid = 0;
            connectorid = 0;
            outputid = 0;
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
        /*public Point Position
        {
            get => position;
            set
            {
                if (position != value)
                {
                    position = value;
                    NotifyPropertyChanged();
                }
            }
        }*/
        public ObservableCollection<bool> Output
        {
            get =>output;
            set
            {
                output = value;
                gates_logic[connectorid].Input[inputid] = output[outputid];
                NotifyPropertyChanged();
            }
        }
        public void Connection(int connectorid, int inputid, int outputid)
        {
            this.connectorid = connectorid;
            this.inputid = inputid;
            this.outputid = outputid;
        }
        abstract protected void ChangeOutput();
    }
}
