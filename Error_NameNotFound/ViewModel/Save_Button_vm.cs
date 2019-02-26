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
                    string bausteine = " |  index left top Name | ";
                    for (int i = 0; i < MainWindow.gates_UI.Count ; i++)//LogicGates.gates_logic.Count
                    {
                        var temp = MainWindow.gates_UI[i];

                        bausteine += " " + LogicGates.gates_logic[i].id + " ";
                        bausteine += Canvas.GetLeft(MainWindow.gates_UI[i]);
                        bausteine += " ";
                        bausteine += Canvas.GetTop(MainWindow.gates_UI[i]);
                        bausteine += " ";
                        bausteine += MainWindow.gates_UI[i].Name;
                        bausteine += " | ";
                    }
                    string connections = " ";
                    connections = LogicGates.Get_Connections;
                    string save = bausteine + " $ " + connections;
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