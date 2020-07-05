﻿using stationpases.VMs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace stationpases.Model
{
    public class DocumentType : VMContext, INotifyPropertyChanged, IOneValueMenageData
    {
        int id;
        string value;
        StationDBContext db = new StationDBContext();

        public DocumentType()
        {
            Documents = new List<Document>();
        }

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(100)]
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }

        public virtual IList<Document> Documents {get; set;}

        public string ValueName => "Тип документа";

        public void Delete()
        {
            if(db.DocumentTypes.Contains(this)) db.DocumentTypes.Remove(this);
        }

        public void Save(string Value)
        {
            this.Value = Value;
            if (!db.DocumentTypes.Contains(this)) db.DocumentTypes.Add(this);
            db.SaveChanges();
            OnPropertyChanged("DocumentTypes");
        }
    }
}
