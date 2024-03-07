using ISHE_Utility.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Filters
{
    public class SmartDeviceFilterModel
    {
        public string? Name { get; set; }
        public string? DeviceType { get; set; }
        public SmartDeviceStatus? Status { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
