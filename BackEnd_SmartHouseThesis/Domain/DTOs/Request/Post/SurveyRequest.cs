using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Post
{
    public class SurveyRequest
    {
        [Required]
        public Guid CustomerId { get; set; } 
        public string? Description { get; set; }
        public int? Status { get; set; } //trạng thái của yêu cầu: hủy-0, đang chờ-1,đang khảo sát-2, hoàn thành-3 
        [Required]
        public DateTime? RequestDate { get; set; } // ngày khách hàng yêu cầu Khảo sát  
    }
}
