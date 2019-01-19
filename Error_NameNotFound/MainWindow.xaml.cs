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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AND_Button_CLicked(object sender, RoutedEventArgs e)
        {
            AND _AND = new AND();
            Workspace.Children.Add(_AND);
            Canvas.SetLeft(_AND, 30);
            Canvas.SetTop(_AND, 30);
        }
        private void OR_Button_CLicked(object sender, RoutedEventArgs e)
        {

            OR _OR = new OR();
            Workspace.Children.Add(_OR);
            Canvas.SetLeft(_OR, 30);
            Canvas.SetTop(_OR, 30);
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
            UIElement _element = (UIElement)e.Data.GetData("Object");
            if (_canvas != null && _element != null)
            {
                Canvas _parent = (Canvas)VisualTreeHelper.GetParent(_element);
                if (_parent != null)
                {
                    Point dropPoint = e.GetPosition(this.Workspace);
                    dropPoint.X = (Convert.ToInt32(dropPoint.X) / 25) * 25.0;
                    dropPoint.Y = (Convert.ToInt32(dropPoint.Y) / 25) * 25.0;
                    if (e.KeyStates == DragDropKeyStates.ControlKey &&
                        e.AllowedEffects.HasFlag(DragDropEffects.Copy))
                    {
                        AND _and = new AND((AND)_element);
                        _canvas.Children.Add(_and);
                        Canvas.SetLeft(_and, dropPoint.X - 50);
                        Canvas.SetTop(_and, dropPoint.Y - 50);
                        // set the value to return to the DoDragDrop call
                        e.Effects = DragDropEffects.Copy;
                    }
                    else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                    {
                        _parent.Children.Remove(_element);
                        _canvas.Children.Add(_element);
                        Canvas.SetLeft(_element, dropPoint.X - 50);
                        Canvas.SetTop(_element, dropPoint.Y - 50);
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
            /*
            string test;
             
           StringBuilder outstr = new StringBuilder();
           XmlWriterSettings settings = new XmlWriterSettings();
           settings.Indent = true;
           settings.OmitXmlDeclaration = true;
           XamlDesignerSerializationManager dsm = new XamlDesignerSerializationManager(XmlWriter.Create(outstr, settings));
           dsm.XamlWriterMode = XamlWriterMode.Expression;
           XamlWriter.Save(Workspace, dsm);
           test = outstr.ToString();
           if (dialog.ShowDialog() == true)
           {
               File.WriteAllText(dialog.FileName, test);
           }*/
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fs = File.Open(openFileDialog.FileName, mode: FileMode.Open, access: FileAccess.Read);
                    Canvas savedCanvas = XamlReader.Load(fs) as Canvas;
            fs.Close();
            this.Workspace.Children.Add(savedCanvas);
            }
            /*
            using (FileStream stream = File.Open("d:\\test.xaml", FileMode.Open, FileAccess.Read))
            {
                // Load the saved panel
                InkCanvas savedCanvas = XamlReader.Load(stream) as InkCanvas;
                // Set the properties on the selected canvas
                Workspace.Background = savedCanvas.Background;
                // Set the strokes
                //Workspace.Children = savedCanvas.Children;
                // Get the child elements
                List<UIElement> elements = new List<UIElement>();
                foreach (UIElement element in savedCanvas.Children)
                    elements.Add(element);
                Workspace.Children.Clear();
                savedCanvas.Children.Clear();
                // Set the child elements
                for (int x = 0; x < elements.Count; x++)
                    Workspace.Children.Add(elements[x]);
            }*/
        }
    }
}