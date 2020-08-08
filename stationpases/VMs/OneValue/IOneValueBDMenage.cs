using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs.interfeses
{
  public interface IOneValueBDMenage : IDbTableMenage
    {
        void ShowExtendedView(Action<object> callBack);

    }
}
