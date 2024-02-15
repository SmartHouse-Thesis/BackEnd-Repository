using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class PackageOwnerResponse
    {
        public string? PackageName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public ICollection<Image>? ImageData { get; set; }
    }
}
