using stationpases.VMs;
using System;
using System.Collections.Generic;
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
    public class DocumentType : VMContext, INotifyPropertyChanged, IOneValue
    {
        int id;
        string value;
        string tempValue;
           
        public DocumentType()
        {
            Documents = new List<Document>();
        }
        public string ValueName { get => "Тип документа"; }
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [MaxLength(100), Required]
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }
        [NotMapped]
        public string ValueTemp { get => tempValue; set => tempValue = value; }

        public virtual IList<Document> Documents {get; set;}
        private RelayCommand openModalWindow;
        private RelayCommand saveInBD;
        private RelayCommand deleteInDB;

        public RelayCommand OpenViewEditor
        {
            get
            {
                return openModalWindow ??
                  (openModalWindow = new RelayCommand( obj=> 
                  {
                      ValueTemp = Value;
                       displayRootRegistry.ShowModalPresentation(this);
                  }));
            }
        }
        public RelayCommand SaveInBD
        {
            get
            {
                return saveInBD ??
                  (saveInBD = new RelayCommand(obj =>
                  {
                      StationDBContext db = MainBDContext.GetRef;
                      Value = ValueTemp;
                      db.DocumentTypes.AddOrUpdate(this);
                      db.SaveChanges();
                  }));
            }
        }

        public RelayCommand DeleteInDB
        {
            get
            {
                return deleteInDB ??
                  (deleteInDB = new RelayCommand(obj =>
                  {
                      if (!Documents.Any()) 
                      {
                          StationDBContext db = MainBDContext.GetRef;
                          db.DocumentTypes.Remove(this);
                          db.SaveChanges();
                       
                      }
                  }));
            }
        }

    }
}
