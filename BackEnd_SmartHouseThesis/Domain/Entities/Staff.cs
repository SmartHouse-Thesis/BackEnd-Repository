using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Staff : BaseEntity
    {
        public bool? isLeader { get; set; }
        public Guid? ManageId { get; set; } //id của staffLead (dành cho các Staff thường)
        
        public string? RoleName { get; set; }
        /*[ForeignKey(nameof(AccountId))]
        public Guid? AccountId { get; set; } */
        public virtual Account Account { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Survey> Surveys { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
