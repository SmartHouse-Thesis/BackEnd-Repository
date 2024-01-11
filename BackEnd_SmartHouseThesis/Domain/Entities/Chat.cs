using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chat : BaseEntity
    {
        public string? Logchat {  get; set; }

        [ForeignKey(nameof(TellerId))]
        public Guid? TellerId { get; set; }
        public virtual Teller Teller { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
