using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Device :BaseEntity
    {
        public string? DeviceName { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int? WarrantyTime { get; set;}
        

        public ICollection<Image> Images { get; set; }
        public ICollection<Package> Packages { get; set; }
        public ICollection<WarrantyReport> WarrantyReports { get; set; }


        [ForeignKey(nameof(OwnerId))]
        public Guid? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

    }
}
