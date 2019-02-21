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
        public Cable()
        {
            InitializeComponent();
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
    }
}
