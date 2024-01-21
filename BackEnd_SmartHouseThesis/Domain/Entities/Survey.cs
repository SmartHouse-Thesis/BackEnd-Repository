using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Survey :BaseEntity
    {
        public string? Description { get; set; }
        public decimal? RoomArea { get; set; } 
        public Guid? RecommendPacket { get; set; }

        [ForeignKey(nameof(StaffId))]
        public Guid? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Guid? RequestId { get; set; }
        public virtual Request Request { get; set; }

    }
}
