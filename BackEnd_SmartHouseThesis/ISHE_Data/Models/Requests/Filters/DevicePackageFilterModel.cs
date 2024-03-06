using ISHE_Utility.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Filters
{
    public class DevicePackageFilterModel
    {
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public DevicePackageStatus? Status { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
