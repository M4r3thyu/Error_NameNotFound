﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Error_NameNotFound.Model;
using Error_NameNotFound.ViewModel;
using System.Threading;

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Logicgatescontrol> gates_UI = new List<Logicgatescontrol>();
        public static List<Cable> cables = new List<Cable>();
        public static int currentGate = 0, id = 0, prozessid = 1;
        public static Canvas GetCanvas;
        private static string gateType;
        private static bool gateFromButton, gateDelete = false,cableDrag=false,cable_xy=false;
        private static double cableX1, cableY1, cableX2, cableY2;
        private static Cable previewCable;
        private Image previewImage;
        private Point gateDropPoint,previewCableDropPoint;
        public MainWindow()
        {
            InitializeComponent();
            GetCanvas = Workspace;
        }
        public static Cable PreviewCable
        {
            get => previewCable;
            set => previewCable = value;
        }
        public static double CableX1
        {
            get => cableX1;
            set => cableX1 = value;
        }
        public static double CableY1
        {
            get => cableY1;
            set => cableY1 = value;
        }
        public static double CableX2
        {
            get => cableX2;
            set => cableX2 = value;
        }
        public static double CableY2
        {
            get => cableY2;
            set => cableY2 = value;
        }
        public static void Setcurrentgate(int id)
        {
            currentGate = id;
        }
        public static void SetGateFromButton(bool i)
        {
            gateFromButton = i;
        }
        public static bool CableDrag
        {
            get => cableDrag;
            set => cableDrag = value;
        }
        public static bool GateDelete
        {
            get => gateDelete;
            set => gateDelete = value;
        }
        public static string GateType
        {
            get => gateType;
            set => gateType = value;
        }
        private void GeneratePreview()
        {
            gateFromButton = true;
            id++;
            if (gates_UI[currentGate] != null)
            {
                DragDrop.DoDragDrop(gates_UI[currentGate], gates_UI[currentGate], DragDropEffects.Copy);
            }
        }
        private void AND_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AND _and = new AND(id);
            gateType = "AND";
            gates_UI.Add(_and);
            GeneratePreview();
        }
        private void LogicButton_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LogicButton _button = new LogicButton(id);
            gateType = "LogicButton";
            gates_UI.Add(_button);
            GeneratePreview();
        }
        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GateDelete)
            {
                    Mouse.OverrideCursor = new Cursor(Application.GetResourceStream(new Uri("Views/Delete-Cursor.cur", UriKind.Relative)).Stream);
            }
        }
        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            Workspace.Children.Remove(previewImage);
            previewImage = null;
            Workspace.Children.Remove(previewCable);
            previewCable = null;
            if (GateDelete)
            {
                    Mouse.OverrideCursor = null;
            }
        }
        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                // These Effects values are used in the drag source's
                // GiveFeedback event handler to determine which cursor to display.
                if (e.KeyStates == DragDropKeyStates.ControlKey)
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.Move;
                }
            }
            if (cableDrag)
            {
                previewCableDropPoint = e.GetPosition(Workspace);
                previewCableDropPoint.X = (Convert.ToInt32(previewCableDropPoint.X) / 25) * 25.0;
                previewCableDropPoint.Y = (Convert.ToInt32(previewCableDropPoint.Y) / 25) * 25.0;
                if (previewCable == null)
                {
                    previewCable = new Cable(cableX1, cableY1, previewCableDropPoint.X, previewCableDropPoint.Y);
                    Workspace.Children.Add(previewCable);
                }
                else
                {
                    previewCable.SetXY2(previewCableDropPoint.X, previewCableDropPoint.Y);
                }
            }
            else
            {
                gateDropPoint = e.GetPosition(Workspace);
                gateDropPoint.X = (Convert.ToInt32(gateDropPoint.X) / 25) * 25.0;
                gateDropPoint.Y = (Convert.ToInt32(gateDropPoint.Y) / 25) * 25.0;
                if (previewImage == null)
                {
                    previewImage = new Image();
                    BitmapImage previewBitmap;
                    switch (gateType)
                    {
                        case "AND":
                            previewBitmap = new BitmapImage(new Uri("pack://application:,,,/Pictures/And.png", UriKind.Absolute));
                            previewImage.Source = previewBitmap;
                            previewImage.Height = 100;
                            previewImage.Width = 100;
                            break;
                        case "LogicButton":
                            previewBitmap = new BitmapImage(new Uri("pack://application:,,,/Pictures/LogicButton.png", UriKind.Absolute));
                            previewImage.Source = previewBitmap;
                            previewImage.Height = 50;
                            previewImage.Width = 50;
                            break;
                        default:
                            previewBitmap = new BitmapImage(new Uri("pack://application:,,,/Pictures/And.png", UriKind.Absolute));
                            previewImage.Source = previewBitmap;
                            previewImage.Height = 100;
                            previewImage.Width = 100;
                            break;
                    }
                    Canvas.SetLeft(previewImage, gateDropPoint.X);
                    Canvas.SetTop(previewImage, gateDropPoint.Y);
                    Workspace.Children.Add(previewImage);
                }
                else
                {
                    Canvas.SetLeft(previewImage, gateDropPoint.X);
                    Canvas.SetTop(previewImage, gateDropPoint.Y);
                }
            }
        }
        private void canvas_Drop(object sender, DragEventArgs e) 
        {
            if (cableDrag)
            {
                Workspace.Children.Remove(previewCable);
                previewCable = null;
                if (e.Handled == false)
                {
                    Point cableDropPoint = e.GetPosition(Workspace);
                    cableX2 = (Convert.ToInt32(cableDropPoint.X) / 25) * 25.0;
                    cableY2 = (Convert.ToInt32(cableDropPoint.Y) / 25) * 25.0;


                    Cable _cable = new Cable(cableX1, cableY1, cableX2, cableY2);

                    Workspace.Children.Add(_cable);
                }
                cableDrag = false;
            }
            else
            {
                Workspace.Children.Remove(previewImage);
                previewImage = null;
<<<<<<< HEAD
                //currentGate = gates_UI.IndexOf(gates_UI.FirstOrDefault(c => c.GatesUIindex == currentGate));
=======
                currentGate = gates_UI.IndexOf(gates_UI.FirstOrDefault(c => c.Id == currentGate));
>>>>>>> parent of a0afd8e... fixed gatesUI index problem after removing gates
                Canvas _canvas = (Canvas)sender;
                if (_canvas != null && gates_UI[currentGate] != null)
                {
                    if (gateFromButton)
                    {
                        currentGate = id - 1;
                        Workspace.Children.Add(gates_UI[currentGate]);
                        Canvas.SetLeft(gates_UI[currentGate], gateDropPoint.X);
                        Canvas.SetTop(gates_UI[currentGate], gateDropPoint.Y);
                        // set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Copy;
                    }
                    else
                    {
                        if (e.KeyStates == DragDropKeyStates.ControlKey && e.Effects.HasFlag(DragDropEffects.Copy))
                        {

                            AND _and = new AND(id);
                            id++;
                            gates_UI.Add(_and);
                            currentGate = _and.Id;
                            Workspace.Children.Add(gates_UI[currentGate]);
                            Canvas.SetLeft(gates_UI[currentGate], gateDropPoint.X);
                            Canvas.SetTop(gates_UI[currentGate], gateDropPoint.Y);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            Canvas.SetLeft(gates_UI[currentGate], gateDropPoint.X);
                            Canvas.SetTop(gates_UI[currentGate], gateDropPoint.Y);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            GateDelete = !GateDelete;
        }
        public static void RemoveGate(int id)
        {
            currentGate = id;
            Canvas Workspace = (Canvas)gates_UI[currentGate].Parent;
            Workspace.Children.Remove(gates_UI[currentGate]);
            gates_UI.Remove(gates_UI[currentGate]);
            var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == currentGate);
            LogicGates.Remove_connections(currentGate);
            LogicGates.gates_logic.Remove(temp);
            LogicGates.in_or_out = 0;
        }
        public static void RemoveCable(Cable c)
        {
            Canvas Workspace = (Canvas)c.Parent;
            Workspace.Children.Remove(c);

        }
        private void Print(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { dialog.PrintVisual(Workspace, "Workspace"); }
        }
    }
}