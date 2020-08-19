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
    public class SinglePass : VMContext, INotifyPropertyChanged, IReadyForDBMenage
    {
        int id;
        DateTime dateOfIssue;
        DateTime validUntil;
        string purposeOfIssuance;
        Employee singlePassIssued;
        Employee accompanying;
        Visitor visitor;
        
        IDbTableMenage dbTableMenage;

        DateTime tempDateOfIssue;
        DateTime tempValidUntil;
        string tempPurposeOfIssuance;
        Employee tempSinglePassIssued;
        Employee tempAccompanying;

        public SinglePass()
        {
            DbTableMenage = new DbTableMenage<SinglePass>(this);
        }

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        public DateTime DateOfIssue { get => dateOfIssue; set { dateOfIssue = value; OnPropertyChanged(); } }
        [Required]
        public DateTime ValidUntil { get => validUntil; set { validUntil = value; OnPropertyChanged(); } }
        [Required, MaxLength(500)]
        public string PurposeOfIssuance { get => purposeOfIssuance; set { purposeOfIssuance = value; OnPropertyChanged(); } }
        [InverseProperty("SinglePassIssued")]
        public virtual Employee SinglePassIssued { get => singlePassIssued; set { singlePassIssued = value; OnPropertyChanged(); } }
        [InverseProperty("Accompanying")]
        public virtual Employee Accompanying { get => accompanying; set { accompanying = value; OnPropertyChanged(); } }
        public virtual Visitor Visitor { get => visitor; set { visitor = value; OnPropertyChanged(); } }
        public IDbTableMenage DbTableMenage { get => dbTableMenage; set { dbTableMenage = value; OnPropertyChanged(); } }

        [NotMapped]
        public DateTime TempDateOfIssue { get => tempDateOfIssue; set { tempDateOfIssue = value; OnPropertyChanged(); } }
        [NotMapped]
        public DateTime TempValidUntil { get => tempValidUntil; set { tempValidUntil = value; OnPropertyChanged(); } }
        [NotMapped]
        public string TempPurposeOfIssuance { get => tempPurposeOfIssuance; set { tempPurposeOfIssuance = value; OnPropertyChanged(); } }
        [NotMapped]
        public Employee TempSinglePassIssued { get => tempSinglePassIssued; set { tempSinglePassIssued = value; OnPropertyChanged(); } }
        [NotMapped]
        public Employee TempAccompanying { get => tempAccompanying; set { tempAccompanying = value; OnPropertyChanged(); } }

        public void InitTempData()
        {
            TempDateOfIssue = DateOfIssue;
            TempValidUntil = ValidUntil;
            TempSinglePassIssued = SinglePassIssued;
            TempAccompanying = Accompanying;
            TempSinglePassIssued = SinglePassIssued;
        }

        public bool IsUsedInOtherTables() => false;
       

        public void SaveTempData()
        {
            DateOfIssue = TempDateOfIssue;
            ValidUntil = TempValidUntil;
            SinglePassIssued = TempSinglePassIssued;
            Accompanying = TempAccompanying;
            SinglePassIssued = TempSinglePassIssued;
        }
    }
}
