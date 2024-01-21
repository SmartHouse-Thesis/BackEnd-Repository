using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment :BaseEntity
    {
        public string? PaymentName { get; set; }
        public string? PaymentType {  get; set; }
        public decimal? Amount { get; set; }
        public bool? isDeposit { get; set; }

        public DateTime? PaymentDate { get; set; } // ngày thanh toán 
        public string? Description { get; set; } // mô tả thanh toán 

        public ICollection<Order> Orders { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Guid? ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
