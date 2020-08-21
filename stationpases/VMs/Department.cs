using stationpases.VMs;
using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace stationpases.Model
{
    public class Department : VMContext, INotifyPropertyChanged, IOneValue, IReadyForDBMenage
    {
        int id;
        string value;
        string tempValue;

        public Department()
        {
            DbTableMenage = new  OneValueDBMenage<Department>(this);
            Employees = new ObservableCollection<Employee>();
        }
        [Required]
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [MaxLength(50), Required]
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }
        public virtual ICollection<Employee> Employees { get; set; }
        public IOneValueBDMenage DbTableMenage { get; set; }
        public string ValueName => "Подразделение";
        public string ValueTemp { get => tempValue; set { tempValue = value; OnPropertyChanged(); } }

        public void InitTempData()
        {
            ValueTemp = Value;
        }

        public bool IsUsedInOtherTables() => Employees.Any();
      
        public void SaveTempData()
        {
            Value = ValueTemp;
        }
    }
}
