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

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for AND.xaml
    /// </summary>
    public partial class AND : UserControl
    {
        private static int anzahl = 0;
        //private string imagename;
        private int id;
        private And l_and;
        public AND()
        {

            InitializeComponent();
            id = 0;
            anzahl++;
            Name = "ANDUI";
            //      imagename = "ANDUI" + Convert.ToString(id);

        }
        public AND(int id) : this()
        {
            this.id = id;
            //     imagename = "ANDUI" + Convert.ToString(id);
            //        ANDUI.Name = imagename;
            l_and = new And(2, id, this);
            LogicGates.gates_logic.Add(l_and);
            ChangeColorInOut();
        }
        public int Id
        {
            get => id;
        }
        public double GetANDUI_Height()
        {
            double heightsave;
            //ANDUI.Name = "ANDUI";
            heightsave = ANDUI.Height;
            //  ANDUI.Name = imagename;
            return heightsave;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Setcurrentgate(id);
                MainWindow.SetGateFromButton(false);
                // Package the data.
                //  ANDUI.Name = "ANDUI";
                DataObject data = new DataObject();
                data.SetData("Double", ANDUI.Height);
                data.SetData("Object", this);
                //  ANDUI.Name = imagename;
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (MainWindow.GateDelete)
            {
                MainWindow.RemoveGate(id);
            }
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            //if (e.Effects.HasFlag(DragDropEffects.Copy) | e.Effects.HasFlag(DragDropEffects.Move))
            //{
            //    Mouse.SetCursor(new Cursor(Application.GetResourceStream(new Uri("Views/And.cur", UriKind.Relative)).Stream));
            //}
            if (e.Effects.HasFlag(DragDropEffects.Copy)) ;
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Hand);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        private void Input0_Click(object sender, RoutedEventArgs e)
        {
            bool success = Inputbutton_vm.Input_Click(id, 0);
            if (success)
                input0.Background = System.Windows.Media.Brushes.Yellow;
        }

        private void Input1_Click(object sender, RoutedEventArgs e)
        {
            bool success = Inputbutton_vm.Input_Click(id, 1);
            if (success)
                input1.Background = System.Windows.Media.Brushes.Yellow;
        }

        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            bool sucess = Outputbutton_vm.Output_Click(id, 0);
            if (sucess)
                output0.Background = System.Windows.Media.Brushes.Yellow;

        }
        private void Output1_Click(object sender, RoutedEventArgs e)
        {
            bool sucess = Outputbutton_vm.Output_Click(id, 1);
            if (sucess)
                output1.Background = System.Windows.Media.Brushes.Yellow;
        }

        private void DelConnection_Input0(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 0);
        }

        private void DelConnection_Input1(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 1);
        }

        public void ChangeColorInOut()
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
    }
}