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
using Error_NameNotFound.ViewModel;
using Error_NameNotFound.Model;
using System.Drawing;
using System.Windows.Threading;

namespace Error_NameNotFound.ViewModel
{
    public partial class FF_JK_c_r : Logicgatescontrol
    {
        private L_FF_JK_c_r l_FF_JK_c_r;
        public FF_JK_c_r() : base()
        {
            InitializeComponent();
            Name = "FF_JK_C_RUI";
        }
        public FF_JK_c_r(int id) : base(id)
        {
            InitializeComponent();
            Name = "FF_JK_C_RUI";
            l_FF_JK_c_r = new L_FF_JK_c_r(id, this);
            LogicGates.gates_logic.Add(l_FF_JK_c_r);
            ChangeColorInOut();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.CurrentGate = id;
                MainWindow.SetGateFromButton(false);
                MainWindow.GateType = "FF_JK_C_R";
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Double", FF_JK_C_RUI.Height);
                data.SetData("Object", this);
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }
        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            Outputbutton_vm.Output_Click(id, 0);
            MainWindow.CableX1 = Canvas.GetLeft(this) + 90;
            MainWindow.CableY1 = Canvas.GetTop(this) + 75;
            StartCableDrag();
        }
        private void Output1_Click(object sender, RoutedEventArgs e)
        {
            Outputbutton_vm.Output_Click(id, 1);
            MainWindow.CableX1 = Canvas.GetLeft(this) + 90;
            MainWindow.CableY1 = Canvas.GetTop(this) + 25;
            StartCableDrag();
        }
        private void DelConnection_Input0(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 0);
        }
        private void DelConnection_Input1(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 1);
        }
        public override void ChangeColorInOut()
        {
            Dispatcher.Invoke(() =>
            {
                // Set property or change UI compomponents.              
                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[0])
                    input0.Background = System.Windows.Media.Brushes.GreenYellow;
                else
                    input0.Background = System.Windows.Media.Brushes.Purple;

                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[1])
                    input1.Background = System.Windows.Media.Brushes.GreenYellow;
                else
                    input1.Background = System.Windows.Media.Brushes.Purple;

                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0])
                    output0.Background = System.Windows.Media.Brushes.GreenYellow;
                else
                    output0.Background = System.Windows.Media.Brushes.Purple;

                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[1])
                    output1.Background = System.Windows.Media.Brushes.GreenYellow;
                else
                    output1.Background = System.Windows.Media.Brushes.Purple;
            });
        }
        private void Input0_Drop(object sender, DragEventArgs e)
        {
            StopCableDrag(Canvas.GetLeft(this) + 10, Canvas.GetTop(this) + 25);
            Inputbutton_vm.Input_Click(id, 0);
            e.Handled = true;
        }
        private void Input1_Drop(object sender, DragEventArgs e)
        {
            StopCableDrag(Canvas.GetLeft(this) + 10, Canvas.GetTop(this) + 75);
            Inputbutton_vm.Input_Click(id, 1);
            e.Handled = true;
        }
    }
}
