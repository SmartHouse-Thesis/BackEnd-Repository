using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class Acceptance
    {
        public Guid Id { get; set; }
        public Guid CustomertId { get; set; }
        public string ConstructionContractId { get; set; } = null!;
        public DateTime StartWarranty { get; set; }
        public string ImageUrl { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual ConstructionContract ConstructionContract { get; set; } = null!;
        public virtual CustomerAccount Customert { get; set; } = null!;
    }
}
