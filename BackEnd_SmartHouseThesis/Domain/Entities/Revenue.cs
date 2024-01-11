using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Revenue : BaseEntity
    {
        public decimal? Total { get; set; }
        public int? TotalConstract {  get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Guid? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public ICollection<Constract> Constracts { get; set; }
    }
}
