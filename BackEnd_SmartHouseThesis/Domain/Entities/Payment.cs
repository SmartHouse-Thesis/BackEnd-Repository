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

        //
        [ForeignKey(nameof(ConstractId))]
        public Guid? ConstractId { get; set; }
        public virtual Constract Constract { get; set; }
    }
}
