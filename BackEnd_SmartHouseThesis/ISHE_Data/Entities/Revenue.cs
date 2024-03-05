using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class Revenue
    {
        public Guid Id { get; set; }
        public string ConstructionContractId { get; set; } = null!;
        public int TotalAmount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual ConstructionContract ConstructionContract { get; set; } = null!;
    }
}
