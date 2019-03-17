﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Threading;
using Error_NameNotFound.ViewModel;

namespace Error_NameNotFound.Model
{
    class L_Oscillator : LogicGates
    {
        private Oscillator v_Oscillator;
        private Thread t;
        private int timeout;
        public L_Oscillator(int id, Oscillator v_Oscillator) : base(2, 1,id)
        {
            this.v_Oscillator = v_Oscillator;
            t = new Thread(new ThreadStart(ChangeOutput));
            t.Start();
            timeout = 1000;
            for (int i = 0; i < 2; i++)
            {
                this.input[i] = false;
            }
        }

        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        protected override void ChangeOutput()
        {
            while (true)
            {
                output[0] = !output[0];
                Thread.Sleep(timeout);
                ChangeColor();
            }
        }
        public override void ChangeColor()
        {
            //v_Not.ChangeColorInOut();
        }
        protected override void basevalue(int inr)
        {
            input[inr] = false;
            ChangeOutput();
        }
    }
}