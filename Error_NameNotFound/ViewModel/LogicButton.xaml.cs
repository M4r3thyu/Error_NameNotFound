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
using Error_NameNotFound.ViewModel.Outsourced_Drag_and_drop_funktions;

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for LogicButton.xaml
    /// </summary>
    public partial class LogicButton : UserControl
    {
        private int id;
        private L_Button l_button;
                //private And l_and;
        public LogicButton()
        {
            InitializeComponent();
            id = 0;
            Name = "ButtonUI";
        }
        public LogicButton(int id) : this()
        {
            this.id = id;
            l_button = new L_Button(id, this);
            //l_and = new And(2, id, this);
            LogicGates.gates_logic.Add(l_button);
            ChangeColorInOut();
        }
        public int Id
        {
            get => id;
        }
        public double GetANDUI_Height()
        {
            return ButtonUI.Height;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Setcurrentgate(id);
                MainWindow.SetGateFromButton(false);
                MainWindow.GateType = "LogicButton";
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Double", ButtonUI.Height);
                data.SetData("Object", this);
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Outsourced_d_and_d.OnMouseLeftButtonDown(id);
            //if (MainWindow.GateDelete)
            //{
            //    MainWindow.RemoveGate(id);
            //}
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.     
            Outsourced_d_and_d.OnGiveFeedback(e);
            //if (e.Effects.HasFlag(DragDropEffects.Move))
            //{
            //    Mouse.SetCursor(Cursors.Hand);
            //}
            //else if (e.Effects.HasFlag(DragDropEffects.Copy))
            //{
            //    Mouse.SetCursor(Cursors.Cross);
            //}
            //else
            //{
            //    Mouse.SetCursor(Cursors.No);
            //}
            //e.Handled = true;
        }
        private void ButtonUI_MouseDown(object sender, MouseButtonEventArgs e)
        {
            l_button.Inputset(!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0], 0);
        }
        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            bool sucess = Outputbutton_vm.Output_Click(id, 0);
            if (sucess)
                output0.Background = System.Windows.Media.Brushes.Yellow;
        }
        public void ChangeColorInOut()
        {
            Dispatcher.Invoke(() =>
            {
                // Set property or change UI compomponents.              
                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0])
                    output0.Background = System.Windows.Media.Brushes.Red;
                else
                    output0.Background = System.Windows.Media.Brushes.MediumPurple;
            });
        }
    }
}
