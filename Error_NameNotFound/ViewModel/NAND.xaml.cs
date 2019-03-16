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

namespace Error_NameNotFound.ViewModel
{
    /// <summary>
    /// Interaction logic for NAND.xaml
    /// </summary>
//<<<<<<< HEAD
//    public partial class NAND : Logicgatescontrol
//    {
//        //private L_Nand l_nand;
//        public NAND() : base()
//=======
    public partial class NAND : UserControl
    {
        public NAND()
        {
            InitializeComponent();
        }
        public NAND(NAND g)
        {
            InitializeComponent();
//<<<<<<< HEAD
//            Name = "NANDUI";
//            //l_nand = new L_Nand(2, id, this);
//            //LogicGates.gates_logic.Add(l_nand);
//            ChangeColorInOut();
//=======
//            this.NANDUI.Height = g.NANDUI.Height;
//            this.NANDUI.Width = g.NANDUI.Height;
//>>>>>>> parent of 21d4d52... implement other basic Gates
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Double", NANDUI.Height);
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Hand);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }
    }
}
