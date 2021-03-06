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
using System.Windows.Threading;

namespace Error_NameNotFound.ViewModel
{
    public partial class FF_RS_c_ms : Logicgatescontrol
    {
        private L_FF_RS_c_ms l_FF_RS_c_ms;
        public FF_RS_c_ms() : base()
        {
            InitializeComponent();
            anz_input = 3;
            anz_output = 2;
            Name = "FF_RS_C_MSUI";
        }
        public FF_RS_c_ms(int id) : base(id)
        {
            InitializeComponent();
            anz_input = 3;
            anz_output = 2;
            Name = "FF_RS_C_MSUI";
            l_FF_RS_c_ms = new L_FF_RS_c_ms(id, this);
            LogicGates.gates_logic.Add(l_FF_RS_c_ms);
            ChangeColorInOut();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!textboxIsUsed)
            {
                base.OnMouseMove(e);
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    MainWindow.CurrentGate = id;
                    MainWindow.SetGateFromButton(false);
                    MainWindow.GateType = "FF_RS_C_MS";
                    // Package the data.
                    DataObject data = new DataObject();
                    data.SetData("Double", FF_RS_C_MSUI.Height);
                    data.SetData("Object", this);
                    // Inititate the drag-and-drop operation.
                    DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
                }
            }
        }
        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            Outputbutton_vm.Output_Click(id, 0);
            MainWindow.CableX1 = Canvas.GetLeft(this) + 90;
            MainWindow.CableY1 = Canvas.GetTop(this) + 75;
            StartCableDrag();
        }
        private void Output1_Click(object sender, RoutedEventArgs e)
        {
            Outputbutton_vm.Output_Click(id, 1);
            MainWindow.CableX1 = Canvas.GetLeft(this) + 90;
            MainWindow.CableY1 = Canvas.GetTop(this) + 25;
            StartCableDrag();
        }
        private void DelConnection_Input0(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 0);
        }
        private void DelConnection_Input1(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 1);
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
