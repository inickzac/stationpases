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
        StationDBContext db = (Application.Current as App).db;
        public static ObservableCollection<DocumentType> documentTypes;

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
        public virtual DocumentType DocumentType { get => documentType; set { documentType = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string IssuingAuthority { get => issuingAuthority; set { issuingAuthority = value; OnPropertyChanged(); } }

        public virtual Visitor Visitor { get; set; }
        [NotMapped]
        public ObservableCollection<DocumentType> DocumentTypes
        {
            get => documentTypes; set { documentTypes = value; OnPropertyChanged(); }
        }
        private RelayCommand getDocumentTypeSettings;
        public RelayCommand GetDoocumentTypeSettings
        {
            get
            {
                return getDocumentTypeSettings ??
                  (getDocumentTypeSettings = new RelayCommand(async obj =>
                  {
                      if (obj != null) await displayRootRegistry.ShowModalPresentation((obj as Document).DocumentType);
                      else await displayRootRegistry.ShowModalPresentation(new DocumentType());
                  }));
            }
        }


    }
}
