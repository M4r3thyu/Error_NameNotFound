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
using System.Windows.Threading;

namespace Error_NameNotFound.ViewModel
{
    public class Logicgatescontrol : UserControl
    {
        protected int id;
        protected int connectedCablesCount;
        protected int anz_input;
        protected int anz_output;

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
                MainWindow.CurrentGate=id;
                MainWindow.RemoveGate();
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
        public void StartCableDrag()
        {
            MainWindow.CableDrag = true;
            MainWindow.CableDirection = false;
            Cable _cable = new Cable();

            DragDrop.DoDragDrop(_cable, _cable, DragDropEffects.Move);
        }
        public void StopCableDrag(double x2,double y2)
        {
            Canvas c = MainWindow.GetCanvas;
            c.Children.Remove(MainWindow.PreviewCable);
            MainWindow.PreviewCable = null;
            Cable _cable = new Cable(MainWindow.CableX1, MainWindow.CableY1, x2, y2, MainWindow.CableDirection);
            MainWindow.AddCable(_cable);
            MainWindow.CableDrag = false;
        }
        public void UpdateCablepositions(double gatepositionXnew,double gatepositionYnew, double gatepositionXold, double gatepositionYold)
        {
            List<Cable> x_cables = new List<Cable>();
            connectedCablesCount = 0;
            for (int i = 0; i < LogicGates.connections.Count; i += 4)
            {
                if (id == LogicGates.connections[i])
                {
                    connectedCablesCount++;
                    x_cables.Add(MainWindow.Cables.FirstOrDefault(c => c.Id == LogicGates.connections[i + 2]));   // haengt am eingang connections[i + 1] vom bewegten Baustein
                }
                if (id == LogicGates.connections[i+2])
                {
                    connectedCablesCount++;
                    x_cables.Add(MainWindow.Cables.FirstOrDefault(c => c.Id == LogicGates.connections[i + 2]));   // haengt am eingang connections[i + 1] vom bewegten Baustein
                }
            }
           
            Canvas Workspace = MainWindow.GetCanvas;

            double oldCablepositionX1;
            double oldCablepositionY1;
            double oldCablepositionX2;
            double oldCablepositionY2;

            if (connectedCablesCount != 0)
            {
                //Cable[] c = new Cable[10]; //<=

                for (int i=0;i>connectedCablesCount;i++)
                {
                    
                    oldCablepositionX1 = x_cables[i].X1;
                    oldCablepositionY1 = x_cables[i].Y1;
                    oldCablepositionX2 = x_cables[i].X2;
                    oldCablepositionY2 = x_cables[i].Y2;

                    x_cables[i].X2 = gatepositionXnew + (oldCablepositionX2 - gatepositionXold);
                    x_cables[i].Y2 = gatepositionYnew + (oldCablepositionY2 - gatepositionYold);

                    //c[i].X2 = gatepositionXnew + c[i].DifferenceToGatepositionX;
                    //c[i].Y2 = gatepositionYnew + c[i].DifferenceToGatepositionY;

                    if (x_cables[i].Y2 != oldCablepositionY2)
                    {
                        x_cables[i].Y1 = x_cables[i].Y2;
                        bool yCableIsConnnected =false; //<= if x has cable as inbound connection
                        bool yCableHasAdditionalConnections=false; //<= if y has more than 1 outbound connections
                        Cable y_cable = null;
                        for (int j = 0; j < LogicGates.connections.Count; j += 4)                                       //Abfrage if x comes from a gate (! y cable connected)
                        {
                            if (x_cables[i].Id == LogicGates.connections[j + 2])
                            {
                                y_cable = MainWindow.Cables.FirstOrDefault(c => c.Id == LogicGates.connections[j + 2]);
                                yCableIsConnnected = true;
                                for (int k = 0; k < LogicGates.connections.Count; k++)                                  //Abfrage if y cable has more than 1 output id (Additional connections)
                                {
                                    if (y_cable.Id == LogicGates.connections[k + 2])
                                    {
                                        if(x_cables[i].Id != LogicGates.connections[k])
                                        {
                                            yCableHasAdditionalConnections = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (yCableIsConnnected)
                        {
                            if (yCableHasAdditionalConnections)
                            {
                                Outputbutton_vm.Output_Click(x_cables[i].Id, 0);
                                Cable yCableNew = new Cable(oldCablepositionX1,oldCablepositionY1,oldCablepositionX1,x_cables[i].Y2,true);
                                MainWindow.Cables.Add(yCableNew);
                                int cablesIndex = MainWindow.Cables.IndexOf(MainWindow.Cables.FirstOrDefault(l => l.Id == yCableNew.Id));
                                Workspace.Children.Add(MainWindow.Cables[cablesIndex]);
                                for (int j = 0; j < LogicGates.connections.Count; j+=4)
                                {
                                    if (x_cables[i].Id == LogicGates.connections[j + 2])
                                        LogicGates.connections[j] = yCableNew.Id;
                                }
                                /*logic Connection Update
                                    cable y id = 0
                                    cable x id = 1
                                    new y cable id = 2
                                    00 10 --> 20 10 
                                    added connection 
                                    00 20
                                */
                            }
                            else
                            {
                                //Cable yCable = new Cable(); //<=
                                y_cable.Y2 = x_cables[i].Y2;
                            }
                        }
                    }
                }
            }
        }
        public virtual void ChangeColorInOut()
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
                                Button myButton = (Button)FindName("input"+i);
                                myButton.Background = System.Windows.Media.Brushes.GreenYellow;
                            }
                            else
                            {
                                Button myButton = (Button)FindName("input"+i);
                                myButton.Background = System.Windows.Media.Brushes.Purple;
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        for (int i = 0; i < anz_output; i++)
                        {
                            if (temp.Output[i])
                            {
                                Button myButton = (Button)FindName("output" + i);
                                myButton.Background = System.Windows.Media.Brushes.GreenYellow;
                            }
                            else
                            {
                                Button myButton = (Button)FindName("output" + i);
                                myButton.Background = System.Windows.Media.Brushes.Purple;
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
