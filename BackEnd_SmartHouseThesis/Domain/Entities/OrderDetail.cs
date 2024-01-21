using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public Guid? DeviceId { get; set; }
        public virtual Device Device { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Guid? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
