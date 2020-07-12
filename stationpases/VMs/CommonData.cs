using stationpases.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace stationpases.VMs
{
    class CommonData
    {

      static  CommonData commonData;
        StationDBContext db = (Application.Current as App).db;
      public ObservableCollection<DocumentType> DocumentTypes
        {
            get => new ObservableCollection<DocumentType>(db.DocumentTypes); set { }
        }

        public static CommonData GetData()
        {
            if (commonData == null) commonData = new CommonData();
            return commonData;
        }



    }
}
