using stationpases.VMs;
using stationpases.VMs.interfeses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace stationpases.Model
{
    public class DocumentType : VMContext, INotifyPropertyChanged, IOneValue, IReadyForDBMenage
    {
        int id;
        string value;
        string tempValue;
           
        public DocumentType()
        {
            Documents = new List<Document>();
            DbTableMenage = new OneValueDBMenage<DocumentType>(this);
            Value = string.Empty;
        }
        public string ValueName { get => "Тип документа"; }
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [MaxLength(100), Required]
        public string Value { get => value; set { this.value = value; OnPropertyChanged();  } }
        [NotMapped]
        public string ValueTemp { get => tempValue; set { tempValue = value; OnPropertyChanged(nameof(Value)); } }
        public virtual IList<Document> Documents {get; set;}
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

        public void DeleteRelatedData()
        {
            
        }
    }
}
