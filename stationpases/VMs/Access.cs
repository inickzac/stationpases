using stationpases.Model;
using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    public class Access : VMContext, INotifyPropertyChanged, IReadyForDBMenage, IDataErrorInfo
    {
        int id;
        StationFacility stationFacility;
        bool accessIsAllowed;

        StationFacility testStationFacility;
        bool testAccessIsAllowed;
        StationDBContext db = MainBDContext.GetRef;
        public StationDBContext Db { get { return db; } }
        private string error;

        public Access()
        {
            DbTableMenage = new DbTableMenage<Access>(this);
            //StationFacility = new StationFacility();
        }

        public IDbTableMenage DbTableMenage { get; set; }
        public virtual ShootingPermission ShootingPermission { get; set; }
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        public bool AccessIsAllowed { get => accessIsAllowed; set { accessIsAllowed = value; OnPropertyChanged(); } }
        [NotMapped]
        public bool TempAccessIsAllowed { get => testAccessIsAllowed; set { testAccessIsAllowed = value; OnPropertyChanged(); } }
        [Required]
        public virtual StationFacility StationFacility { get => stationFacility; set { stationFacility = value; OnPropertyChanged(); } }
        [NotMapped]
        public StationFacility TempStationFacility { get => testStationFacility; set { testStationFacility = value; OnPropertyChanged(); } }

        public void InitTempData()
        {
            TempAccessIsAllowed = AccessIsAllowed;
            TempStationFacility = StationFacility;
            
        }

        public bool IsUsedInOtherTables() => false;


        public void SaveTempData()
        {
            AccessIsAllowed = TempAccessIsAllowed;
            StationFacility = TempStationFacility;
        }

        public void DeleteRelatedData()
        {
           
        }

        private RelayCommand showStationFacilityExtendedView;
        public RelayCommand ShowStationFacilityExtendedView
        {
            get
            {
                return showStationFacilityExtendedView ??
                  (showStationFacilityExtendedView = new RelayCommand(obj =>
                  {
                      if (StationFacility == null) StationFacility = new StationFacility();
                      StationFacility.DbTableMenage.ShowExtendedView(
                          (objCB) => { this.StationFacility = (StationFacility)objCB; });
                  }));
            }
        }

        public string Error { get => error; set => error = value; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "TempStationFacility":
                        if (TempStationFacility == null)
                        {
                            error = "Выберите объект";
                        }
                        break;
                }
                Error = error;
                return error;
            }
        }
    }
}
