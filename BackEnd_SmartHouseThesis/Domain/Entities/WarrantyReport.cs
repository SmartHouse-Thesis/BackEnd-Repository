using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WarrantyReport : BaseEntity
    {

        /* public DateTime? StartWarranty { get; set; } // ngày được Bắt đầu bảo hành
         public DateTime? EndWarranty { get; set; } // ngày kết thúc Bảo Hành*/



        //CreationDate ngày tạo bảng bảo hành
        public string? Description { get; set; } // mô tả vấn đề cần bảo hành
        public string? ImageFile { get; set; } // ảnh lỗi cần bảo hành
        public DateTime? ResolveDate { get; set; } // ngày sau khi bảo hành cho khách hàng thành công



        public virtual Device Device { get; set; }

        [ForeignKey(nameof(StaffId))]
        public Guid? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

/*        [ForeignKey(nameof(AcceptanceId))]
        public Guid? AcceptanceId { get; set; }
        public virtual Acceptance Acceptance { get; set; }*/
    }
}
