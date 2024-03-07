using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Put
{
    public class UpdateSmartDeviceModel
    {
        public Guid? ManufacturerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? DeviceType { get; set; }
        public string? Status { get; set; }
    }
}
