using Error_NameNotFound.Model;
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
    /// Interaction logic for Cable.xaml
    /// </summary>
    public partial class Cable : UserControl
    {
        private L_Cable l_cable;
        public int id = 0;
        public bool direction;
        public Cable()
        {
            InitializeComponent();
            Name = "CableUI";
            id = MainWindow.id;
            l_cable = new L_Cable(id, this);
            LogicGates.gates_logic.Add(l_cable);
            MainWindow.id++;
            Inputbutton_vm.Input_Click(id, 0);
            ChangeColorInOut();
        }
        public bool Direction
        {
            get => direction;
        }
        public Cable(double X1, double Y1, double X2, double Y2,bool direction):this()
        {
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            this.direction = direction;
        }
        public void SetXY(double X1, double Y1, double X2, double Y2)
        {
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
        }
        public void SetXY2(double X2, double Y2)
        {
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (MainWindow.GateDelete)
            {
                MainWindow.RemoveCable(this);
            }
        }
        private void CableUI_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.CableDrag = true;
            MainWindow.CableX1 = CableUI.X2;
            MainWindow.CableY1 = CableUI.Y2;
            MainWindow.CableDirection = !direction;
            Cable _cable = new Cable();
            DragDrop.DoDragDrop(_cable, _cable, DragDropEffects.Move);
            Outputbutton_vm.Output_Click(id, 0);
            ChangeColorInOut();
        }

        private void CableUI_MouseMove(object sender, MouseEventArgs e)
        {

        }
        public void ChangeColorInOut()
        {
            Dispatcher.Invoke(() =>
            {
                // Set property or change UI compomponents.              
                if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[0])
                    CableUI.Stroke = System.Windows.Media.Brushes.Red;
                else
                    CableUI.Stroke = System.Windows.Media.Brushes.MediumPurple;
            });
        }
    }
}
