using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Post
{
    public class ContractRequest
    {
        [Required]
        public Guid TellerId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Package>? Packages { get; set; }
        //public ICollection<Device>? Devices { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        //public int? Status { get; set; } // trạng thái của Constract: chưa cọc,đặt cọc - scan, lắp đặt, nghiệm thu, xóa 
        public DateTime? StartPlanDate { get; set; } // ngày lắp đặt
        public DateTime? EndPlanDate { get; set; } // ngày hoàn thành


    }
}
