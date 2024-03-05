﻿using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class Payment
    {
        public string Id { get; set; } = null!;
        public string ConstructionContractId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
        public int Amount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual ConstructionContract ConstructionContract { get; set; } = null!;
    }
}
