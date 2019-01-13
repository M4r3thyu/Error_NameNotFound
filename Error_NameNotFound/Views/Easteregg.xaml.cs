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
using Error_NameNotFound.Model;

namespace Error_NameNotFound.Views
{
    /// <summary>
    /// Interaction logic for Easteregg.xaml
    /// </summary>
    public partial class Easteregg : UserControl
    {
        public Easteregg()
        {
            InitializeComponent();
            Easteregglabel.Content = null;
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           Easteregglabel.Content =  Convert.ToInt32(Releasedate.Days_Releasedate());
        }
    }
}
