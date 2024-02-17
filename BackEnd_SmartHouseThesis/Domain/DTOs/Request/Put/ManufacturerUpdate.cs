using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Put
{
    public class ManufacturerUpdate
    {
        [Required]
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
