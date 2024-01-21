using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Acceptance : BaseEntity
    {

        public DateTime? StartWarranty { get; set; } // ngày bắt đầu bảo hành 
        public string? ImageFile { get; set; } // ảnh bảng nghiệm thu

        //
        [ForeignKey(nameof(ContractId))]
        public Guid? ContractId { get; set; }
        public virtual Contract Contract { get; set; }


        //
        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set;}
        public virtual Customer Customer { get; set; }


        /*
        [ForeignKey(nameof(WarrantyId))]
        public Guid? WarrantyId { get; set; }
        public virtual WarrantyReport WarrantyReport { get; set; }*/

    }
}
