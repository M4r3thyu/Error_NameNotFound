using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Error_NameNotFound.ViewModel
{
    /// <summary>
    /// Interaction logic for Counter.xaml
    /// </summary>
    public partial class Counter : UserControl
    {
        public Counter()
        {
            InitializeComponent();
        }
        //public override void ChangeColorInOut()
        //{
        //    Dispatcher.Invoke(() =>
        //    {
        //        // Set property or change UI compomponents.              
        //        if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[0])
        //            input0.Background = System.Windows.Media.Brushes.GreenYellow;
        //        else
        //            input0.Background = System.Windows.Media.Brushes.Purple;

        //        if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[1])
        //            input1.Background = System.Windows.Media.Brushes.GreenYellow;
        //        else
        //            input1.Background = System.Windows.Media.Brushes.Purple;

        //        if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0])
        //            output0.Background = System.Windows.Media.Brushes.GreenYellow;
        //        else
        //            output0.Background = System.Windows.Media.Brushes.Purple;

        //        if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[1])
        //            output1.Background = System.Windows.Media.Brushes.GreenYellow;
        //        else
        //            output1.Background = System.Windows.Media.Brushes.Purple;
        //    });
        //}
    }
}
