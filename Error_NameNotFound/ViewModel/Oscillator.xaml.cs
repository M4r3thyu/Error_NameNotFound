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
    public partial class Oscillator : Logicgatescontrol
    {
        private L_Oscillator l_oscillator;
        public Oscillator() : base()
        {
            InitializeComponent();
            anz_input = 0;
            anz_output = 2;
            Name = "OscillatorUI";
            textboxIsUsed = false;
        }
        public Oscillator(int id) : base(id)
        {
            InitializeComponent();
            anz_input = 0;
            anz_output = 2;
            Name = "OscillatorUI";
            l_oscillator = new L_Oscillator(id, this);
            LogicGates.gates_logic.Add(l_oscillator);
            ChangeColorInOut();
            Timeout.Text = "1000";
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!textboxIsUsed)
            {
                base.OnMouseMove(e);
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    MainWindow.CurrentGate = id;
                    MainWindow.SetGateFromButton(false);
                    MainWindow.GateType = "Oscillator";
                    // Package the data.
                    DataObject data = new DataObject();
                    data.SetData("Double", OscillatorUI.Height);
                    data.SetData("Object", this);
                    // Inititate the drag-and-drop operation.
                    DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
                }
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
        private void Timeout_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(Timeout.Text) > 9999)
                    Timeout.Text = "9999";
                if (int.Parse(Timeout.Text) <= 100)
                    Timeout.Text = "100";
                l_oscillator.Timeout = int.Parse(Timeout.Text);
            }
            catch (Exception)
            {

            }
        }
    }
}
