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
    /// Interaction logic for LogicButton.xaml
    /// </summary>
    public partial class LogicButton : Logicgatescontrol
    {
        private L_Button l_button;
        public LogicButton() :base()
        {
            InitializeComponent();
            Name = "ButtonUI";
        }
        public LogicButton(int id) : base(id)
        {
            InitializeComponent();
            Name = "ButtonUI";
            l_button = new L_Button(id, this);
            LogicGates.gates_logic.Add(l_button);
            ChangeColorInOut();
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
        private void ButtonUI_MouseDown(object sender, MouseButtonEventArgs e)
        {
            l_button.Inputset(!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0], 0);
        }
        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CableX1 = Canvas.GetLeft(this) + 50;
            MainWindow.CableY1 = Canvas.GetTop(this) + 25;
            StartCableDrag();
            bool sucess = Outputbutton_vm.Output_Click(id, 0);
        }
        public override void ChangeColorInOut()
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
