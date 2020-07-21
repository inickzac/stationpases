using stationpases.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    class OneValueExtendedVM<T> : VMContext where T: class, IOneValue 
    {
        private T selectingValue;
                   
        public OneValueExtendedVM(T selectingValue)
        {
            this.selectingValue = selectingValue;
        }

        public string Value { get => selectingValue.Value; set => selectingValue.Value = value; }
       public ObservableCollection<T> ValueList { get => MainBDContext.GetRef.Set<T>().Local; }
    }
}
