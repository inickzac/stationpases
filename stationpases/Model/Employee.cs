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
    public class Employee : VMContext, INotifyPropertyChanged
    {
        int id;
        string name;
        string lastName;
        string position;
        Department department;

        public Employee()
        {
            SinglePassIssued = new List<SinglePass>();
            Accompanying = new List<SinglePass>();
        }

        [Required]
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
        public Department Department { get => department; set { department = value; OnPropertyChanged(); } }
        public virtual ICollection<SinglePass> SinglePassIssued { get; set; }
        public virtual ICollection<SinglePass> Accompanying { get; set; }
    }
    }
