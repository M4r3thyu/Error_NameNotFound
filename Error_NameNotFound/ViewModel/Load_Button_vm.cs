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
using System.Windows.Threading;

namespace Error_NameNotFound.ViewModel
{
    class Load_Button_vm : Basemodel
    {
        public Load_Button_vm()
        {

        }
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand(c => Load());
                }
                return clickCommand;
            }
            set { clickCommand = value; }
        }
        private void Load()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    FileStream fs = File.Open(openFileDialog.FileName, mode: FileMode.Open, access: FileAccess.Read);
                    fs.Close();
                    MainWindow.GetCanvas.Children.Clear();
                    MainWindow.gates_UI = new List<UserControl>();
                    LogicGates.gates_logic = new List<LogicGates>();
                    LogicGates.connections = new List<int>();
                    MainWindow.id = 0;
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
                        MainWindow.id = Convert.ToInt32(merker[2]);
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
                                    AND _and = new AND(MainWindow.id);
                                    MainWindow.id++;
                                    MainWindow.gates_UI.Add(_and);

                                    break;
                                default:
                                    break;
                            }
                            MainWindow.GetCanvas.Children.Add(MainWindow.gates_UI[gateindex]);
                            Canvas.SetLeft(MainWindow.gates_UI[gateindex], canvas_Left);
                            Canvas.SetTop(MainWindow.gates_UI[gateindex], canvas_Top);
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
            catch (Exception x)
            {
                MessageBox.Show("Unhandled Error occoured \n" + x.Message);
            }
        }
    }
}
