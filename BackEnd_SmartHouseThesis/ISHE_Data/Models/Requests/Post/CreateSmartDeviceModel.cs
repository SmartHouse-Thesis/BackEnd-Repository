using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Post
{
    public class CreateSmartDeviceModel
    {
        public Guid ManufacturerId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public string? DeviceType { get; set; }

        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}
