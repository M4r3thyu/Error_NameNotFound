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

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<UserControl> gate = new List<UserControl>();
        public static int currentgate=0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public static void Setcurrentgate(int id)
        {
            currentgate=id;
        }
        private void AND_Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int id=0;
            foreach (UserControl element in gate)
                id++;
            AND _and = new AND(id);
            gate.Add(_and);
            currentgate = _and.Id;
            if (gate[currentgate] != null)
            {
                DragDrop.DoDragDrop(gate[currentgate], gate[currentgate], DragDropEffects.Copy);
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
            //Point dropPoint = e.GetPosition(this.Workspace);

            //UserControl gate = new AND();
            //gate.Content = draggeditem.GetGateData();
            //Workspace.Children.Add(gate);

            //Canvas.SetLeft(gate, dropPoint.X - 50);
            //Canvas.SetTop(gate, dropPoint.Y - 50);

            Canvas _canvas = (Canvas)sender;
            if(_canvas!=null&& gate[currentgate] != null)
            {
                Point dropPoint = e.GetPosition(this.Workspace);
                dropPoint.X = (Convert.ToInt32(dropPoint.X) / 25) * 25.0;
                dropPoint.Y = (Convert.ToInt32(dropPoint.Y) / 25) * 25.0;

                if (e.Effects.HasFlag(DragDropEffects.Copy))
                {
                    Workspace.Children.Add(gate[currentgate]);
                    Canvas.SetLeft(gate[currentgate], dropPoint.X - 50);
                    Canvas.SetTop(gate[currentgate], dropPoint.Y - 50);
                    // set the value to return to the DoDragDrop call
                    e.Effects = DragDropEffects.Copy;
                }
                else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                {
                    Canvas.SetLeft(gate[currentgate], dropPoint.X - 50);
                    Canvas.SetTop(gate[currentgate], dropPoint.Y - 50);
                    // set the value to return to the DoDragDrop call
                    e.Effects = DragDropEffects.Move;
                }
                
            }

            //Canvas _canvas = (Canvas)sender;
            //UIElement _element = (UIElement)e.Data.GetData("Object");
            //if (_canvas != null && _element != null)
            //{
            //    Canvas _parent = (Canvas)VisualTreeHelper.GetParent(_element);
            //    if (_parent != null)
            //    {
            //        Point dropPoint = e.GetPosition(this.Workspace);
            //        dropPoint.X = (Convert.ToInt32(dropPoint.X) / 25) * 25.0;
            //        dropPoint.Y = (Convert.ToInt32(dropPoint.Y) / 25) * 25.0;
            //        if (e.KeyStates == DragDropKeyStates.ControlKey &&
            //            e.AllowedEffects.HasFlag(DragDropEffects.Copy))
            //        {
            //            AND _and = new AND((AND)_element);
            //            _canvas.Children.Add(_and);
            //            Canvas.SetLeft(_and, dropPoint.X - 50);
            //            Canvas.SetTop(_and, dropPoint.Y - 50);
            //            // set the value to return to the DoDragDrop call
            //            e.Effects = DragDropEffects.Copy;
            //        }
            //        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
            //        {
            //            _parent.Children.Remove(_element);
            //            _canvas.Children.Add(_element);
            //            Canvas.SetLeft(_element, dropPoint.X - 50);
            //            Canvas.SetTop(_element, dropPoint.Y - 50);
            //            // set the value to return to the DoDragDrop call
            //            e.Effects = DragDropEffects.Move;
            //        }
            //    }
            //}
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
                    Filter = "Text Files(*.xaml)|*.xaml|All(*.*)|*"
                };
                if (dialog.ShowDialog() == true)
                {
                    FileStream fs = File.Open(dialog.FileName, FileMode.Create);
                    XamlWriter.Save(Workspace, fs);
                    fs.Close();
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
                    gate=new List<UserControl>();
                    int gateindex = 0;
                    string Loadfiletext = File.ReadAllText(openFileDialog.FileName) as string;
                    string[] loadsplit=Loadfiletext.Split(' ');
                    string[] merker;
                    double canvas_Left = 0, canvas_Top = 0;
                    for (int i = 9; i < loadsplit.Length;i++)
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
                                    gate.Add(_and);
                                    Workspace.Children.Add(gate[gateindex]);
                                    Canvas.SetLeft(gate[gateindex],  canvas_Left);
                                    Canvas.SetTop(gate[gateindex], canvas_Top);
                                    gateindex++;
                                break;
                            default:
                                break;
                        }
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