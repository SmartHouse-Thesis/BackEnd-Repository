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
        public string? ImageFile { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<Package> Packages { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(TellerId))]
        public Guid? TellerId { get; set; }
        public virtual Teller Teller { get; set; }

        [ForeignKey(nameof(RenevueId))]
        public Guid? RenevueId { get; set; }
        public virtual Revenue Revenue { get; set; }


    }
}
