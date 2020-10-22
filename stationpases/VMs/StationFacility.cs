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
    public class StationFacility : VMContext, INotifyPropertyChanged, IOneValue, IReadyForDBMenage
    {
        int id;
        string value;
        string tempValue;

        public StationFacility()
        {
            Accesses = new List<Access>();
            DbTableMenage = new OneValueDBMenage<StationFacility>(this);
            Value = string.Empty;
        }
        public string ValueName { get => "Объект станции"; }
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [MaxLength(100), Required]
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempValue { get => tempValue; set { tempValue = value; OnPropertyChanged(nameof(Value)); } }
        public virtual IList<Access> Accesses { get; set; }
        [NotMapped]
        public IOneValueBDMenage DbTableMenage { get; set; }
        public bool IsUsedInOtherTables() => Accesses.Any();
        public void SaveTempData()
        {
            Value = TempValue;
        }
        public void InitTempData()
        {
            TempValue = Value;
        }

        public void DeleteRelatedData()
        {
            
        }
    }
}
