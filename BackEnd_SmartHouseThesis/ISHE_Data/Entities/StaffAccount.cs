using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class StaffAccount
    {
        public StaffAccount()
        {
            ContractAssignments = new HashSet<ContractAssignment>();
            Surveys = new HashSet<Survey>();
        }

        public Guid AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string? Avatar { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<ContractAssignment> ContractAssignments { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
