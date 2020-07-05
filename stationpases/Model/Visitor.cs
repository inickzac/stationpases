using stationpases.VMs;
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
    public class Visitor : VMContext, INotifyPropertyChanged, IDataMenage
    {
        int id;
        string name;
        string lastName;
        string position;
        int documentId;
        string placeOfWork;
        Document document;
        SinglePass singlePass;
        string patronymic;

        public Visitor()
        {
            SinglePasses = new List<SinglePass>();
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
        public string Patronymic { get => patronymic; set { patronymic = value; OnPropertyChanged(); } }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            (Application.Current as App).db.SaveChanges();
        }
     
    }
}
