using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Package :BaseEntity
    {
        public string? PackageName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        public ICollection<Device> Devices { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Guid? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey(nameof(PromotionId))]
        public Guid? PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Guid? ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        [ForeignKey(nameof(ImageId))]
        public Guid? ImageId { get; set; }
        public virtual Image Image { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Guid? ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey(nameof(PolicyId))]
        public Guid? PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
