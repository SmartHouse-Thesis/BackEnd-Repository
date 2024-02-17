using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Request : BaseEntity 
    {
        public string? Description { get; set; }
        public int? Status { get; set; } //trạng thái của yêu cầu: draft, hủy,đang khảo sát,duyệt 
        public DateTime? RequestDate { get; set; } // ngày khách hàng yêu cầu Khảo sát  

        [ForeignKey(nameof(CustomerId))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        [ForeignKey(nameof(SurveyId))]
        public Guid? SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

    }
}
