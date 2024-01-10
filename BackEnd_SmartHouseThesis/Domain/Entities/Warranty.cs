using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Warranty :BaseEntity
    {
        public decimal? WarrantyDamage { get; set; }
        public string? Description { get; set; }
        //
        public ICollection<Device> Devices { get; set; }
        //
        [ForeignKey(nameof(ConstractId))]
        public Guid? ConstractId { get; set; }
        public virtual Constract Constract { get; set; }
    }
}
