using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static stationpases.VMs.VMContext;

namespace stationpases.VMs
{
    public class OneValueDBMenage<T> : DbTableMenage<T>, IOneValueBDMenage  where T : class,
        IReadyForDBMenage,
        IOneValue,
        INotifyPropertyChanged, new()
    {
        T menageTable;
       public OneValueExtendedVM<T> ExtendVM { get; set; }
        public OneValueDBMenage(T menageTable) : base(menageTable)
        {
            this.menageTable = menageTable;
        }
       

        public void ShowExtendedView(Action<object> callBack) 
        {
            ExtendVM = new OneValueExtendedVM<T>(menageTable, callBack);
            displayRootRegistry.ShowPresentation(ExtendVM);
        }
    }


}
