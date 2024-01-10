using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServicePack :BaseEntity
    {
        public string? PackageName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        //
        [ForeignKey(nameof(PromotionId))]
        public Guid? PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
        //
        public ICollection<Device> Devices { get; set; }
        //
        [ForeignKey(nameof(ConstractId))]
        public Guid? ConstractId { get; set; }
        public virtual Constract Constract { get; set; }
    }
}
