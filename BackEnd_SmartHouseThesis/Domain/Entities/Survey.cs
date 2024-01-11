using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Survey :BaseEntity
    {
        public string? Description { get; set; }
        public string? Note { get; set; }


        [ForeignKey(nameof(AccountId))]
        public Guid? AccountId { get; set; }
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Guid? RequestId { get; set; }
        public virtual Request Request { get; set; }


    }
}
