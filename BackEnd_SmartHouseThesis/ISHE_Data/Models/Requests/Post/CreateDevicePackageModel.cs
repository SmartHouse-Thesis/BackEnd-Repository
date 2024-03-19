using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Post
{
    public class CreateDevicePackageModel
    {
        public Guid ManufacturerId { get; set; }
        public Guid? PromotionId { get; set; }
        public string Name { get; set; } = null!;
        public int? WarrantyDuration { get; set; }
        public string Description { get; set; } = null!;

        public List<Guid> SmartDevicesIds { get; set; } = new List<Guid>();

        public IFormFile Image { get; set; } = null!;
    }
}
