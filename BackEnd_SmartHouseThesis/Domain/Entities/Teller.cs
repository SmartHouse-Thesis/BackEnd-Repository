using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teller : BaseEntity
    {
        /*
               [ForeignKey(nameof(AccountId))]
                public Guid? AccountId { get; set; } */
        public virtual Account Account { get; set; }
        public string? RoleName { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Constract> Constracts { get; set; }

    }
}
