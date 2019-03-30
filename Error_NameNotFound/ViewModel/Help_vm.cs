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
    class Help_vm : Basemodel
    {
        private static string help = "Zoom: \t\t\tLeftCtrl+Mousweel \nSaveFile: \t\t\tLeftCtrl+S \nOpenFile: \t\tLeftCtrl+O \nPrint: \t\t\tLeftCtrl+P \nAdd Copy of Gate: \tLeftCtrl+MouseDrag \nAdd CableBranch: \t\tLeftShift+MouseDrag \nDelete Gate: \t\tDel \nHelp: \t\t\t?";
        public Help_vm()
        { }
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand(c => Help());
                }
                return clickCommand;
            }
            set { clickCommand = value; }
        }

        public static string Help_message { get => help; set => help = value; }

        private void Help()
        {
            MessageBox.Show(help,"Help");
        }
    }
}
