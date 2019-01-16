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
    abstract class LogicGates : Basemodel
    {
        protected bool[] input;
        protected bool[] output;
        protected Point position;
        public LogicGates(int input, int output,Point position)
        {
            this.position = position;
            this.input = new bool[input];
            this.output = new bool[output];
            for (int i = 0; i < input; i++)
            {
                this.input[i] = false;
            }
            for (int i = 0; i < output; i++)
            {
                this.output[i] = false;
            }
        }
        public bool[] Input
        {
            get => input;
            set
            {
                if (input != value)
                {
                    if (input != value)
                    {
                        input = value;
                        NotifyPropertyChanged();
                        ChangeOutput();
                    }
                }
            }
        }
        public Point Position
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
        }
        public bool[] Output
        {
            get => output;
            set
            {
                    output = value;
                    NotifyPropertyChanged();
            }
        }
        abstract protected void ChangeOutput();
    }
}
