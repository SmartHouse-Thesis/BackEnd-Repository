using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image :BaseEntity
    {
        public string? Data { get; set; }


        [ForeignKey(nameof(DeviceId))]
        public Guid? DeviceId { get; set; }
        public virtual Device Device { get; set; }
        
    }
}
