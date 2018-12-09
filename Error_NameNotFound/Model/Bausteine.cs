using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Error_NameNotFound.Model
{
    class Bausteine : INotifyPropertyChanged
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
                    input = value;
                    RaisePropertyChanged("Input");
                    RaisePropertyChanged("Output");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    class And : Bausteine
    {
        public And() { }
        public And(int input) : base(input, 2)
        {
            output[1] = !output[0];
        }
        public new bool[] Output {
            get
            {
                bool merke = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == false)
                        merke = false;
                }
                output[0] = merke;
                output[1] = !output[0];
                return output;
            }
          }
    }
    
}