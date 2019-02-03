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
        private static List<UserControl> gates_UI = new List<UserControl>();
        public static int currentGate = 0, id=0;
        private static bool gateFromButton = true, gateDelete = false;
        public MainWindow()
        {
            InitializeComponent();
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

                    Mouse.OverrideCursor = Cursors.Arrow;
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
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            Canvas _canvas = (Canvas)sender;
            if (_canvas != null && gates_UI[currentGate] != null)
            {
                Point dropPoint = e.GetPosition(this.Workspace);
                dropPoint.X = (Convert.ToInt32(dropPoint.X) / 25) * 25.0;
                dropPoint.Y = (Convert.ToInt32(dropPoint.Y) / 25) * 25.0;
                if (gateFromButton)
                {
                    Workspace.Children.Add(gates_UI[currentGate]);
                    Canvas.SetLeft(gates_UI[currentGate], dropPoint.X - 50);
                    Canvas.SetTop(gates_UI[currentGate], dropPoint.Y - 50);
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
                        Canvas.SetLeft(gates_UI[currentGate], dropPoint.X - 50);
                        Canvas.SetTop(gates_UI[currentGate], dropPoint.Y - 50);
                        // set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Copy;
                    }
                    else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                    {
                        Canvas.SetLeft(gates_UI[currentGate], dropPoint.X - 50);
                        Canvas.SetTop(gates_UI[currentGate], dropPoint.Y - 50);
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
            LogicGates.inout = 0;

        }

        private void Print(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { dialog.PrintVisual(Workspace, "Workspace"); }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
           // try
            {
                SaveFileDialog dialog = new SaveFileDialog()
                {
                    Filter = "Xaml Files(*.logic)|*.logic|All(*.*)|*"
                };
                if (dialog.ShowDialog() == true)
                {
                    FileStream fs = File.Open(dialog.FileName, FileMode.Create);
                    // XamlWriter.Save(Workspace, fs);
                    fs.Close();
                    string bausteine = " |  index left top | ";
                    for (int i = 0; i < LogicGates.gates_logic.Count; i++)
                    {
                        var temp = gates_UI[i];

                        bausteine += " " + LogicGates.gates_logic[i].id + " ";
                        bausteine += Canvas.GetLeft(gates_UI[i]);
                        bausteine += " ";
                        bausteine += Canvas.GetTop(gates_UI[i]);
                        bausteine += " ";
                        bausteine += gates_UI[i].Name;
                        bausteine += " | ";
                    }
                    string connections = " ";
                    connections = LogicGates.Connections;
                    string save = bausteine + " $ " + connections;
                    File.AppendAllText(dialog.FileName, save);

                }
            }
            //catch (Exception x)
            {
           //     MessageBox.Show("Unhandled Error occoured /n" + x.Message);
            }
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    FileStream fs = File.Open(openFileDialog.FileName, mode: FileMode.Open, access: FileAccess.Read);
                    fs.Close();
                    this.Workspace.Children.Clear();
                    gates_UI = new List<UserControl>();
                    LogicGates.gates_logic = new List<LogicGates>();
                    LogicGates.connections = new List<int>();
                    id = 0;
                    int gateindex = 0;
                    string Loadfiletext = File.ReadAllText(openFileDialog.FileName) as string;
                    string[] loadsplit = Loadfiletext.Split('$');
                    string[] bausteine = loadsplit[0].Split('|');
                    string[] connections = loadsplit[1].Split('|');
                    string[] merker;
                    double canvas_Left = 0, canvas_Top = 0;
                    for (int i = 2; i < bausteine.Length - 1; i++)
                    {
                        merker = bausteine[i].Split(' ');
                        id= Convert.ToInt32(merker[2]);
                        if (merker[3] == "NaN")
                            canvas_Left = 9999999;
                        else
                            canvas_Left = double.Parse(merker[3]);
                        if (merker[4] == "NaN")
                            canvas_Top = 9999999;
                        else
                            canvas_Top = double.Parse(merker[4]);
                        if (canvas_Top != 9999999)
                        {
                            switch (merker[5])
                            {
                                case "ANDUI":
                                    AND _and = new AND(id);
                                    id++;
                                    gates_UI.Add(_and);

                                    break;
                                default:
                                    break;
                            }
                            Workspace.Children.Add(gates_UI[gateindex]);
                            Canvas.SetLeft(gates_UI[gateindex], canvas_Left);
                            Canvas.SetTop(gates_UI[gateindex], canvas_Top);
                            gateindex++;
                        }
                    }
                    for (int i = 2; i < connections.Length; i++)
                    {
                        string[] call = null;
                        call = connections[i].Split(' ');
                        var temp = LogicGates.gates_logic.First(c => c.id == Convert.ToInt32(call[1]));
                        LogicGates.outid = Convert.ToInt32(call[1]);
                        LogicGates.outnr = Convert.ToInt32(call[2]);
                        LogicGates.inid = Convert.ToInt32(call[3]);
                        LogicGates.innr = Convert.ToInt32(call[4]);
                        if (temp != null)
                            temp.Connection();
                        //                   //output id                                inportid                    inportnr                ouportnr     
                        // LogicGates.gates_logic[Convert.ToInt32(call[1])].Connection(Convert.ToInt32(call[2]), Convert.ToInt32(call[3]), Convert.ToInt32(call[4]));
                    }
                }
            }
            catch (XamlParseException)
            {
                MessageBox.Show("Wrong File");
            }
            catch (Exception x)
            {
                MessageBox.Show("Unhandled Error occoured \n" + x.Message);
            }
        }
    }
}