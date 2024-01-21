using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Policy : BaseEntity
    {
        public string? Type { get; set; }
        public string? Content { get; set; }

        [ForeignKey(nameof(PackageId))]
        public Guid? PackageId { get; set; }
        public virtual Package Package { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Guid? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
