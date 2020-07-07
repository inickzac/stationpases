using stationpases.VMs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stationpases.Model
{
    public class Department : VMContext, INotifyPropertyChanged
    {
        int id;
        string value;

        public Department()
        {
            Documents = new List<Employee>();
        }

        [Required]
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string Value { get => value; set { this.value = value; OnPropertyChanged(); } }
        public virtual ICollection<Employee> Documents { get; set; }
        public string ValueName { get => throw new NotImplementedException();  }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
