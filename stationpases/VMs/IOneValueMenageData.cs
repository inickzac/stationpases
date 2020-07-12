using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    interface IOneValueMenageData
    {         
    string Value { get; set; }
    string ValueName { get; }
    void Save(string Value);
    
    }
}
