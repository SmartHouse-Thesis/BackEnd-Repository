using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class ContractAssignment
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public string ConstructionContractId { get; set; } = null!;
        public bool IsLeader { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual ConstructionContract ConstructionContract { get; set; } = null!;
        public virtual StaffAccount Staff { get; set; } = null!;
    }
}
