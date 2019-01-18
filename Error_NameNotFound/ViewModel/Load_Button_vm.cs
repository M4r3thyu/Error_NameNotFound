using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Error_NameNotFound.Model;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;

namespace Error_NameNotFound.ViewModel
{
    class Load_Button_vm:Basemodel
    {
        private static string serializationFile;
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
                    clickCommand = new RelayCommand(c => Deserializ());
                }
                return clickCommand;
            }
            set { clickCommand = value; }
        }
        public void Deserializ()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                serializationFile = File.ReadAllText(openFileDialog.FileName);
            //deserialize
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Save_Button_vm.save= (List<LogicGates>)bformatter.Deserialize(stream);
            }
        }
    }
}
