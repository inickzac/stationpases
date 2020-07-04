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
    public class DocumentType : VMContext, INotifyPropertyChanged
    {
        int id;
        string type;

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }
        [Required]
        [MaxLength(100)]
        public string Type { get => type; set { type = value; OnPropertyChanged(); } }

    }
}
