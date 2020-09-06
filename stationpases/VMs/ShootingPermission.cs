using stationpases.Model;
using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.VMs
{
   public class ShootingPermission : VMContext, INotifyPropertyChanged, IReadyForDBMenage
    {
        int id;
        DateTime? dateOfIssue;
        DateTime? validUntil;
        string cameraType;
        Employee shootingAllowed;
        string shootingPurpose;

        DateTime? tempDateOfIssue;
        DateTime? tempValidUntil;
        string tempCameraType;
        Employee tempShootingAllowed;
        string tempShootingPurpose;
        IDbTableMenage dbTableMenage;
        Access access;

        public ShootingPermission()
        {
            DbTableMenage = new DbTableMenage<ShootingPermission>(this);
            Accesses = new ObservableCollection<Access>();
        }

        StationDBContext db = MainBDContext.GetRef;
        public StationDBContext Db { get { return db; } }
        public IDbTableMenage DbTableMenage { get => dbTableMenage; set => dbTableMenage = value; }
        public virtual Visitor Visitor { get; set; }
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required, Column(TypeName = "datetime2")]
        public DateTime? DateOfIssue { get => dateOfIssue; set { dateOfIssue = value; OnPropertyChanged();} }
        [Required, Column(TypeName = "datetime2")]
        public DateTime? ValidUntil { get => validUntil; set { validUntil = value; OnPropertyChanged(); } }
        [Required, MaxLength(100)]
        public string CameraType { get => cameraType; set { cameraType = value; OnPropertyChanged(); } }
        [Required]
        [InverseProperty("ShootingAllowed")]
        public virtual Employee ShootingAllowed { get => shootingAllowed; set { shootingAllowed = value; OnPropertyChanged(); } }
        [Required, MaxLength(500)]
        public string ShootingPurpose { get => shootingPurpose; set { shootingPurpose = value; OnPropertyChanged(); } }

        [NotMapped]
        public DateTime? TempDateOfIssue { get => tempDateOfIssue; set { tempDateOfIssue = value; OnPropertyChanged(); } }
        [NotMapped]
        public DateTime? TempValidUntil { get => tempValidUntil; set { tempValidUntil = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempCameraType { get => tempCameraType; set { tempCameraType = value; OnPropertyChanged(); } }
        [NotMapped]
        public Employee TempShootingAllowed { get => tempShootingAllowed; set { tempShootingAllowed = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempShootingPurpose { get => tempShootingPurpose; set { tempShootingPurpose = value; OnPropertyChanged(); } }
        public virtual IList<Access> Accesses { get; set; }
        [NotMapped]
        public Access Access { get => access; set { access = value; OnPropertyChanged(); } }

        public void InitTempData()
        {
            TempCameraType = CameraType;
            TempDateOfIssue = DateOfIssue;
            TempShootingAllowed = ShootingAllowed;
            TempValidUntil = ValidUntil;
            tempShootingPurpose = shootingPurpose;
            Accesses.ToList().ForEach(a => a.InitTempData());
        }

        public bool IsUsedInOtherTables() => false;
       

        public void SaveTempData()
        {
            CameraType = TempCameraType;
            DateOfIssue = TempDateOfIssue;
            ShootingAllowed = TempShootingAllowed;
            ValidUntil = tempValidUntil;
            ShootingPurpose = TempShootingPurpose;
            Accesses.ToList().ForEach(a => a.SaveTempData());
        }

        public void DeleteRelatedData()
        {
            Accesses.ToList().ForEach(a => a.DbTableMenage.DeleteInDB.Execute(this));
        }

        private RelayCommand showShootingAllowedExtendedView;
        public RelayCommand ShowShootingAllowedExtendedView
        {
            get
            {
                return showShootingAllowedExtendedView ??
                  (showShootingAllowedExtendedView = new RelayCommand(obj =>
                  {
                      if (ShootingAllowed == null) ShootingAllowed = new Employee();
                      ShootingAllowed.DbTableMenage.ShowExtendedView(
                          (objCB) => { this.ShootingAllowed = (Employee)objCB; });
                  }));
            }
        }
        private RelayCommand addNewAccess;
        public RelayCommand AddNewAccess
        {
            get
            {
                return addNewAccess ??
                  (addNewAccess = new RelayCommand(obj =>
                  {
                      var Access = new Access { ShootingPermission = this };
                      Access.DbTableMenage.EditValue.Execute(this);
                  }));
            }
        }

     
    }
}
