using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class TellerAccount
    {
        public TellerAccount()
        {
            ConstructionContracts = new HashSet<ConstructionContract>();
            Orders = new HashSet<Order>();
        }

        public Guid AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Avatar { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<ConstructionContract> ConstructionContracts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
