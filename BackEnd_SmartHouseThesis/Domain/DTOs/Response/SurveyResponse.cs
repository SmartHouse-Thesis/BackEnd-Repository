using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class SurveyResponse
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
