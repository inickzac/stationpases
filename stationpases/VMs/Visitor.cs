﻿using stationpases.VMs;
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

namespace stationpases.Model
{
    public class Visitor : VMContext, INotifyPropertyChanged
    {
        int id;
        string name;
        string lastName;
        string position;
        string placeOfWork;
        Document document;
        string patronymic;
        SinglePass singlePass;
        TemporaryPass temporaryPass;

        public Visitor()
        {
            SinglePass = new SinglePass();
            SinglePasses = new ObservableCollection<SinglePass>();
            TemporaryPasses = new ObservableCollection<TemporaryPass>();
        }

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]      
        public string Position { get => position; set { position = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(100)]
        public string PlaceOfWork { get => placeOfWork; set { placeOfWork = value; OnPropertyChanged(); } }       
        [Required]
        public virtual Document Document { get => document; set { document = value; OnPropertyChanged(); } }
        public virtual ICollection<SinglePass> SinglePasses { get; set; }
        public virtual ICollection<TemporaryPass> TemporaryPasses { get; set; }
        public string Patronymic { get => patronymic; set { patronymic = value; OnPropertyChanged(); } }
        [NotMapped]
        public SinglePass SinglePass { get => singlePass; set { singlePass = value; OnPropertyChanged(); } }
        [NotMapped]
        public TemporaryPass TemporaryPass { get => temporaryPass; set { temporaryPass = value; OnPropertyChanged(); } }
    }
}
