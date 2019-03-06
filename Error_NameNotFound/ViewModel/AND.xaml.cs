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

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for AND.xaml
    /// </summary>
    public partial class AND : Logicgatescontrol
    {
        private L_And l_and;
        public AND() : base()
        {
            InitializeComponent();
            Name = "ANDUI";
        }
        public AND(int id) : base(id)
        {
            InitializeComponent();
            Name = "ANDUI";
            l_and = new L_And(2, id, this);
            LogicGates.gates_logic.Add(l_and);
            ChangeColorInOut();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Setcurrentgate(id);
                MainWindow.SetGateFromButton(false);
                MainWindow.GateType = "AND";
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Double", ANDUI.Height);
                data.SetData("Object", this);
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }
        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            bool sucess = Outputbutton_vm.Output_Click(id, 0);
            MainWindow.CableX1 = Canvas.GetLeft(this) + 90;
            MainWindow.CableY1 = Canvas.GetTop(this) + 75;
            StartCableDrag();
        }
        private void Output1_Click(object sender, RoutedEventArgs e)
        {
            bool sucess = Outputbutton_vm.Output_Click(id, 1);
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
                    input0.Background = System.Windows.Media.Brushes.Red;
                else
                    input0.Background = System.Windows.Media.Brushes.MediumPurple;

                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[1])
                    input1.Background = System.Windows.Media.Brushes.Red;
                else
                    input1.Background = System.Windows.Media.Brushes.MediumPurple;

                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0])
                    output0.Background = System.Windows.Media.Brushes.Red;
                else
                    output0.Background = System.Windows.Media.Brushes.MediumPurple;

                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[1])
                    output1.Background = System.Windows.Media.Brushes.Red;
                else
                    output1.Background = System.Windows.Media.Brushes.MediumPurple;
            });
        }
        private void Input0_Drop(object sender, DragEventArgs e)
        {
            StopCableDrag(Canvas.GetLeft(this) + 10, Canvas.GetTop(this) + 25);
            e.Handled = true;
            bool success = Inputbutton_vm.Input_Click(id, 0);
        }
        private void Input1_Drop(object sender, DragEventArgs e)
        {
            StopCableDrag(Canvas.GetLeft(this) + 10, Canvas.GetTop(this) + 75);
            e.Handled = true;
            bool success = Inputbutton_vm.Input_Click(id, 1);
        }
    }
}