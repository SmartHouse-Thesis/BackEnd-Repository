using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Put
{
    public class UpdateDevicePackageModel
    {
        public Guid? ManufacturerId { get; set; }
        public string? Name { get; set; }
        public int? WarrantyDuration { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public IFormFile? Image { get; set; }
        public List<Guid> SmartDevicesIds { get; set; } = new List<Guid>();
    }
}
