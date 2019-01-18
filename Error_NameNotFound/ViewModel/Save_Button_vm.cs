using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Error_NameNotFound.Model;
using System.IO;
using System.Windows.Input;

namespace Error_NameNotFound.ViewModel
{
    [Serializable]
    class Save_Button_vm:Basemodel
    {
        public static List<LogicGates> save;
        static string dir;
        static string serializationFile;
        public Save_Button_vm()
        {
            dir = @"C:\test";
            serializationFile = Path.Combine(dir, "save.bin");
            save = new List<LogicGates>();
        }
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand(c => Serializ());
                }
                return clickCommand;
            }
            set { clickCommand = value; }
        }
        public void Serializ()
        {
            //serialize
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, save);
            }
        }
        public void Deserializ()
        {
            //deserialize
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                save = (List<LogicGates>)bformatter.Deserialize(stream);
            }
        }
    }
}