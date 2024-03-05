using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class ConstructionContract
    {
        public ConstructionContract()
        {
            ContractAssignments = new HashSet<ContractAssignment>();
            Payments = new HashSet<Payment>();
            Revenues = new HashSet<Revenue>();
        }

        public string Id { get; set; } = null!;
        public Guid DevicePackageId { get; set; }
        public Guid TellerId { get; set; }
        public Guid CustomerId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? StartPlanDate { get; set; }
        public DateTime? EndPlanDate { get; set; }
        public int TotalAmount { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int Deposit { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual CustomerAccount Customer { get; set; } = null!;
        public virtual DevicePackage DevicePackage { get; set; } = null!;
        public virtual TellerAccount Teller { get; set; } = null!;
        public virtual Acceptance? Acceptance { get; set; }
        public virtual ICollection<ContractAssignment> ContractAssignments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Revenue> Revenues { get; set; }
    }
}
