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

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double zoomlvl = 1;
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
    }
}
