using System;
using System.Collections.Generic;

namespace ISHE_Data.Entities
{
    public partial class Policy
    {
        public Guid Id { get; set; }
        public Guid DevicePackageId { get; set; }
        public string Type { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual DevicePackage DevicePackage { get; set; } = null!;
    }
}
