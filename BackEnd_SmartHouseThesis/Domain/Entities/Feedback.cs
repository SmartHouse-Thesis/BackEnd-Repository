using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public string? Description { get; set; }
        public string? Content { get; set; }

        [ForeignKey(nameof(PackageId))]
        public Guid? PackageId { get; set; }
        public virtual Package Package { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
