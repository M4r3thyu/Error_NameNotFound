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
                    MainWindow.Gates_UI = new List<Logicgatescontrol>();
                    LogicGates.gates_logic = new List<LogicGates>();
                    MainWindow.Cables = new List<Cable>();
                    LogicGates.connections = new List<int>();
                    MainWindow.Id = 0;
                    int gateindex = 0;
                    string Loadfiletext = File.ReadAllText(openFileDialog.FileName) as string;
                    string[] loadsplit = Loadfiletext.Split('$');
                    string[] bausteine = loadsplit[0].Split('|');
                    string[] cables = loadsplit[1].Split('|');
                    string[] connections = loadsplit[2].Split('|');
                    string[] merker;
                    double canvas_Left = 0, canvas_Top = 0;
                    for (int i = 2; i < bausteine.Length - 1; i++)
                    {
                        merker = bausteine[i].Split(' ');
                        MainWindow.Id = Convert.ToInt32(merker[2]);
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
                                    AND _and = new AND(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_and);
                                    break;
                                case "ButtonUI":
                                    LogicButton _logicbutton = new LogicButton(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_logicbutton);
                                    break;
                                case "CALLIPERUI":
                                    Calliper _calliper = new Calliper(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_calliper);
                                    break;
                                case "CounterUI":
                                    Counter _counter = new Counter(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_counter);
                                    break;
                                case "Counter_MSUI":
                                    Counter_ms _counter_ms = new Counter_ms(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_counter_ms);
                                    break;
                                case "FF_DC_CUI":
                                    FF_DC_c _ff_dc_c = new FF_DC_c(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c);
                                    break;
                                case "FF_DC_C_EUI":
                                    FF_DC_c_e _ff_dc_c_e = new FF_DC_c_e(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_e);
                                    break;
                                case "FF_DC_C_E_RUI":
                                    FF_DC_c_e_r _ff_dc_c_e_r = new FF_DC_c_e_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_e_r);
                                    break;
                                case "FF_DC_C_E_SUI":
                                    FF_DC_c_e_s _ff_dc_c_e_s = new FF_DC_c_e_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_e_s);
                                    break;
                                case "FF_DC_C_E_S_RUI":
                                    FF_DC_c_e_s_r _ff_dc_c_e_s_r = new FF_DC_c_e_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_e_s_r);
                                    break;
                                case "FF_DC_C_MSUI":
                                    FF_DC_c_ms _ff_dc_c_ms = new FF_DC_c_ms(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms);
                                    break;
                                case "FF_DC_C_MS_RUI":
                                    FF_DC_c_ms_r _ff_dc_c_ms_r = new FF_DC_c_ms_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms_r);
                                    break;
                                case "FF_DC_C_MS_EUI":
                                    FF_DC_c_ms_e _ff_dc_c_ms_e = new FF_DC_c_ms_e(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms_e);
                                    break;
                                case "FF_DC_C_MS_E_RUI":
                                    FF_DC_c_ms_e_r _ff_dc_c_ms_e_r = new FF_DC_c_ms_e_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms_e_r);
                                    break;
                                case "FF_DC_C_MS_E_SUI":
                                    FF_DC_c_ms_e_s _ff_dc_c_ms_e_s = new FF_DC_c_ms_e_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms_e_s);
                                    break;
                                case "FF_DC_C_MS_E_S_RUI":
                                    FF_DC_c_ms_e_s_r _ff_dc_c_ms_e_s_r = new FF_DC_c_ms_e_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms_e_s_r);
                                    break;
                                case "FF_DC_C_MS_SUI":
                                    FF_DC_c_ms_s _ff_dc_c_ms_s = new FF_DC_c_ms_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms_s);
                                    break;
                                case "FF_DC_C_MS_S_RUI":
                                    FF_DC_c_ms_s_r _ff_dc_c_ms_s_r = new FF_DC_c_ms_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_ms_s_r);
                                    break;
                                case "FF_DC_C_RUI":
                                    FF_DC_c_r _ff_dc_c_r = new FF_DC_c_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_r);
                                    break;
                                case "FF_DC_C_SUI":
                                    FF_DC_c_s _ff_dc_c_s = new FF_DC_c_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_s);
                                    break;
                                case "FF_DC_C_S_RUI":
                                    FF_DC_c_s_r _ff_dc_c_s_r = new FF_DC_c_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_dc_c_s_r);
                                    break;
                                case "FF_JK_CUI":
                                    FF_JK_c _ff_jk_c = new FF_JK_c(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c);
                                    break;
                                case "FF_JK_C_EUI":
                                    FF_JK_c_e _ff_jk_c_e = new FF_JK_c_e(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_e);
                                    break;
                                case "FF_JK_C_E_RUI":
                                    FF_JK_c_e_r _ff_jk_c_e_r = new FF_JK_c_e_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_e_r);
                                    break;
                                case "FF_JK_C_E_SUI":
                                    FF_JK_c_e_s _ff_jk_c_e_s = new FF_JK_c_e_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_e_s);
                                    break;
                                case "FF_JK_C_E_S_RUI":
                                    FF_JK_c_e_s_r _ff_jk_c_e_s_r = new FF_JK_c_e_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_e_s_r);
                                    break;
                                case "FF_JK_C_MS_EUI":
                                    FF_JK_c_ms_e _ff_jk_c_ms_e = new FF_JK_c_ms_e(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_ms_e);
                                    break;
                                case "FF_JK_C_MS_E_RUI":
                                    FF_JK_c_ms_e_r _ff_jk_c_ms_e_r = new FF_JK_c_ms_e_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_ms_e_r);
                                    break;
                                case "FF_JK_C_MS_E_SUI":
                                    FF_JK_c_ms_e_s _ff_jk_c_ms_e_s = new FF_JK_c_ms_e_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_ms_e_s);
                                    break;
                                case "FF_JK_C_MS_E_S_RUI":
                                    FF_JK_c_ms_e_s_r _ff_jk_c_ms_e_s_r = new FF_JK_c_ms_e_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_ms_e_s_r);
                                    break;
                                case "FF_JK_C_MS_RUI":
                                    FF_JK_c_ms_r _ff_jk_c_ms_r = new FF_JK_c_ms_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_ms_r);
                                    break;
                                case "FF_JK_C_MS_SUI":
                                    FF_JK_c_ms_s _ff_jk_c_ms_s = new FF_JK_c_ms_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_ms_s);
                                    break;
                                case "FF_JK_C_MS_S_RUI":
                                    FF_JK_c_ms_s_r _ff_jk_c_ms_s_r = new FF_JK_c_ms_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_ms_s_r);
                                    break;
                                case "FF_JK_C_RUI":
                                    FF_JK_c_r _ff_jk_c_r = new FF_JK_c_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_r);
                                    break;
                                case "FF_JK_C_SUI":
                                    FF_JK_c_s _ff_jk_c_s = new FF_JK_c_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_s);
                                    break;
                                case "FF_JK_C_S_RUI":
                                    FF_JK_c_s_r _ff_jk_c_s_r = new FF_JK_c_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_jk_c_s_r);
                                    break;
                                    case "FF_RS_CUI":
                                    FF_RS_c _ff_rs_c = new FF_RS_c(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c);
                                    break;
                                case "FF_RS_C_EUI":
                                    FF_RS_c_e _ff_rs_c_e = new FF_RS_c_e(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_e);
                                    break;
                                case "FF_RS_C_E_RUI":
                                    FF_RS_c_e_r _ff_rs_c_e_r = new FF_RS_c_e_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_e_r);
                                    break;
                                case "FF_RS_C_E_SUI":
                                    FF_RS_c_e_s _ff_rs_c_e_s = new FF_RS_c_e_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_e_s);
                                    break;
                                case "FF_RS_C_E_S_RUI":
                                    FF_RS_c_e_s_r _ff_rs_c_e_s_r = new FF_RS_c_e_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_e_s_r);
                                    break;
                                case "FF_RS_C_MS_EUI":
                                    FF_RS_c_ms_e _ff_rs_c_ms_e = new FF_RS_c_ms_e(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_ms_e);
                                    break;
                                case "FF_RS_C_MS_E_RUI":
                                    FF_RS_c_ms_e_r _ff_rs_c_ms_e_r = new FF_RS_c_ms_e_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_ms_e_r);
                                    break;
                                case "FF_RS_C_MS_E_SUI":
                                    FF_RS_c_ms_e_s _ff_rs_c_ms_e_s = new FF_RS_c_ms_e_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_ms_e_s);
                                    break;
                                case "FF_RS_C_MS_E_S_RUI":
                                    FF_RS_c_ms_e_s_r _ff_rs_c_ms_e_s_r = new FF_RS_c_ms_e_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_ms_e_s_r);
                                    break;
                                case "FF_RS_C_MS_RUI":
                                    FF_RS_c_ms_r _ff_rs_c_ms_r = new FF_RS_c_ms_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_ms_r);
                                    break;
                                case "FF_RS_C_MS_SUI":
                                    FF_RS_c_ms_s _ff_rs_c_ms_s = new FF_RS_c_ms_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_ms_s);
                                    break;
                                case "FF_RS_C_MS_S_RUI":
                                    FF_RS_c_ms_s_r _ff_rs_c_ms_s_r = new FF_RS_c_ms_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_ms_s_r);
                                    break;
                                case "FF_RS_C_RUI":
                                    FF_RS_c_r _ff_rs_c_r = new FF_RS_c_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_r);
                                    break;
                                case "FF_RS_C_SUI":
                                    FF_RS_c_s _ff_rs_c_s = new FF_RS_c_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_s);
                                    break;
                                case "FF_RS_C_S_RUI":
                                    FF_RS_c_s_r _ff_rs_c_s_r = new FF_RS_c_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_c_s_r);
                                    break;
                                case "FF_RS_RUI":
                                    FF_RS_r _ff_rs_r = new FF_RS_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_r);
                                    break;
                                case "FF_RS_SUI":
                                    FF_RS_s _ff_rs_s = new FF_RS_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_s);
                                    break;
                                case "FF_RS_S_RUI":
                                    FF_RS_s_r _ff_rs_s_r = new FF_RS_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_rs_s_r);
                                    break;
                                case "FF_T_C_MS_EUI":
                                    FF_T_c_ms_e _ff_t_c_ms_e = new FF_T_c_ms_e(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_t_c_ms_e);
                                    break;
                                case "FF_T_C_MS_E_RUI":
                                    FF_T_c_ms_e_r _ff_t_c_ms_e_r = new FF_T_c_ms_e_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_t_c_ms_e_r);
                                    break;
                                case "FF_T_C_MS_E_SUI":
                                    FF_T_c_ms_e_s _ff_t_c_ms_e_s = new FF_T_c_ms_e_s(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_t_c_ms_e_s);
                                    break;
                                case "FF_T_C_MS_E_S_RUI":
                                    FF_T_c_ms_e_s_r _ff_t_c_ms_e_s_r = new FF_T_c_ms_e_s_r(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_ff_t_c_ms_e_s_r);
                                    break;
                                case "FULLADDERUI":
                                    Fulladder _fulladder = new Fulladder(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_fulladder);
                                    break;
                                case "HALFADDERUI":
                                    Halfadder _halfadder = new Halfadder(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_halfadder);
                                    break;
                                case "Hex7UI":
                                    HEX7 _hex7 = new HEX7(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_hex7);
                                    break;
                                case "HighUI":
                                    High _high = new High(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_high);
                                    break;
                                case "LightUI":
                                    Light _light = new Light(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_light);
                                    break;
                                case "LowUI":
                                    Low _low = new Low(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_low);
                                    break;
                                case "NANDUI":
                                    NAND _nand = new NAND(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_nand);
                                    break;
                                case "NORUI":
                                    NOR _nor = new NOR(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_nor);
                                    break;
                                /*case "NOTUI":
                                    NOT _not = new NOT(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_not);
                                    break;*/
                                case "ORUI":
                                    OR _or = new OR(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_or);
                                    break;
                                case "OscillatorUI":
                                    Oscillator _oscillator = new Oscillator(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_oscillator);
                                    break;
                                /*case "REGISTERUI":
                                    Register _register = new Register(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_register);
                                    break;*/
                                case "Seg7UI":
                                    Seg7 _seg7 = new Seg7(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_seg7);
                                    break;
                                case "XNORUI":
                                    XNOR _xnor = new XNOR(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_xnor);
                                    break;
                                case "XORUI":
                                    XOR _xor = new XOR(MainWindow.Id);
                                    MainWindow.Gates_UI.Add(_xor);
                                    break;
                                default:
                                    break;
                            }
                            
                            MainWindow.GetCanvas.Children.Add(MainWindow.Gates_UI[gateindex]);
                            Canvas.SetLeft(MainWindow.Gates_UI[gateindex], canvas_Left);
                            Canvas.SetTop(MainWindow.Gates_UI[gateindex], canvas_Top);
                            gateindex++;
                        }
                    }
                    for (int i = 2; i < cables.Length-1; i++)
                    {
                        string[] split = cables[i].Split(' ');
                        Cable _cable = new Cable(int.Parse(split[2]), double.Parse(split[4]), double.Parse(split[6]), double.Parse(split[8]), double.Parse(split[10]), bool.Parse(split[12]));
                        MainWindow.Cables.Add(_cable);
                        MainWindow.GetCanvas.Children.Add(_cable);
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
                        //                   //output Id                                inportId                    inportnr                ouportnr     
                        // LogicGates.Gates_logic[Convert.ToInt32(call[1])].Connection(Convert.ToInt32(call[2]), Convert.ToInt32(call[3]), Convert.ToInt32(call[4]));
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
