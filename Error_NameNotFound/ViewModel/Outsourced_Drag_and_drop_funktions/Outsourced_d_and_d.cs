using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Error_NameNotFound.ViewModel.Outsourced_Drag_and_drop_funktions
{
    class Outsourced_d_and_d
    {
        public static void OnMouseLeftButtonDown(int id)
        {
            if (MainWindow.GateDelete)
            {
                MainWindow.RemoveGate(id);
            }
        }
        public static void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
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
    }
}
