using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : BaseEntity 
    {
        /* [ForeignKey(nameof(AccountId))]
         public Guid? AccountId { get; set; } */
        public virtual Account Account { get; set; }

        public string? RoleName { get; set; } 

        public ICollection<Chat> Chats { get; set; }
        
        public ICollection<Payment> Payments { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Acceptance> Acceptances { get; set; }
        public ICollection<Request > Requests { get; set; } 


    }
}
