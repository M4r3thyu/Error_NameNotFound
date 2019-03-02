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
        public int id = 0;
        public Cable()
        {
            id = MainWindow.id;
            MainWindow.id++;
            InitializeComponent();
        }
        public Cable(double X1, double Y1, double X2, double Y2):this()
        {
            CableUI.X1 = X1;
            CableUI.Y1 = Y1;
            CableUI.X2 = X2;
            CableUI.Y2 = Y2;
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

        private void CableUI_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.CableDrag = true;
            
            MainWindow.CableX1 = CableUI.X2;
            MainWindow.CableY1 = CableUI.Y2;

            Cable _cable = new Cable();
            DragDrop.DoDragDrop(_cable, _cable, DragDropEffects.Move);
        }

        private void CableUI_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
