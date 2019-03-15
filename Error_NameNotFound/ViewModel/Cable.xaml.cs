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
        private int id = 0;
        private bool direction;
        private double x1;
        private double x2;
        private double y1;
        private double y2;

        public double Y2
        {
            get { return y2; }
            set { y2 = value; }
        }

        public double Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        public double X2
        {
            get { return x2; }
            set { x2 = value; }
        }


        public double X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        public Cable()
        {
            InitializeComponent();
            Name = "CableUI";
        }
        public bool Direction
        {
            get => Direction1;
        }
        public int Id
        {
            get => id;
        }
        public bool Direction1 { get => direction; set => direction = value; }

        public Cable(double X1, double Y1, double X2, double Y2,bool direction):this()
        {
            id = MainWindow.Id;
            MainWindow.Id++;
            l_cable = new L_Cable(id, this);
            LogicGates.gates_logic.Add(l_cable);
            Inputbutton_vm.Input_Click(id, 0);
            Outputbutton_vm.Output_Click(id, 0);
            ChangeColorInOut();
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            this.Direction1 = direction;
            this.X1 = X1;
            this.X2 = X2;
            this.Y1 = Y1;
            this.Y2 = Y2;
        }
        public Cable(int id,double X1, double X2, double Y1, double Y2, bool direction)
        {
            InitializeComponent();
            Name = "CableUI";
            this.id = id;
            l_cable = new L_Cable(id, this);
            LogicGates.gates_logic.Add(l_cable);
            //Inputbutton_vm.Input_Click(id, 0);
            //Outputbutton_vm.Output_Click(id, 0);
            ChangeColorInOut();
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            this.Direction1 = direction;
            this.X1 = X1;
            this.X2 = X2;
            this.Y1 = Y1;
            this.Y2 = Y2;
        }
        public Cable(double X1, double Y1, double X2, double Y2, bool direction,bool preview) : this()
        {
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            this.Direction1 = direction;
        }
        public void SetXY(double X1, double Y1, double X2, double Y2)
        {
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            this.X1 = X1;
            this.X2 = X2;
            this.Y1 = Y1;
            this.Y2 = Y2;
        }
        public void SetXY2(double X2, double Y2)
        {
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            this.X2 = X2;
            this.Y2 = Y2;
        }
        private void CableUI_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.GateDelete)
            {
                MainWindow.Currentcable = id;
                MainWindow.RemoveCable();
            }
            else
            {
                Outputbutton_vm.Output_Click(id, 0);
                MainWindow.CableDrag = true;
                MainWindow.CableX1 = CableUI.X2;
                MainWindow.CableY1 = CableUI.Y2;
                MainWindow.CableDirection = !Direction1;
                Cable _cable = new Cable();
                DragDrop.DoDragDrop(_cable, _cable, DragDropEffects.Move);
                ChangeColorInOut();
            }
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
                    CableUI.Stroke = System.Windows.Media.Brushes.GreenYellow;
                else
                    CableUI.Stroke = System.Windows.Media.Brushes.Purple;
            });
        }

        private void CableUI_MouseEnter(object sender, MouseEventArgs e)
        {
            if (MainWindow.GateDelete)
            {
                Mouse.OverrideCursor = new Cursor(Application.GetResourceStream(new Uri("../Views/Delete-Cursor_Cable_.cur", UriKind.Relative)).Stream);
            }
        }

        private void CableUI_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MainWindow.GateDelete)
            {
                Mouse.OverrideCursor = new Cursor(Application.GetResourceStream(new Uri("../Views/Delete-Cursor.cur", UriKind.Relative)).Stream);
            }
        }
    }
}
