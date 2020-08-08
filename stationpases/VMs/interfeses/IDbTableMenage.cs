using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static stationpases.VMs.VMContext;

namespace stationpases.VMs.interfeses
{
   public interface IDbTableMenage
    {
        RelayCommand EditValue { get; }
        RelayCommand DeleteInDB { get; }
        RelayCommand SaveInBD { get; }
        RelayCommand AddNewValue { get; }


    }
}
