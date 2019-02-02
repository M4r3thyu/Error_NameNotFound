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
using System.Drawing;

namespace Error_NameNotFound
{
    /// <summary>
    /// Interaction logic for AND.xaml
    /// </summary>
    public partial class AND : UserControl
    {
        private static int anzahl = 0;
        //private string imagename;
        private int id;
        private And l_and;
        public AND()
        {

            InitializeComponent();
            id = 0;
            anzahl++;
            //      imagename = "ANDUI" + Convert.ToString(id);

        }
        public AND(int id) : this()
        {
            this.id = id;
            //     imagename = "ANDUI" + Convert.ToString(id);
            //        ANDUI.Name = imagename;
            l_and = new And(2, id, this);
            LogicGates.gates_logic.Add(l_and);
            ChangeColorInOut();
        }
        public AND(AND g) : this()
        {
            //  ANDUI.Name = "ANDUI";
            ANDUI.Height = g.ANDUI.Height;
            ANDUI.Width = g.ANDUI.Width;
            //  ANDUI.Name = imagename;
        }
        public int Id
        {
            get => id;
        }
        public double GetANDUI_Height()
        {
            double heightsave;
            //ANDUI.Name = "ANDUI";
            heightsave = ANDUI.Height;
            //  ANDUI.Name = imagename;
            return heightsave;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Setcurrentgate(id);
                MainWindow.SetGateFromButton(false);
                // Package the data.
                //  ANDUI.Name = "ANDUI";
                DataObject data = new DataObject();
                data.SetData("Double", ANDUI.Height);
                data.SetData("Object", this);
                //  ANDUI.Name = imagename;
                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (MainWindow.GateDelete)
            {
                MainWindow.RemoveGate(id);
            }
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy) | e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(new Cursor(Application.GetResourceStream(new Uri("Views/And.cur", UriKind.Relative)).Stream));
                //Mouse.SetCursor(Cursors.Cross);
            }
            //else if (e.Effects.HasFlag(DragDropEffects.Move))
            //{
            //    Mouse.SetCursor(Cursors.Hand);
            //}
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        private void Input0_Click(object sender, RoutedEventArgs e)
        {
            switch (LogicGates.inout)
            {
                case 0:
                    LogicGates.inid = id;
                    LogicGates.innr = 0;
                    if(!LogicGates.gates_logic.FirstOrDefault(c =>c.id==id).in0)
                    {
                        LogicGates.inout = 2;
                        input0.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    
                    break;
                case 1:                 //output id             inportid  inportnr  ouportnr     
                    if (!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).in0)
                    {
                        LogicGates.inid = id;
                        LogicGates.innr = 0;
                        var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid);
                        if (temp != null)
                        {
                            temp.Connection();
                        }
                    }
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    LogicGates.inout = 0;
                    break;
                default:
                    LogicGates.inout = 0;
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
                    break;
            }
        }

        private void Input1_Click(object sender, RoutedEventArgs e)
        {
            switch (LogicGates.inout)
            {
                case 0:
                        LogicGates.inid = id;
                        LogicGates.innr = 1;
                    if (!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).in1)
                    {
                        LogicGates.inout = 2;
                        input1.Background = System.Windows.Media.Brushes.Yellow;
                    }
                    break;
                case 1:
                    if (!LogicGates.gates_logic.FirstOrDefault(c => c.id == id).in1)
                    {
                        LogicGates.inid = id;
                        LogicGates.innr = 1;
                        var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid);
                        if (temp != null)
                        {
                            temp.Connection();
                        }
                    }
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    LogicGates.inout = 0;
                    break;
                default:
                    LogicGates.inout = 0;
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
                    break;
            }
        }

        private void Output0_Click(object sender, RoutedEventArgs e)
        {
            switch (LogicGates.inout)
            {
                case 0:
                    LogicGates.outid = id;
                    LogicGates.outnr = 0;
                    LogicGates.inout = 1;
                    output0.Background = System.Windows.Media.Brushes.Yellow;
                    break;
                case 2:
                    LogicGates.outid = id;
                    LogicGates.outnr = 0;
                    var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid);
                    if (temp != null)
                    {
                        bool ant = temp.Connection();
                        if (!ant)
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
                    }
                    LogicGates.inout = 0;
                    break;
                default:
                    LogicGates.inout = 0;
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    break;
            }
        }
        private void Output1_Click(object sender, RoutedEventArgs e)
        {
            switch (LogicGates.inout)
            {
                case 0:
                    LogicGates.outid = id;
                    LogicGates.outnr = 1;
                    LogicGates.inout = 1;
                    output1.Background = System.Windows.Media.Brushes.Yellow;
                    break;
                case 2:
                    LogicGates.outid = id;
                    LogicGates.outnr = 1;
                    var temp = LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid);
                    if (temp != null)
                    {
                        bool ant = temp.Connection();
                        if (!ant)
                            LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
                    }
                    LogicGates.inout = 0;
                    break;
                default:
                    LogicGates.inout = 0;
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.inid).ChangeColor();
                    LogicGates.gates_logic.FirstOrDefault(c => c.id == LogicGates.outid).ChangeColor();
                    break;
            }
        }

        private void DelConnection_Input0(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 0);
        }

        private void DelConnection_Input1(object sender, MouseButtonEventArgs e)
        {
            LogicGates.gates_logic.FirstOrDefault(c => c.id == id).DelConnections(id, 1);
        }

        public void ChangeColorInOut()
        {
            if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[0])
                input0.Background = System.Windows.Media.Brushes.Red;
            else
                input0.Background = System.Windows.Media.Brushes.MediumPurple;

            if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Input[1])
                input1.Background = System.Windows.Media.Brushes.Red;
            else
                input1.Background = System.Windows.Media.Brushes.MediumPurple;

            if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[0])
                output0.Background = System.Windows.Media.Brushes.Red;
            else
                output0.Background = System.Windows.Media.Brushes.MediumPurple;

            if (LogicGates.gates_logic.FirstOrDefault(c => c.id == id).Output[1])
                output1.Background = System.Windows.Media.Brushes.Red;
            else
                output1.Background = System.Windows.Media.Brushes.MediumPurple;
        }
    }
}