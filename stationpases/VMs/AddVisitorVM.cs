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
        public StationDBContext db { get; set; } = (Application.Current as App).db;
        public Visitor Visitor { get; set; }

        public AddVisitorVM()
        {
            Visitor = db.Visitors.FirstOrDefault();
            Document.documentTypes = new ObservableCollection<DocumentType>(db.DocumentTypes);

        }
    }
}
