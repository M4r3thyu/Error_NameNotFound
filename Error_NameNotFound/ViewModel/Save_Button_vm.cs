using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Error_NameNotFound.Model;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows;

namespace Error_NameNotFound.ViewModel
{
    [Serializable]
    class Save_Button_vm : Basemodel
    {
        public Save_Button_vm()
        {
        }
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand(c => Save());
                }
                return clickCommand;
            }
            set { clickCommand = value; }
        }
        private void Save()
        {
            try
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
                    string bausteine = " | (Baussteine) index left top Name | ";
                    for (int i = 0; i < MainWindow.Gates_UI.Count ; i++)//LogicGates.gates_logic.Count
                    {
                        var temp = MainWindow.Gates_UI[i];

                        bausteine += " " + LogicGates.gates_logic[i].id + " ";
                        bausteine += Canvas.GetLeft(MainWindow.Gates_UI[i]);
                        bausteine += " ";
                        bausteine += Canvas.GetTop(MainWindow.Gates_UI[i]);
                        bausteine += " ";
                        bausteine += MainWindow.Gates_UI[i].Name;
                        bausteine += " | ";
                    }
                    string cables = " | (Kabel) index x1 x2 y1 y2 direction | ";
                    for (int i = 0; i < MainWindow.Cables.Count; i++)
                    {
                        cables += " " + MainWindow.Cables[i].Id + " ";
                        cables += " " + MainWindow.Cables[i].X1 + " ";
                        cables += " " + MainWindow.Cables[i].X2 + " ";
                        cables += " " + MainWindow.Cables[i].Y1 + " ";
                        cables += " " + MainWindow.Cables[i].Y2 + " ";
                        cables += " " + MainWindow.Cables[i].Direction + " ";
                        cables += " | "; 
                    }
                    string connections = " ";
                    connections = LogicGates.Get_Connections;
                    string save = bausteine + " $ " + cables + " $ " + connections;
                    File.AppendAllText(dialog.FileName, save);

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Unhandled Error occoured \n" + x.Message);
            }
        }
    }
}