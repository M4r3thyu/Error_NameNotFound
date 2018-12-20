using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Error_NameNotFound.Model
{
    abstract class Bausteine : INotifyPropertyChanged
    {
        protected bool[] input;
        protected bool[] output;
        public Bausteine() { }
        public Bausteine(int input, int output)
        {
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
    class Button : Bausteine
    {
        public Button() : base(1, 1)            //Input 1 = Taster getrueckt
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
    class Calliper : Bausteine
    {
        public Calliper() : base(1, 1)          //Input 1 = Taster getrueckt
        {
            output = input;
        }
        override protected void ChangeOutput()
        {
            output = input;
            Output = output;
        }
    }
    class High : Bausteine
    {
        public High() : base(0, 1)
        {
            output[0] = true;
        }
        override protected void ChangeOutput()
        {
            output[0] = true;
            Output = output;
        }
    }
    class Low : Bausteine
    {
        public Low() : base(0, 1)
        {
            output[0] = false;
        }
        override protected void ChangeOutput()
        {
            output[0] = false;
            Output = output;
        }
    }
    class Not : Bausteine
    {
        public Not() : base(1, 1)
        {
            output[0] = !input[0];
        }
        override protected void ChangeOutput()
        {
            output[0] = !input[0];
            Output = output;
        }
    }
    class Light : Bausteine
    {
        public Light() : base(1, 1)         //Output 1 = Licht an
        {
            output[0] = input[0];
        }
        override protected void ChangeOutput()
        {
            output[0] = input[0];
            Output = output;
        }
    }
    class And : Bausteine
    {
        public And() { }
        public And(int input) : base(input, 2)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];
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
    class Nand : Bausteine
    {
        public Nand() { }
        public Nand(int input) : base(input, 2)      //Output[0] = Normal [1] = Negiert
        {
            output[0] = !output[1];
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
    class Or : Bausteine
    {
        public Or() { }
        public Or(int input) : base(input, 2)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];
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
    class Nor : Bausteine
    {
        public Nor() { }
        public Nor(int input) : base(input, 2)      //Output[0] = Normal [1] = Negiert
        {
            output[0] = !output[1];
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
    class Xor : Bausteine
    {
        public Xor() { }
        public Xor(int input) : base(2, 2)      //Output[0] = Normal [1] = Negiert
        {
            output[1] = !output[0];
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

    class Xnor : Bausteine
    {
        public Xnor() { }
        public Xnor(int input) : base(2, 2)      //Output[0] = Normal [1] = Negiert
        {
            output[0] = !output[1];
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
    class Seg7 : Bausteine
    {                                           // Output[] 1= Licht an
        public Seg7() : base(7, 7)              //  0_
        {                                       // 1|2_|3
            output = input;                     // 4|5_|6
        }
        override protected void ChangeOutput()
        {
            output = input;
            Output = output;
        }
    }
    class Hex7 : Bausteine
    {                                           // Output[] 1= Licht an Input[] wertichkeit -> 2^0/1/2/3/4
        public Hex7() : base(4, 7)              //  0_
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
    //Missing:  Oscillator, Halfadder, Fulladder, all RS's, Register, Counter  ????Logic analyzer
}