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

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for AND.xaml
    /// </summary>
    public partial class AND : UserControl
    {
        private static int anzahl=0;
        //private string imagename;
        private int id;
        public AND()
        {
            InitializeComponent();
            id = 0;
            anzahl++;
      //      imagename = "ANDUI" + Convert.ToString(id);
        }
        public AND(int id) :this()
        {
            this.id = id;
       //     imagename = "ANDUI" + Convert.ToString(id);
    //        ANDUI.Name = imagename;
        }
        public AND(AND g) :this()
        {
            ANDUI.Name = "ANDUI";
            ANDUI.Height = g.ANDUI.Height;
            ANDUI.Width = g.ANDUI.Width;
          //  ANDUI.Name = imagename;
            System.Drawing.Point position = new System.Drawing.Point(25,25);
            And x = new And(2,position);
            Save_Button_vm.save.Add(x);
        }
        public int Id
        {
            get => id;
        }
        public double GetANDUI_Height()
        {
            double heightsave;
            ANDUI.Name = "ANDUI";
            heightsave = ANDUI.Height;
          //  ANDUI.Name = imagename;
            return heightsave;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Setcurrentgate(id);
                // Package the data.
                ANDUI.Name = "ANDUI";
                DataObject data = new DataObject();
                data.SetData("Double", ANDUI.Height);
                data.SetData("Object", this);
              //  ANDUI.Name = imagename;
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Hand);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        private void Input0_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Input1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Output0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Output1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
