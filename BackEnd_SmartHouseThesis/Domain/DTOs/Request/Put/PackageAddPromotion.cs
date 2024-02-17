using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Put
{
    public class PackageAddPromotion
    {
        [Required]
        public Guid PackageId { get; set; }
        [Required]
        public Guid PromotionId { get; set; }
    }
}
