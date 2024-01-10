using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Constract :BaseEntity
    {
        public string? Title { get; set; } 
        public string? Description { get; set; }
        public decimal? TotalCost { get; set; }
        public int? Status { get; set; }
        //
        [ForeignKey(nameof(PackageId))]
        public Guid? PackageId { get; set; }
        public virtual ServicePack ServicePack { get; set; }
        //
        [ForeignKey(nameof(AccountId))]
        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }
        //
        public ICollection<Payment> Payment { get; set; }
        //
        public ICollection<Image> Images { get; set; }
    }
}
