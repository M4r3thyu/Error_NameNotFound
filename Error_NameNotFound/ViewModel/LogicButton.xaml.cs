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
        private bool On;
        public LogicButton() :base()
        {
            InitializeComponent();
            anz_input = 0;
            anz_output = 1;
            Name = "ButtonUI";
            On = false;
        }
        public LogicButton(int id) : base(id)
        {
            InitializeComponent();
            anz_input = 0;
            anz_output = 1;
            Name = "ButtonUI";
            On = false;
            l_button = new L_Button(id, this);
            LogicGates.gates_logic.Add(l_button);
            ChangeColorInOut();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.CurrentGate = id;
                MainWindow.SetGateFromButton(false);
                if (On)
                {
                    MainWindow.GateType = "LogicButton_On";
                }
                else
                {
                    MainWindow.GateType = "LogicButton_Off";
                }
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Double", ButtonUI.Height);
                data.SetData("Object", this);
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }
        private void ButtonUI_MouseUp(object sender, MouseButtonEventArgs e)
        {
            l_button.Inputset(!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0], 0);
            On = !On;
            if (On)
            {
                ButtonUI.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/LogicButton_On.png", UriKind.Absolute));
            }
            else
            {
                ButtonUI.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/LogicButton_Off.png", UriKind.Absolute));
            }
        }
        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            Outputbutton_vm.Output_Click(id, 0);
            MainWindow.CableX1 = Canvas.GetLeft(this) + 50;
            MainWindow.CableY1 = Canvas.GetTop(this) + 25;
            StartCableDrag();
        }
    }
}
