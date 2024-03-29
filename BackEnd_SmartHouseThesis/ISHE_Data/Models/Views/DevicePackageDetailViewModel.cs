﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISHE_Data.Entities;

namespace ISHE_Data.Models.Views
{
    public class DevicePackageDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int? WarrantyDuration { get; set; }
        public int CompletionTime { get; set; }

        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual ManufacturerViewModel Manufacturer { get; set; } = null!;
        public virtual PromotionViewModel? Promotion { get; set; }

        //public virtual ICollection<FeedbackDevicePackage> FeedbackDevicePackages { get; set; }
        public virtual ICollection<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();
        //public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<SmartDeviceViewModel> SmartDevices { get; set; } = new HashSet<SmartDeviceViewModel>();
    }
}
