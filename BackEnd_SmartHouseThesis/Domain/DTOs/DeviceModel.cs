using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class DeviceModel
    {
        public string? DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? DeviceType { get; set; }
    }
}
