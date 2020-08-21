using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.Model
{
    class MainBDContext
    {
        static private StationDBContext stationDBContext;
        private MainBDContext()
        {
        }

        public static StationDBContext GetRef
        {
            get
            {
                if (stationDBContext == null) stationDBContext = new StationDBContext();
                stationDBContext.DocumentTypes.Load();
                stationDBContext.IssuingAuthorities.Load();
                stationDBContext.Departments.Load();
                return stationDBContext;
            }
        }


    }
}
