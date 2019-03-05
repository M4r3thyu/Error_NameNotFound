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


namespace Error_NameNotFound.ViewModel
{
    public class Logicgatescontrol : UserControl
    {
        protected int id;
        public Logicgatescontrol()
        {
            id = 0;
        }
        public Logicgatescontrol(int id) : this()
        {
            this.id = id;
        }
        public int Id
        {
            get => id;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (MainWindow.GateDelete)
            {
                MainWindow.RemoveGate(id);
            }
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.     
            if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Hand);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }
        public virtual void ChangeColorInOut() { }
        public void StartCableDrag()
        {
            MainWindow.CableDrag = true;
            Cable _cable = new Cable();

            DragDrop.DoDragDrop(_cable, _cable, DragDropEffects.Move);
        }
        public void StopCableDrag(object sender, DragEventArgs e)
        {

            MainWindow.CableDrag = false;
            Canvas c = MainWindow.GetCanvas;

            c.Children.Remove(MainWindow.PreviewCable);
            MainWindow.PreviewCable = null;

            Point p = e.GetPosition(c);
            p.X = (Convert.ToInt32(p.X) / 25) * 25.0;
            p.Y = (Convert.ToInt32(p.Y) / 25) * 25.0;

            Cable _cable = new Cable(MainWindow.CableX2, MainWindow.CableY2, p.X, p.Y);
            c.Children.Add(_cable);

            e.Handled = true;
        }

    }
}
