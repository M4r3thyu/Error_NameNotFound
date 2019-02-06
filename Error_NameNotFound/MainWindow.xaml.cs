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

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<UserControl> gates_UI = new List<UserControl>();
        public static int currentGate = 0, id = 0, prozessid = 1;
        public static Canvas GetCanvas;
        private static bool gateFromButton = true, gateDelete = false;
        private Image previousPreviewImage;
        public MainWindow()
        {
            InitializeComponent();
            GetCanvas = Workspace;
        }
        public static void Setcurrentgate(int id)
        {
            currentGate = id;
        }
        public static void SetGateFromButton(bool i)
        {
            gateFromButton = i;
        }
        public static bool GateDelete
        {
            get => gateDelete;
            set => gateDelete = value;
        }
        private void AND_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AND _and = new AND(id);
            id++;
            _and.Name = "ANDUI";
            gates_UI.Add(_and);
            if (gates_UI[currentGate] != null)
            {
                DragDrop.DoDragDrop(gates_UI[currentGate], gates_UI[currentGate], DragDropEffects.Copy);
                gateFromButton = true;
            }
            currentGate++;
        }
        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GateDelete)
            {
                if (this.Cursor != Cursors.Wait)
                    Mouse.OverrideCursor = new Cursor(Application.GetResourceStream(new Uri("Views/Delete-Cursor.cur", UriKind.Relative)).Stream);
            }

        }
        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            if (GateDelete)
            {
                if (this.Cursor != Cursors.Wait)

                    Mouse.OverrideCursor = null;
            }

        }
        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            if (previousPreviewImage != null)
            {
                Workspace.Children.Remove(previousPreviewImage);
            }
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
            Point previewDropPoint = e.GetPosition(Workspace);
            previewDropPoint.X = (Convert.ToInt32(previewDropPoint.X) / 25) * 25.0;
            previewDropPoint.Y = (Convert.ToInt32(previewDropPoint.Y) / 25) * 25.0;
            BitmapImage previewBitmap = new BitmapImage(new Uri("pack://application:,,,/Pictures/And.png", UriKind.Absolute));
            Image previewImage = new Image();
            previewImage.Source = previewBitmap;
            previewImage.Height = 100;
            previewImage.Width = 100;
            Canvas.SetLeft(previewImage, previewDropPoint.X);
            Canvas.SetTop(previewImage, previewDropPoint.Y);
            Workspace.Children.Add(previewImage);
            previousPreviewImage = previewImage;

        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            if (previousPreviewImage != null)
            {
                Workspace.Children.Remove(previousPreviewImage);
            }
            Canvas _canvas = (Canvas)sender;
            if (_canvas != null && gates_UI[currentGate] != null)
            {
                Point dropPoint = e.GetPosition(Workspace);
                dropPoint.X = (Convert.ToInt32(dropPoint.X) / 25) * 25.0;
                dropPoint.Y = (Convert.ToInt32(dropPoint.Y) / 25) * 25.0;
                if (gateFromButton)
                {
                    currentGate = id - 1;
                    Workspace.Children.Add(gates_UI[currentGate]);
                    Canvas.SetLeft(gates_UI[currentGate], dropPoint.X);
                    Canvas.SetTop(gates_UI[currentGate], dropPoint.Y);
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
                        Canvas.SetLeft(gates_UI[currentGate], dropPoint.X);
                        Canvas.SetTop(gates_UI[currentGate], dropPoint.Y);
                        // set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Copy;
                    }
                    else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                    {
                        Canvas.SetLeft(gates_UI[currentGate], dropPoint.X);
                        Canvas.SetTop(gates_UI[currentGate], dropPoint.Y);
                        // set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Move;
                    }
                }

            }
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (GateDelete)
            {
                GateDelete = false;
            }
            else
            {
                GateDelete = true;
            }
        }
        public static void RemoveGate(int id)
        {
            currentGate = id;
            Canvas Workspace = (Canvas)gates_UI[currentGate].Parent;
            Workspace.Children.Remove(gates_UI[currentGate]);
            var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == currentGate);
            LogicGates.Remove_connections(currentGate);
            LogicGates.gates_logic.Remove(temp);
            LogicGates.in_or_out = 0;

        }

        private void Print(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { dialog.PrintVisual(Workspace, "Workspace"); }
        }

        private void Prozess_Button(object sender, RoutedEventArgs e)
        {
            Prozesstoken test = new Prozesstoken(prozessid);
            prozessid++;
        }
    }
}