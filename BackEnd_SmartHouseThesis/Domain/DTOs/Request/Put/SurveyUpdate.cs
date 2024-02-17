using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request.Put
{
    public class SurveyUpdate
    {
        [Required]
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal? RoomArea { get; set; }
        public Guid? RecommendPacket { get; set; }

        public Guid? StaffId { get; set; }
        public Guid? RequestId { get; set; }
    }
}
