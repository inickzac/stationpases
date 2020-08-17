using stationpases.Model;
using stationpases.Views;
using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static stationpases.VMs.VMContext;

namespace stationpases.VMs
{
    public class DbTableMenage<T> : IDbTableMenage where T : class, IReadyForDBMenage, new()
    {
        private T menageTable;
        protected DisplayRootRegistry displayRootRegistry = (Application.Current as App).displayRootRegistry;
        private RelayCommand editValue;
        private RelayCommand saveInBD;
        private RelayCommand deleteInDB;


        public DbTableMenage(T menageTable)
        {
            this.menageTable = menageTable;
        }

        public RelayCommand EditValue
        {
            get
            {
                return editValue ??
                  (editValue = new RelayCommand(obj =>
                  {
                      menageTable.InitTempData();
                      displayRootRegistry.ShowPresentation(menageTable);
                  }));
            }
        }
        public RelayCommand SaveInBD
        {
            get
            {
                return saveInBD ??
                  (saveInBD = new RelayCommand(obj =>
                  {
                      StationDBContext db = MainBDContext.GetRef;
                      menageTable.SaveTempData();
                      db.Set<T>().AddOrUpdate(menageTable);
                      db.SaveChanges();
                      HidePresentation(obj);
                  }, obj => menageTable != null));
            }
        }
        public RelayCommand DeleteInDB
        {
            get
            {
                return deleteInDB ??
                  (deleteInDB = new RelayCommand(obj =>
                  {
                      if (!menageTable.IsUsedInOtherTables())
                      {
                          StationDBContext db = MainBDContext.GetRef;
                          db.Set<T>().Remove(menageTable);
                          db.SaveChanges();
                          HidePresentation(obj);
                      }
                      else displayRootRegistry.ShowPresentation(new DialogVM("Значение используется"));
                  }/*, obj => menageTable != null*/));
            }
        }
        private RelayCommand addNewValue;
        public RelayCommand AddNewValue
        {
            get
            {
                return addNewValue ??
                  (addNewValue = new RelayCommand(obj =>
                  {
                      menageTable.InitTempData();
                      displayRootRegistry.ShowPresentation(new T());
                  }));
            }
        }


        private void HidePresentation(object presentationVM)
        {
            if (presentationVM == null) displayRootRegistry.HidePresentation(menageTable);
            else displayRootRegistry.HidePresentation(presentationVM);
        }

    }
}
