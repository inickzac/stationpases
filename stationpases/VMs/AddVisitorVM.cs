using stationpases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace stationpases.VMs
{
    class AddVisitorVM
    {
        StationDBContext StationDBContext = new StationDBContext();
        DocumentType DocumentType = new DocumentType { Type = "bilet" };

        public AddVisitorVM()
        {
            StationDBContext.DocumentTypes.Add(DocumentType);
            StationDBContext.SaveChanges();

            var Visitor = StationDBContext.Visitors.FirstOrDefault();
            string vd = Visitor.Document.DocumentType.Type;
            Visitor.Document.DocumentType = new DocumentType {Type="2" };
            var v2 = Visitor.Document.DocumentType.Type;








            StationDBContext.Dispose();


            

        }
    }
}
