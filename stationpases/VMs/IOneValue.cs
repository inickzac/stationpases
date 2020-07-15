using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    interface IOneValue
    {
         string ValueName { get; }
         string Value { get; set; }


    }
}
