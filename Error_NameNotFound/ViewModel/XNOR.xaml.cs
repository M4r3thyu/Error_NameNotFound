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
    /// Interaction logic for XNOR.xaml
    /// </summary>
    public partial class XNOR : UserControl
    {
        public XNOR()
        {
            InitializeComponent();
        }
        public XNOR(XNOR g)
        {
            InitializeComponent();
            Name = "XNORUI";
            l_xnor = new L_Xnor(id, this);
            LogicGates.gates_logic.Add(l_xnor);
            ChangeColorInOut();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Double", XNORUI.Height);
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
                var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == id);
                if (temp != null)
                {
                    // Set property or change UI compomponents.              
                    if (temp.Input[0])
                        input0.Background = System.Windows.Media.Brushes.GreenYellow;
                    else
                        input0.Background = System.Windows.Media.Brushes.Purple;

                    if (temp.Input[1])
                        input1.Background = System.Windows.Media.Brushes.GreenYellow;
                    else
                        input1.Background = System.Windows.Media.Brushes.Purple;

                    if (temp.Output[0])
                        output0.Background = System.Windows.Media.Brushes.GreenYellow;
                    else
                        output0.Background = System.Windows.Media.Brushes.Purple;

                    if (temp.Output[1])
                        output1.Background = System.Windows.Media.Brushes.GreenYellow;
                    else
                        output1.Background = System.Windows.Media.Brushes.Purple;
                }
            });
        }
        private void Input0_Drop(object sender, DragEventArgs e)
        {
            StopCableDrag(Canvas.GetLeft(this) + 10, Canvas.GetTop(this) + 25);
            Inputbutton_vm.Input_Click(id, 0);
            e.Handled = true;
        }
        private void Input1_Drop(object sender, DragEventArgs e)
        {
            StopCableDrag(Canvas.GetLeft(this) + 10, Canvas.GetTop(this) + 75);
            Inputbutton_vm.Input_Click(id, 1);
            e.Handled = true;
        }
    }
}
