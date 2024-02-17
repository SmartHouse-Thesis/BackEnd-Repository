using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Put
{
    public class AssignStaffToSurvey
    {
        [Required]
        public Guid RequestId { get; set; }
        [Required]
        public Guid StaffId { get; set; }
    }
}
