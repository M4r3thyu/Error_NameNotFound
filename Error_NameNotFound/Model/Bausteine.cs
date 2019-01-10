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
    abstract class LogicGates : INotifyPropertyChanged
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
                    ChangeOutput();
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
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class Button : LogicGates
    {
        public Button(Point position) : base(1, 1, position)            //Input 1 = Taster getrueckt
        {
            output[0] = false;
        }
        override protected void ChangeOutput()
        {
            if (output[0] == true)
                output[0] = false;
            else
                output[0] = true;
            Output = output;
        }

    }
    class Calliper : LogicGates
    {
        public Calliper(Point position) : base(1, 1, position)          //Input 1 = Taster getrueckt
        {
            output = input;
        }
        override protected void ChangeOutput()
        {
            output = input;
            Output = output;
        }
    }
    class High : LogicGates
    {
        public High(Point position) : base(0, 1, position)
        {
            output[0] = true;
        }
        override protected void ChangeOutput()
        {
            output[0] = true;
            Output = output;
        }
    }
    class Low : LogicGates
    {
        public Low(Point position) : base(0, 1, position)
        {
            output[0] = false;
        }
        override protected void ChangeOutput()
        {
            output[0] = false;
            Output = output;
        }
    }
    class Not : LogicGates
    {
        public Not(Point position) : base(1, 1, position)
        {
            output[0] = !input[0];                                  //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            output[0] = !input[0];
            Output = output;
        }
    }
    class Light : LogicGates
    {
        public Light(Point position) : base(1, 1, position)         //Output 1 = Licht an
        {
            output[0] = input[0];
        }
        override protected void ChangeOutput()
        {
            output[0] = input[0];
            Output = output;
        }
    }
    class And : LogicGates
    {
        public And(int input, Point position) : base(input, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];                              //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            bool merke = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == false)
                    merke = false;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
        }
    }
    class Nand : LogicGates
    {
        public Nand(int input, Point position) : base(input, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[0] = !output[1];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            bool merke = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == false)
                    merke = true;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
        }
    }
    class Or : LogicGates
    {
        public Or(int input, Point position) : base(input, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            bool merke = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == true)
                    merke = true;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
        }
    }
    class Nor : LogicGates
    {
        public Nor(int input, Point position) : base(input, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[0] = !output[1];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            bool merke = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == true)
                    merke = false;
            }
            output[0] = merke;
            output[1] = !output[0];
            Output = output;
        }
    }
    class Xor : LogicGates
    {
        public Xor(int input, Point position) : base(2, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            if (input[0] != input[1])
                output[0] = true;
            else
                output[0] = false;
            output[1] = !output[0];
            Output = output;
        }
    }

    class Xnor : LogicGates
    {
        public Xnor(int input, Point position) : base(2, 2, position)      //Output[0] = Normal [1] = Negiert
        {
            output[0] = !output[1];                        //output[0] = Q output[1] = !Q
        }
        override protected void ChangeOutput()
        {
            if (input[0] == input[1])
                output[0] = true;
            else
                output[0] = false;
            output[1] = !output[0];
            Output = output;
        }
    }
    class FF_RS : LogicGates
    {
        public FF_RS(Point position) : base(2, 2, position) // input 0=S, 1=R
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
        }
        protected override void ChangeOutput()
        {
            if (input[1] && input[2])
            {
                output[0] = false;
                output[1] = false;
            }
            else
            {
                if (input[1])
                {
                    output[0] = false;
                }
                else
                {
                    if (input[0])
                        output[0] = true;
                }
                output[1] = !output[0];
            }
        }
    }
    class FF_RS_c : LogicGates
    {
        public FF_RS_c(Point position) : base(3, 2, position) // input 0=S, 1=R, 2=C
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
        }
        protected override void ChangeOutput()
        {
            if (input[1] && input[2])
            {
                output[0] = false;
                output[1] = false;
            }
            else
            {
                if (input[3])
                {
                    if (input[1])
                    {
                        output[0] = false;
                    }
                    else
                    {
                        if (input[0])
                            output[0] = true;
                    }
                    output[1] = !output[0];
                }
            }
        }
    }
    class FF_RS_c_e : LogicGates
    {
        private bool ms;
        public FF_RS_c_e(Point position) : base(3, 2, position) // input 0=S, 1=R, 2=C
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[1] && input[2])
            {
                output[0] = false;
                output[1] = false;
            }
            else
            {
                if (input[3])
                {
                    if (!ms)
                    {
                        if (input[1])
                        {
                            output[0] = false;
                        }
                        else
                        {
                            if (input[0])
                                output[0] = true;
                        }
                        ms = true;
                        output[1] = !output[0];
                    }
                }
                else
                {
                    if (ms)
                        ms = false;
                }
            }
        }
    }
    class FF_RS_c_ms : LogicGates
    {
        private bool ms;
        public FF_RS_c_ms(Point position) : base(3, 2, position) // input 0=S, 1=R, 2=C
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[1] && input[2])
            {
                output[0] = false;
                output[1] = false;
            }
            else
            {
                if (input[3])
                    ms = true;
                else
                {
                    if (ms)
                    {
                        if (input[1])
                        {
                            output[0] = false;
                        }
                        else
                        {
                            if (input[0])
                                output[0] = true;
                        }
                        ms = false;
                        output[1] = !output[0];
                    }
                }
            }
        }
    }
    class FF_RS_c_ms_e : LogicGates
    {
        private bool ms;
        public FF_RS_c_ms_e(Point position):base(3,2,position) // input 0=S, 1=R, 2=C
        {
            output[1] = !output[0];                        //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[1] && input[2])
            {
                output[0] = false;
                output[1] = false;
            }
            else
            {
                if (input[3])
                    ms = true;
                else
                {
                    if (ms)
                    {
                        if (input[1])
                        {
                            output[0] = false;
                        }
                        else
                        {
                            if (input[0])
                                output[0] = true;
                        }
                        ms = false;
                        output[1] = !output[0];
                    }
                }
            }
        }
    }
    class FF_JK_c : LogicGates
    {
        public FF_JK_c(Point position) : base(3, 2, position) // input 0=J, 1=K, 2=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
        }
        protected override void ChangeOutput()
        {
            if (input[3])
            {
                if (input[0] && input[1])
                    output[0] = output[1];
                else
                {
                    if (input[1])
                        output[0] = false;
                    if (input[0])
                        output[0] = true;
                }
                output[1] = !output[0];
            }
        }
    }
    class FF_JK_c_e : LogicGates
    {
        private bool ms;
        public FF_JK_c_e(Point position) : base(3, 2, position) // input 0=J, 1=K, 2=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[3])
            {
                if (!ms)
                {
                    if (input[0] && input[1])
                        output[0] = output[1];
                    else
                    {
                        if (input[1])
                            output[0] = false;
                        if (input[0])
                            output[0] = true;
                    }
                    ms = true;
                    output[1] = !output[0];
                }
                else
                {
                    ms = false;
                }
            }
        }
    }
    class FF_JK_c_ms : LogicGates                                                            
    {
        private bool ms;
        public FF_JK_c_ms(Point position) : base(3, 2, position) // input 0=J, 1=K, 2=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[3])
                ms = true;
            else
            {
                if (ms)
                {
                    if (input[0] && input[1])
                        output[0] = output[1];
                    else
                    {
                        if (input[1])
                            output[0] = false;
                        if (input[0])
                            output[0] = true;
                    }
                    ms = false;
                    output[1] = !output[0];
                }
            }
        }
    }
    class FF_JK_c_ms_e : LogicGates
    {
        private bool ms;
        public FF_JK_c_ms_e(Point position) : base(3, 2, position) // input 0=J, 1=K, 2=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[3])
                ms = true;
            else
            {
                if (ms)
                {
                    if (input[0] && input[1])
                        output[0] = output[1];
                    else
                    {
                        if (input[1])
                            output[0] = false;
                        if (input[0])
                            output[0] = true;
                    }
                    ms = false;
                    output[1] = !output[0];
                }
            }
        }
    }
    class FF_DC_c : LogicGates
    {
        private bool ms;
        public FF_DC_c(Point position) : base(2, 2, position) // input 0=D, 1=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
        }
        protected override void ChangeOutput()
        {
            if (input[1])
            {
                if (input[0])
                    output[0] = true;
                else
                    output[0] = false;
                output[1] = !output[0];
            }
        }
    }
    class FF_DC_c_e : LogicGates
    {
        private bool ms;
        public FF_DC_c_e(Point position) : base(2, 2, position) // input 0=D, 1=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[1])
                if (!ms)
                {
                    if (input[0])
                        output[0] = true;
                    else
                        output[0] = false;
                    ms = true;
                    output[1] = !output[0];
                }
            else
                ms = false;
        }
    }
    class FF_DC_c_ms : LogicGates
    {
        private bool ms;
        public FF_DC_c_ms(Point position) : base(2, 2, position) // input 0=D, 1=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[1])
                ms = true;
            else
            {
                if (ms)
                {
                    if (input[0])
                        output[0] = true;
                    else
                        output[0] = false;
                    ms = false;
                    output[1] = !output[0];
                }
            }
        }
    }
    class FF_DC_c_ms_e : LogicGates
    {
        private bool ms;
        public FF_DC_c_ms_e(Point position) : base(2, 2, position) // input 0=D, 1=C
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[1])
                ms = true;
            else
            {
                if (ms)
                {
                    if (input[0])
                        output[0] = true;
                    else
                        output[0] = false;
                    ms = false;
                    output[1] = !output[0];
                }
            }
        }
    }
    class FF_T_c_e : LogicGates
    {
        private bool ms;
        public FF_T_c_e(Point position) : base(1, 2, position) // input 0=T
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[0])
                if (!ms)
                {
                    ms = true;
                    output[0] = output[1];
                    output[1] = !output[0];
                }
                else
                    ms = false;
        }
    }
    class FF_T_c_ms_e : LogicGates
    {
        private bool ms;
        public FF_T_c_ms_e(Point position) : base(1, 2, position) // input 0=T
        {
            output[1] = !output[0];                         //output[0] = Q output[1] = !Q
            ms = false;
        }
        protected override void ChangeOutput()
        {
            if (input[0])
                ms = true;
            else
            {
                if (ms)
                {
                    ms = false;
                    output[0] = output[1];
                    output[1] = !output[0];
                }
            }
        }
    }
    class Halfadder : LogicGates
    {
        public Halfadder(Point position) : base(2, 2, position) // input 0=a 1=b output 0=S 1=Cout
        { }
        protected override void ChangeOutput()
        {
            if (input[0] && input[1])
            {
                output[0] = false;
                output[1] = true;
            }
            if (!input[0] && input[1]||input[0]&&!input[1])
            {
                output[0] = true;
                output[1] = false;
            }
            if(!input[0]&&!input[1])
            {
                output[0] = false;
                output[1] =false;
            }
        }
    }
    class Fulladder : LogicGates
    {
        public Fulladder(Point position) : base(3, 2, position) // input 0=a 1=b 2=Cin output 0=S 1=Cout
        { }
        protected override void ChangeOutput()
        {
            if (input[0] && input[1] && input[2])
            {
                output[0] = true;
                output[1] = true;
            }
            if (!input[0] && input[0] && input[2] || input[0] && !input[1] && input[2] || input[0] && input[1] && !input[2])
            {
                output[0] = false;
                output[1] = true;
            }
            if (!input[0] && !input[0] && input[2] || !input[0] && input[1] && !input[2] || input[0] && !input[1] && !input[2])
            {
                output[0] = true;
                output[1] = false;
            }
            if (!input[0] && !input[1] && !input[2])
            {
                output[0] = false;
                output[1] = false;
            }
        }
    }
    class Seg7 : LogicGates
    {                                                                   // Output[] 1 = Licht an
        public Seg7(Point position) : base(7, 7, position)              //   0_
        {                                                               // 1|2_|3
            output = input;                                             // 4|5_|6
        }
        override protected void ChangeOutput()
        {
            output = input;
            Output = output;
        }
    }
    class Hex7 : LogicGates
    {                                           // Output[] 1= Licht an Input[] wertichkeit -> 2^0/1/2/3/4
        public Hex7(Point position) : base(4, 7, position)              //  0_
        {                                       // 1|2_|3
            output = input;                     // 4|5_|6
        }
        override protected void ChangeOutput()
        {
            int merke = 0;
            if (input[0] == false && input[1] == false && input[2] == false && input[3] == false)
                merke = 0;
            if (input[0] == true && input[1] == false && input[2] == false && input[3] == false)
                merke = 1;
            if (input[0] == false && input[1] == true && input[2] == false && input[3] == false)
                merke = 2;
            if (input[0] == true && input[1] == true && input[2] == false && input[3] == false)
                merke = 3;
            if (input[0] == false && input[1] == false && input[2] == true && input[3] == false)
                merke = 4;
            if (input[0] == true && input[1] == false && input[2] == true && input[3] == false)
                merke = 5;
            if (input[0] == false && input[1] == true && input[2] == true && input[3] == false)
                merke = 6;
            if (input[0] == true && input[1] == true && input[2] == true && input[3] == false)
                merke = 7;
            if (input[0] == false && input[1] == false && input[2] == false && input[3] == true)
                merke = 8;
            if (input[0] == true && input[1] == false && input[2] == false && input[3] == true)
                merke = 9;
            if (input[0] == false && input[1] == true && input[2] == false && input[3] == true)
                merke = 10;
            if (input[0] == true && input[1] == true && input[2] == false && input[3] == true)
                merke = 11;
            if (input[0] == false && input[1] == false && input[2] == true && input[3] == true)
                merke = 12;
            if (input[0] == true && input[1] == false && input[2] == true && input[3] == true)
                merke = 13;
            if (input[0] == false && input[1] == true && input[2] == true && input[3] == true)
                merke = 14;
            if (input[0] == true && input[1] == true && input[2] == true && input[3] == true)
                merke = 15;
            switch (merke)
            {
                case 0:
                    output[0] = true;
                    output[1] = true;
                    output[2] = false;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 1:
                    output[0] = false;
                    output[1] = false;
                    output[2] = false;
                    output[3] = true;
                    output[4] = false;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 2:
                    output[0] = true;
                    output[1] = false;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = false;
                    break;
                case 3:
                    output[0] = true;
                    output[1] = false;
                    output[2] = true;
                    output[3] = true;
                    output[4] = false;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 4:
                    output[0] = false;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = false;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 5:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = false;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 6:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 7:
                    output[0] = true;
                    output[1] = false;
                    output[2] = false;
                    output[3] = true;
                    output[4] = false;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 8:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 9:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = false;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 10:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = false;
                    output[6] = true;
                    break;
                case 11:
                    output[0] = false;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 12:
                    output[0] = true;
                    output[1] = true;
                    output[2] = false;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = false;
                    break;
                case 13:
                    output[0] = false;
                    output[1] = false;
                    output[2] = true;
                    output[3] = true;
                    output[4] = true;
                    output[5] = true;
                    output[6] = true;
                    break;
                case 14:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = true;
                    output[6] = false;
                    break;
                case 15:
                    output[0] = true;
                    output[1] = true;
                    output[2] = true;
                    output[3] = false;
                    output[4] = true;
                    output[5] = false;
                    output[6] = false;
                    break;
                default:
                    break;
            }
            Output = output;
        }
    }
    //Missing:  Oscillator, Register, Counter  ????Logic analyzer
}
