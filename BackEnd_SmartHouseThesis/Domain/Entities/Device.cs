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
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? DeviceType { get; set; }


        public ICollection<Image> Images { get; set; }
        public ICollection<Package> Packages { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


        [ForeignKey(nameof(OwnerId))]
        public Guid? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Guid? ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Guid? OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
