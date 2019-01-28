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
        public static int currentGate=0;
        private static bool gateFromButton=false;
        public MainWindow()
        {
            InitializeComponent();
        }
        public static void Setcurrentgate(int id)
        {
            currentGate=id;
        }
        public static void SetGateFromButton(bool i)
        {
            gateFromButton = i;
        }
        private void AND_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int id=0;
            foreach (UserControl element in gates_UI)
                id++;
            AND _and = new AND(id);
            gates_UI.Add(_and);
            currentGate = _and.Id;
            if (gates_UI[currentGate] != null)
            {
                DragDrop.DoDragDrop(gates_UI[currentGate], gates_UI[currentGate], DragDropEffects.Copy);
                gateFromButton = true;
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
            if(_canvas!=null&& gates_UI[currentGate] != null)
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
                        int id = 0;
                        foreach (UserControl element in gates_UI)
                            id++;
                        AND _and = new AND(id);
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
        private void Print(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { dialog.PrintVisual(Workspace, "Workspace"); }
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog()
                {
                    Filter = "Xaml Files(*.xaml)|*.xaml|All(*.*)|*"
                };
                if (dialog.ShowDialog() == true)
                {
                    FileStream fs = File.Open(dialog.FileName, FileMode.Create);
                    XamlWriter.Save(Workspace, fs);
                    string connections = "";
                    connections = LogicGates.Connections;
                    fs.Close();
                    File.AppendAllText(dialog.FileName, connections);
                    
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Unhandled Error occoured /n" + x.Message);
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
                    gates_UI=new List<UserControl>();
                    LogicGates.gates_logic = new List<LogicGates>();
                    int gateindex = 0;
                    string Loadfiletext = File.ReadAllText(openFileDialog.FileName) as string;
                    string[] connections = Loadfiletext.Split('|');
                    string[] loadsplit=connections[0].Split(' ');
                    string[] merker;
                    double canvas_Left = 0, canvas_Top = 0;
                    for (int i = 10; i < loadsplit.Length;i++)
                    {
                        if (loadsplit[i].Contains("Canvas.Left="))
                        {
                            merker = loadsplit[i].Split('"');
                            canvas_Left = double.Parse(merker[1]);
                        }
                        if (loadsplit[i].Contains("Canvas.Top="))
                        {
                            merker = loadsplit[i].Split('"');
                            canvas_Top = double.Parse(merker[1]);
                        }
                        switch (loadsplit[i])
                        {
                            case "Name=\"ANDUI\"":
                                    AND _and = new AND(gateindex);
                                    gates_UI.Add(_and);
                                    Workspace.Children.Add(gates_UI[gateindex]);
                                    Canvas.SetLeft(gates_UI[gateindex],  canvas_Left);
                                    Canvas.SetTop(gates_UI[gateindex], canvas_Top);
                                    gateindex++;
                                break;
                            default:
                                break;
                        }
                    }
                    for (int i = 2; i < connections.Length; i++)
                    {
                        string[] call=null;
                        call=connections[i].Split(' ');
                        //                   //output id                                inportid                    inportnr                ouportnr        
                        LogicGates.gates_logic[Convert.ToInt32(call[1])].Connection(Convert.ToInt32(call[2]), Convert.ToInt32(call[3]), Convert.ToInt32(call[4]));
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