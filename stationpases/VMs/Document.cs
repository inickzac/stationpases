using stationpases.VMs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace stationpases.Model
{
    public class Document : VMContext, INotifyPropertyChanged
    {
        int id;
        string series;
        string number;
        DateTime dateOfIssue;
        DocumentType documentType;
        string issuingAuthority;
        StationDBContext db = MainBDContext.GetRef;
        public StationDBContext Db { get { return db; } }

        [Key, ForeignKey("Visitor")]
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string Series { get => series; set { series = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string Number { get => number; set { number = value; OnPropertyChanged(); } }
        [Required]
        public DateTime DateOfIssue { get => dateOfIssue; set { dateOfIssue = value; OnPropertyChanged(); } }
        [Required]
        public virtual DocumentType DocumentType
        {
            get => documentType; set { documentType = value; OnPropertyChanged(); }
        }
        [Required]
        [MaxLength(50)]
        public string IssuingAuthority { get => issuingAuthority; set { issuingAuthority = value; OnPropertyChanged(); } }

        public virtual Visitor Visitor { get; set; }

        private void DocumentType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DocumentType));
        }

        private RelayCommand showDockTypeExtendedView;
        public RelayCommand ShowDockTypeViewExtendedView
        {
            get
            {
                return showDockTypeExtendedView ??
                  (showDockTypeExtendedView = new RelayCommand(obj =>
                  {
                      if (DocumentType == null) DocumentType = new DocumentType();
                      DocumentType.DbTableMenage.ShowExtendedView(
                          (objCB) => { this.DocumentType = (DocumentType)objCB; });
                  }));
            }
        }

    }
}
