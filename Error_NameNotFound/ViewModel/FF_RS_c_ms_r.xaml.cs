﻿using System;
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
    /// Interaction logic for FF_RS_c_ms_r.xaml
    /// </summary>
    public partial class FF_RS_c_ms_r : UserControl
    {
        public FF_RS_c_ms_r()
        {
            InitializeComponent();
        }
        public FF_RS_c_ms_r(FF_RS_c_ms_r g)
        {
            InitializeComponent();
            this.FF_RS_c_ms_rUI.Height = g.FF_RS_c_ms_rUI.Height;
            this.FF_RS_c_ms_rUI.Width = g.FF_RS_c_ms_rUI.Height;
        }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            // Package the data.
            DataObject data = new DataObject();
            data.SetData("Double", FF_RS_c_ms_rUI.Height);
            data.SetData("Object", this);

            // Inititate the drag-and-drop operation.
            DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
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
}
}
