using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public int? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? ConstructStartDate { get; set; }
        public DateTime? ConstructEndDate { get; set; }

        public ICollection<Device> Devices { get; set; }

        [ForeignKey(nameof(OrderDetailId))]
        public Guid? OrderDetailId { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }

        [ForeignKey(nameof(PaymentId))]
        public Guid? PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(StaffId))]
        public Guid? StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
