using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Threading;

namespace Error_NameNotFound.Model
{
    class Oscillator : LogicGates
    {
        private Thread t;
        private int timeout;
        public Oscillator(int id) : base(2, 1,id)
        {
            t = new Thread(new ThreadStart(ChangeOutput));
            t.Start();
            timeout = 1000;
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
            }
        }
    }
}
