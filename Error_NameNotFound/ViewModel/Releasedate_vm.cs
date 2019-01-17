using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Error_NameNotFound.Model;

namespace Error_NameNotFound.ViewModel
{
    class Releasedate_vm:Basemodel
    {
        public Releasedate_vm()
        {
            content = "";
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; NotifyPropertyChanged(); }
        }
        private ICommand clickCommand;

        public ICommand ClickCommand
        {
            get { if (clickCommand == null)
                {
                    clickCommand = new RelayCommand(c => Release());
                } return clickCommand; }
            set { clickCommand = value; }
        }
        private void Release()
        {
            Content = Convert.ToInt32(Releasedate.Days_Releasedate())+"";
        }
    }
}
