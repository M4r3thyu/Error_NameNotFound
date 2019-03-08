using Microsoft.Win32;
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
        private static List<Logicgatescontrol> gates_UI = new List<Logicgatescontrol>();
        private static List<Cable> cables = new List<Cable>();
        private static int currentGate = 0;
        private static Canvas getCanvas;
        private static string gateType;
        private static bool gateFromButton, gateDelete = false, cableDrag = false, cableDirection = false;
        private static double cableX1, cableY1, cableX2, cableY2;
        private static Cable previewCable;
        private Image previewImage;
        private Point PreviewGateDropPoint, previewCableDropPoint;
        private static int id = 0;
        private static int prozessid = 1;
        private static int currentcable = 0;
        const double ScaleRate = 1.1;

        public static int Prozessid
        {
            get => prozessid;
            
            set => prozessid = value;
        }
        public MainWindow()
        {
            InitializeComponent();
            GetCanvas = Workspace;
        }
        public static int Id
        {
            get => id;
            set =>  id = value; 
        }
        public static bool CableDirection
        {
            get => cableDirection;
            set => cableDirection = value;
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
        public static int Currentcable
        {
            set => currentcable = value;
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
        public static Canvas GetCanvas { get => getCanvas; set => getCanvas = value; }
        public static int CurrentGate { get => currentGate; set => currentGate = value; }
        public static List<Cable> Cables { get => cables; set => cables = value; }
        public static List<Logicgatescontrol> Gates_UI { get => gates_UI; set => gates_UI = value; }
        private void GeneratePreview()
        {
            gateFromButton = true;
            CurrentGate = Gates_UI.IndexOf(Gates_UI.FirstOrDefault(c => c.Id == id));
            id++;
            if (Gates_UI[CurrentGate] != null)
            {
                DragDrop.DoDragDrop(Gates_UI[CurrentGate], Gates_UI[CurrentGate], DragDropEffects.Copy);
            }
        }
        private void AND_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AND _and = new AND(Id);
            gateType = "AND";
            Gates_UI.Add(_and);
            GeneratePreview();
        }
        private void LogicButton_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LogicButton _button = new LogicButton(Id);
            gateType = "LogicButton";
            Gates_UI.Add(_button);
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

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                st.ScaleX *= ScaleRate;
                st.ScaleY *= ScaleRate;
            }
            else
            {
                st.ScaleX /= ScaleRate;
                st.ScaleY /= ScaleRate;
            }
            Workspace.Background = System.Windows.Media.Brushes.GhostWhite;
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
                if (cableDirection)
                {
                    previewCableDropPoint.Y = (Convert.ToInt32(previewCableDropPoint.Y) / 25) * 25.0;
                    previewCableDropPoint.X = cableX1;
                }
                else
                {
                    previewCableDropPoint.X = (Convert.ToInt32(previewCableDropPoint.X) / 25) * 25.0;
                    previewCableDropPoint.Y = cableY1;
                }

                if (previewCable == null)
                {

                    previewCable = new Cable(cableX1, cableY1, previewCableDropPoint.X, previewCableDropPoint.Y, cableDirection,false);
                    Workspace.Children.Add(previewCable);
                }
                else
                {
                    previewCable.SetXY2(previewCableDropPoint.X, previewCableDropPoint.Y);
                }
            }
            else
            {
                PreviewGateDropPoint = e.GetPosition(Workspace);
                PreviewGateDropPoint.X = (Convert.ToInt32(PreviewGateDropPoint.X) / 25) * 25.0;
                PreviewGateDropPoint.Y = (Convert.ToInt32(PreviewGateDropPoint.Y) / 25) * 25.0;
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
                    Canvas.SetLeft(previewImage, PreviewGateDropPoint.X);
                    Canvas.SetTop(previewImage, PreviewGateDropPoint.Y);
                    Workspace.Children.Add(previewImage);
                }
                else
                {
                    Canvas.SetLeft(previewImage, PreviewGateDropPoint.X);
                    Canvas.SetTop(previewImage, PreviewGateDropPoint.Y);
                }
            }
        }
        private void canvas_Drop(object sender, DragEventArgs e)
        {
            Point DropPoint = e.GetPosition(Workspace);
            DropPoint.X = (Convert.ToInt32(DropPoint.X) / 25) * 25.0;
            DropPoint.Y = (Convert.ToInt32(DropPoint.Y) / 25) * 25.0;
            if (cableDrag)
            {
                Workspace.Children.Remove(previewCable);
                previewCable = null;
                if (e.Handled == false)
                {


                    cableX2 = DropPoint.X;
                    cableY2 = DropPoint.Y;

                    if (cableDirection)
                    {
                        cableX2 = cableX1;
                    }
                    else
                    {
                        cableY2 = cableY1;
                    }

                    Cable _cable = new Cable(cableX1, cableY1, cableX2, cableY2, cableDirection);
                    cables.Add(_cable);
                    currentcable = _cable.Id;
                    currentcable = cables.IndexOf(cables.FirstOrDefault(c => c.Id == currentcable));
                    Workspace.Children.Add(cables[currentcable]);

                    cableDirection = !cableDirection;
                }
                cableDrag = false;
            }
            else
            {
                Workspace.Children.Remove(previewImage);
                previewImage = null;
                Canvas _canvas = (Canvas)sender;
                if (gateFromButton)
                {
                    Workspace.Children.Add(Gates_UI[CurrentGate]);
                    Canvas.SetLeft(Gates_UI[CurrentGate], DropPoint.X);
                    Canvas.SetTop(Gates_UI[CurrentGate], DropPoint.Y);
                    // set the value to return to the DoDragDrop call
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    CurrentGate = Gates_UI.IndexOf(Gates_UI.FirstOrDefault(c => c.Id == CurrentGate));
                    if (e.KeyStates == DragDropKeyStates.ControlKey && e.Effects.HasFlag(DragDropEffects.Copy))
                    {

                        AND _and = new AND(id);
                        id++;
                        Gates_UI.Add(_and);
                        CurrentGate = Gates_UI.IndexOf(Gates_UI.FirstOrDefault(c => c.Id == id - 1));
                        Workspace.Children.Add(Gates_UI[CurrentGate]);
                        Canvas.SetLeft(Gates_UI[CurrentGate], PreviewGateDropPoint.X);
                        Canvas.SetTop(Gates_UI[CurrentGate], PreviewGateDropPoint.Y);
                        // set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Copy;
                    }
                    else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                    {
                        Canvas.SetLeft(Gates_UI[CurrentGate], PreviewGateDropPoint.X);
                        Canvas.SetTop(Gates_UI[CurrentGate], PreviewGateDropPoint.Y);
                        // set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Move;
                    }
                }

            }
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            GateDelete = !GateDelete;
        }
        public static void RemoveGate()
        {
            CurrentGate = Gates_UI.IndexOf(Gates_UI.FirstOrDefault(c => c.Id == CurrentGate));
            Canvas Workspace = (Canvas)Gates_UI[CurrentGate].Parent;
            Workspace.Children.Remove(Gates_UI[CurrentGate]);
            Gates_UI.Remove(Gates_UI[CurrentGate]);
            var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == CurrentGate);
            LogicGates.Remove_connections(CurrentGate);
            LogicGates.gates_logic.Remove(temp);
        }
        public static void RemoveCable()
        {
            var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == currentcable);
            LogicGates.Remove_connections(currentcable);
            LogicGates.gates_logic.Remove(temp);
            currentcable = cables.IndexOf(cables.FirstOrDefault(c => c.Id == currentcable));
            Canvas Workspace = (Canvas)cables[currentcable].Parent;
            Workspace.Children.Remove(cables[currentcable]);
            cables.Remove(cables[currentcable]);
        }
        public static void AddCable(Cable _cable)
        {
            cables.Add(_cable);
            currentcable = _cable.Id;
            currentcable = cables.IndexOf(cables.FirstOrDefault(c => c.Id == currentcable));
            GetCanvas.Children.Add(cables[currentcable]);
        }
        private void Print(object sender, RoutedEventArgs e)
        {
            Workspace.Background = System.Windows.Media.Brushes.White;
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { dialog.PrintVisual(Workspace, "Workspace"); }
            Workspace.Background = System.Windows.Media.Brushes.GhostWhite;
        }
    }
}