using stationpases.VMs;
using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.Model
{
    public class Employee : VMContext, INotifyPropertyChanged, IOneValue, IReadyForDBMenage
    {
        int id;
        string name;
        string lastName;
        string patronymic;
        string position;
        Department department;

        string tempName;
        string tempLastName;
        string tempPatronymic;
        string tempPosition;
        Department tempDepartment;
        StationDBContext db = MainBDContext.GetRef;
        public StationDBContext Db { get { return db; } }

        public Employee()
        {
            DbTableMenage = new OneValueDBMenage<Employee>(this);
            SinglePassIssued = new List<SinglePass>();
            Accompanying = new List<SinglePass>();
        }

        public IOneValueBDMenage DbTableMenage { get; set; }
        [Required]
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string Position { get => position; set { position = value; OnPropertyChanged(); } }       
        [Required]
        public Department Department { get => department; set { department = value; OnPropertyChanged(); } }
        public virtual ICollection<SinglePass> SinglePassIssued { get; set; }
        public virtual ICollection<SinglePass> Accompanying { get; set; }
        [Required, MaxLength(50)]
        public string Patronymic { get => patronymic; set { patronymic = value; OnPropertyChanged(); } }
        
        [NotMapped]       
        public string TempName { get => tempName; set { tempName = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempLastName { get => tempLastName; set { tempLastName = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempPatronymic { get => tempPatronymic; set { tempPatronymic = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempPosition { get => tempPosition; set { tempPosition = value; OnPropertyChanged(); } }
        [NotMapped]
        public Department TempDepartment { get => tempDepartment; set { tempDepartment = value; OnPropertyChanged(); } }

        public string ValueName => "Сотрудник";

        public string Value { get => ToString(); set { string t = Value; } }

        public void InitTempData()
        {
            TempName = Name;
            TempLastName = LastName;
            TempDepartment = Department;
            TempPatronymic = Patronymic;
            TempPosition = Position;
        }

        public bool IsUsedInOtherTables() => SinglePassIssued.Any() && Accompanying.Any();
       

        public void SaveTempData()
        {
            Name = TempName;
            LastName = TempLastName;
            Patronymic = TempPosition;
            Position = TempPosition;
            Department = TempDepartment;
        }

        public override string ToString() => Name + " " + LastName + " " + Patronymic;

        private RelayCommand showDepartmentExtendedView;
        public RelayCommand ShowDepartmentExtendedView
        {
            get
            {
                return showDepartmentExtendedView ??
                  (showDepartmentExtendedView = new RelayCommand(obj =>
                  {
                      if (Department == null) Department = new Department();
                      Department.DbTableMenage.ShowExtendedView(
                          (objCB) => { this.Department = (Department)objCB; });
                  }));
            }
        }


    }
}
