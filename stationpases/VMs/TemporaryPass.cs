using stationpases.Model;
using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
    public class TemporaryPass : VMContext, INotifyPropertyChanged, IReadyForDBMenage, IDataErrorInfo
    {
        int id;
        DateTime? validWith;
        DateTime? valitUntil;
        string purposeOfIssuance;
        Employee temporaryPassIssued;
        DateTime? tempValidWith;
        DateTime? tempValitUntil;
        string tempPurposeOfIssuance;
        Employee tempTemporaryPassIssued;
        IDbTableMenage dbTableMenage;
        StationDBContext db = MainBDContext.GetRef;
        
        public StationDBContext Db { get { return db; } }
        DataErrorInfoTools dataErrorInfoTools;
        public TemporaryPass()
        {
            DbTableMenage = new DbTableMenage<TemporaryPass>(this);
            dataErrorInfoTools = new DataErrorInfoTools(this, GetType());
        }

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        public DateTime? ValidWith { get => validWith; set { validWith = value; OnPropertyChanged(); } }
        [Required]
        public DateTime? ValitUntil { get => valitUntil; set { valitUntil = value; OnPropertyChanged(); } }
        [Required, MaxLength(500)]
        public string PurposeOfIssuance { get => purposeOfIssuance; set { purposeOfIssuance = value; OnPropertyChanged(); } }
        [InverseProperty("TemporaryPassIssued"), Required]
        public virtual Employee TemporaryPassIssued { get => temporaryPassIssued; set { temporaryPassIssued = value; OnPropertyChanged(); } }

        [NotMapped]
        public DateTime? TempValidWith { get => tempValidWith; set { tempValidWith = value; OnPropertyChanged(); } }
        [NotMapped]
        public DateTime? TempValitUntil { get => tempValitUntil; set { tempValitUntil = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempPurposeOfIssuance { get => tempPurposeOfIssuance; set { tempPurposeOfIssuance = value; OnPropertyChanged(); } }
        [NotMapped]
        public  Employee TempTemporaryPassIssued { get => tempTemporaryPassIssued; set { tempTemporaryPassIssued = value; OnPropertyChanged(); } }

        public virtual Visitor Visitor { get; set; }
        public IDbTableMenage DbTableMenage { get => dbTableMenage; set => dbTableMenage = value; }

        public void InitTempData()
        {
            TempPurposeOfIssuance = PurposeOfIssuance;
            TempTemporaryPassIssued = TemporaryPassIssued;
            TempValidWith = ValidWith;
            TempValitUntil = ValitUntil;
        }

        public bool IsUsedInOtherTables() => false;


        public void SaveTempData()
        {
            PurposeOfIssuance = TempPurposeOfIssuance;
            TemporaryPassIssued = TempTemporaryPassIssued;
            ValidWith = TempValidWith;
            ValitUntil = TempValitUntil;
        }

        public void DeleteRelatedData()
        {
            
        }

        private RelayCommand showTemporaryPassExtendedView;
        public RelayCommand ShowTemporaryPassExtendedView
        {
            get
            {
                return showTemporaryPassExtendedView ??
                  (showTemporaryPassExtendedView = new RelayCommand(obj =>
                  {
                      if (TemporaryPassIssued == null) TemporaryPassIssued = new Employee();
                      TemporaryPassIssued.DbTableMenage.ShowExtendedView(
                          (objCB) => { this.TemporaryPassIssued = (Employee)objCB; });
                  }));
            }
        }

        public string Error => ((IDataErrorInfo)dataErrorInfoTools).Error;

        public string this[string columnName] => ((IDataErrorInfo)dataErrorInfoTools)[columnName];
    }
}
