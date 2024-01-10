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
        public DateTime? Period { get; set; }
        //
        public ICollection<ServicePack> ServicePack { get; set; }
        //
        public ICollection<Image> Image { get; set; }
        //
        [ForeignKey(nameof(WarrantyId))]
        public Guid? WarrantyId { get; set; }
        public virtual Warranty Warranty { get; set; }


    }
}
