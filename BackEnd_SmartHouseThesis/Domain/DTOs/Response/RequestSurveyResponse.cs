using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class RequestSurveyResponse
    {
        public Guid? Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? Status { get; set; }
    }
}
