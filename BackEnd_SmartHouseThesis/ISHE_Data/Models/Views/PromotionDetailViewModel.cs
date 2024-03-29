﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Views
{
    public class PromotionDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual ICollection<DevicePackageViewModel> DevicePackages { get; set; } = new List<DevicePackageViewModel>();
    }
}
