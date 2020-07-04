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
        string name;

        public Department()
        {
            Documents = new List<Employee>();
        }

        [Required]
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(50)]
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public virtual ICollection<Employee> Documents { get; set; }
    }
}
