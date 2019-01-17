﻿using System;
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
    abstract class LogicGates : Basemodel //Stuff that still has to be done is Saveing/Loading, Connections between Logicgates (including Grid), MVVM Integration
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
            Save_Button_vm.save.Add(this);
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
