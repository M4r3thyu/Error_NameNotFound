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
    /// Interaction logic for Calliper.xaml
    /// </summary>
    public partial class Calliper : Logicgatescontrol
    {
        private L_Calliper l_calliper;
        public Calliper():base()
        {
            InitializeComponent();
            anz_input = 0;
            anz_output = 1;
            Name = "CalliperUI";
        }
        public Calliper(int id):base(id)
        {
            InitializeComponent();
            anz_input = 0;
            anz_output = 1;
            Name = "CalliperUI";
            l_calliper = new L_Calliper(id, this);
            LogicGates.gates_logic.Add(l_calliper);
            ChangeColorInOut();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.CurrentGate = id;
                MainWindow.SetGateFromButton(false);
                MainWindow.GateType = "Calliper";
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Double", CalliperUI.Height);
                data.SetData("Object", this);
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        private void ButtonUI_MouseDown(object sender, MouseButtonEventArgs e)
        {
            l_calliper.Inputset(!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0], 0);
            CalliperUI.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/Calliper_pressed.png", UriKind.Absolute));
        }
        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            Outputbutton_vm.Output_Click(id, 0);
            MainWindow.CableX1 = Canvas.GetLeft(this) + 50;
            MainWindow.CableY1 = Canvas.GetTop(this) + 25;
            StartCableDrag();
        }
        private void CalliperUI_MouseUp(object sender, MouseButtonEventArgs e)
        {
            l_calliper.Inputset(!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0], 0);
            CalliperUI.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/Calliper.png", UriKind.Absolute));
        }
    }
}