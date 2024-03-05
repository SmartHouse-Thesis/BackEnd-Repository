using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; } = null!;
        public Guid SmartDeviceId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual SmartDevice SmartDevice { get; set; } = null!;
    }
}
