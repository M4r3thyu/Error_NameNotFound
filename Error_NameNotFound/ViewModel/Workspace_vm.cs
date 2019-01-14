using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Error_NameNotFound.Model;
using System.IO;

namespace Error_NameNotFound.ViewModel
{
    [Serializable]
    class Workspace_vm
    {
        List<LogicGates> save;
        public Workspace_vm()
        {
            save = new List<LogicGates>();
        }
        public void serializ()
        {
            string dir = @"C:\Users\Mar3t\Desktop\Projekt\save";
            string serializationFile = Path.Combine(dir, "save.bin");

            //serialize
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, save);
            }

            //deserialize
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                save = (List<LogicGates>)bformatter.Deserialize(stream);
            }
        }
    }
}