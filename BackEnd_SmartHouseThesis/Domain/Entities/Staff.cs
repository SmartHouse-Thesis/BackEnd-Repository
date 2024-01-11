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
        public string? RoleName { get; set; }
        /*[ForeignKey(nameof(AccountId))]
        public Guid? AccountId { get; set; } */
        public virtual Account Account { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Guid? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public ICollection<WarrantyReport> WarrantyReports { get; set; }

    }
}
