using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class DeviceResponse
    {
        public string? DeviceName { get; set; }
        public decimal? Price { get; set; }
        public string? DeviceType { get; set; }
        public string? ManufactureName { get; set; }
        public ICollection<Image>? ImageData { get; set; }
    }
}
