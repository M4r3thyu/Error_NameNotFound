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
    public partial class Light : Logicgatescontrol
    {
        private L_Light l_light;
        public Light() : base()
        {
            InitializeComponent();
            anz_input = 1;
            anz_output = 0;
            Name = "LightUI";
        }
        public Light(int id) : base(id)
        {
            InitializeComponent();
            anz_input = 1;
            anz_output = 0;
            Name = "LightUI";
            l_light = new L_Light(id, this);
            LogicGates.gates_logic.Add(l_light);
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
                    MainWindow.GateType = "Light";
                    // Package the data.
                    DataObject data = new DataObject();
                    data.SetData("Double", LightUI.Height);
                    data.SetData("Object", this);
                    // Inititate the drag-and-drop operation.
                    DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
                }
            }
        }
        private void DelConnection_Input0(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 0);
        }
        private void Input0_Drop(object sender, DragEventArgs e)
        {
            StopCableDrag(Canvas.GetLeft(this), Canvas.GetTop(this) + 25);
            Inputbutton_vm.Input_Click(id, 0);
            e.Handled = true;
        }
        public override void ChangeColorInOut()
        {
            Dispatcher.BeginInvoke((Action)delegate ()
            {
                var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == id);
                if (temp != null)
                {
                    try
                    {
                        // Set property or change UI compomponents.              
                        for (int i = 0; i < anz_input; i++)
                        {
                            if (temp.Input[i])
                            {
                                Button myButton = (Button)FindName("input" + i);
                                myButton.Background = System.Windows.Media.Brushes.GreenYellow;
                                LightUI.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/LightOn.png", UriKind.Absolute));
                            }
                            else
                            {
                                Button myButton = (Button)FindName("input" + i);
                                myButton.Background = System.Windows.Media.Brushes.Purple;
                                LightUI.Source=new BitmapImage(new Uri("pack://application:,,,/Pictures/LightOff.png", UriKind.Absolute));
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }, DispatcherPriority.SystemIdle);
        }
    }
}

