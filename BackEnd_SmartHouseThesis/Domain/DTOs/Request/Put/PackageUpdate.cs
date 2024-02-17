using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Put
{
    public class PackageUpdate
    {
        [Required]
        public Guid Id { get; set; }
        public string? PackageName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public ICollection<Device>? Devices { get; set; }
        public ICollection<Image>? ImageData { get; set; }
    }
}
