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
    public class IssuingAuthority : VMContext, INotifyPropertyChanged, IOneValue, IReadyForDBMenage
    {
        int id;
        string value;
        string tempValue;

        public IssuingAuthority()
        {
            Documents = new List<Document>();
            DbTableMenage = new OneValueDBMenage<IssuingAuthority>(this);
            Value = string.Empty;
        }
        public string ValueName { get => "Орган выдавший документ"; }
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [MaxLength(100), Required]
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }
        [NotMapped]
        public string ValueTemp { get => tempValue; set { tempValue = value; OnPropertyChanged(nameof(Value)); } }
        public virtual IList<Document> Documents { get; set; }
        [NotMapped]
        public IOneValueBDMenage DbTableMenage { get; set; }
        public bool IsUsedInOtherTables() => Documents.Any();
        public void SaveTempData()
        {
            Value = ValueTemp;
        }
        public void InitTempData()
        {
            ValueTemp = Value;
        }
    }
}
