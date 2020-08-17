using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    class DialogVM : VMContext
    {
        private string text;
        public DialogVM(string text)
        {
            this.Text = text;
        }
        public string Text { get => text; set { text = value; OnPropertyChanged(); } }

        private RelayCommand okCommand;
        public RelayCommand OkCommand
        {
            get
            {
                return okCommand ??
                  (okCommand = new RelayCommand(obj =>
                  {
                      displayRootRegistry.HidePresentation(this);
                  }));
            }
        }
    }
}
