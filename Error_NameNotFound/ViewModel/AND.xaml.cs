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
        private string imagename;
        public AND()
        {
            InitializeComponent();
            anzahl++;
            imagename = "ANDUI" + Convert.ToString(anzahl);
        }
        public AND(AND g) :this()
        {
            this.ANDUI.Name = "ANDUI";
            this.ANDUI.Height = g.ANDUI.Height;
            this.ANDUI.Width = g.ANDUI.Width;
            this.ANDUI.Name = imagename;
            System.Drawing.Point position = new System.Drawing.Point(25,25);
            And x = new And(2,position);
            Save_Button_vm.save.Add(x);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                this.ANDUI.Name = "ANDUI";
                DataObject data = new DataObject();
                data.SetData("Double", ANDUI.Height);
                data.SetData("Object", this);
                this.ANDUI.Name = imagename;
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
