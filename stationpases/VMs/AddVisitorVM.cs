using stationpases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Collections.ObjectModel;

namespace stationpases.VMs
{
    class AddVisitorVM
    {
        public Visitor Visitor { get; set; }

        public AddVisitorVM()
        {
            Visitor = MainBDContext.GetRef.Visitors.First();
        }
    }
}
