using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Promotion :BaseEntity 
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<Package> Packages { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Guid? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
