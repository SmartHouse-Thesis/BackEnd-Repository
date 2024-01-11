using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Acceptance : BaseEntity
    {
        public DateTime? StartWarranty { get; set; }
        public string? ImageFile { get; set; }
        //
        [ForeignKey(nameof(DeviceId))]
        public Guid? DeviceId { get; set; }
        public virtual Device Device { get; set; }
        //
        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set;}
        public virtual Customer Customer { get; set; }

    }
}
