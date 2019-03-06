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
        public static bool y = false;
        public int id = 0;
        public double x1,x2,y1,y2;
        public bool x;
        public Cable()
        {
            if (y)
            {
                x = false;
            }
            else
            {
                x = true;
            }
            id = MainWindow.id;
            MainWindow.id++;
            InitializeComponent();
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
        }
        public Cable(double X1, double Y1, double X2, double Y2) : this()
        {
            if (x)
            {
                x1 = X1; x2 = X2; y1 = Y1; y2 = Y1;
            }
            else
            {
                y1 = Y1; y2 = Y2; x1 = X1; x2 = X1;
            }
            ChangeXY();
            /*
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            */
        }
        public Cable(double X1, double Y1, double X2, double Y2,bool z):this()
        {
            if(x)
            {
                x1 = X1; x2 = X2; y1 = Y1; y2 = Y1;
            }
            else
            {
                y1 = Y1; y2 = Y2;x1 = X1;x2 = X1;
            }
            ChangeXY();
            /*
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            */
            y = false;
        }
        public void SetXY(double X1, double Y1, double X2, double Y2)
        {
            if (x)
            {
                x1 = X1; x2 = X2;
            }
            else
            {
                y1 = Y1; y2 = Y2;
            }
            ChangeXY();
            /*
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            */
        }
        public void SetXY2(double X2, double Y2)
        {
            if(x)
            {
                x2 = X2;
            }
            else
                y2 = Y2;
            ChangeXY();
            /*
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
            */
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
            y = x;
            MainWindow.CableDrag = true;
            if(x)
            {
                MainWindow.CableX1 = x2;
                MainWindow.CableY1 = y1;
            }
            else
            {
                MainWindow.CableX1 = x1;
                MainWindow.CableY1 = y2;
            }
            /*
            MainWindow.CableX1 = CableUI.X2;
            MainWindow.CableY1 = CableUI.Y2;
            */
            Cable _cable = new Cable();
            DragDrop.DoDragDrop(_cable, _cable, DragDropEffects.Move);
        }
        private void CableUI_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void ChangeXY()
        {
            if (x)
            {
                if (x1 >= x2)
                {
                    Canvas.SetLeft(this, x2);
                    Canvas.SetTop(this, y1);
                    CableUI.Width = x1 - x2;
                }
                else
                {
                    Canvas.SetLeft(this, x1);
                    Canvas.SetTop(this, y1);
                    CableUI.Width = x2 - x1;
                }
            }
            else
            {
                if (y1 >= y2)
                {
                    Canvas.SetLeft(this, x2);
                    Canvas.SetTop(this, y2);
                    CableUI.Height = y1 - y2;
                }
                else
                {
                    Canvas.SetLeft(this, x2);
                    Canvas.SetTop(this, y1);
                    CableUI.Height = y2 - y1;
                }
            }
        }
    }
}
