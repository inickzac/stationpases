using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace stationpases.VMs
{
    class OneValueMenageDataVM: VMContext
    {
        IOneValueMenageData oneValueMenageData;
        string valueName;
        string value;     
        
        public string Value { get => value; set { this.value = Value; OnPropertyChanged(); } }
        public string ValueName { get => oneValueMenageData.ValueName;}
        public OneValueMenageDataVM(IOneValueMenageData oneValueMenageData)
        {
            this.oneValueMenageData = oneValueMenageData;
        }
        private RelayCommand saveInBD;     

    }
}
