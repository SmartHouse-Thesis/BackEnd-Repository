using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Post
{
    public class DeviceRequest
    {
        [Required]
        public string DeviceName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string DeviceType { get; set; }
        [Required]
        public string ManufacturerName { get; set; }

        //public ICollection<Image>? Images { get; set; }

    }
}
