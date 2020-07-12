using stationpases.VMs;
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
    public class SinglePass : VMContext, INotifyPropertyChanged
    {
        int id;
        DateTime dateOfIssue;
        DateTime validUntil;
        string purposeOfIssuance;
        Employee singlePassIssued;
        Employee accompanying;
        Visitor visitor;


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


    }
}
