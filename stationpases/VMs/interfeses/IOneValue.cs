using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    public interface IOneValue 
    {
        IOneValueBDMenage DbTableMenage { get; set; }
        string ValueName { get; }
        string Value { get; set; }
    }
}
