using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contract : BaseEntity
    {
        public string? Email { get; set; } 
        public string? Description { get; set; }
        public decimal? TotalCost { get; set; }
        public int? Status { get; set; } // trạng thái của Constract: chưa cọc,đặt cọc - scan, lắp đặt, nghiệm thu, xóa 
        public DateTime? StartPlanDate { get; set; } // ngày lắp đặt
        public DateTime? EndPlanDate { get; set; } // ngày hoàn thành
        public string? ImageFile { get; set; } // ảnh của hợp đồng

        public ICollection<Payment> Payments { get; set; }
        public ICollection<Package> Packages { get; set; }  
        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(TellerId))]
        public Guid? TellerId { get; set; }
        public virtual Teller Teller { get; set; }

        [ForeignKey(nameof(StaffId))]
        public Guid? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(RevenueId))]
        public Guid? RevenueId { get; set; }
        public virtual Revenue Revenue { get; set; }

        [ForeignKey(nameof(AcceptanceId))]
        public Guid? AcceptanceId { get; set; }
        public virtual Acceptance Acceptance { get; set; }

    }
}
