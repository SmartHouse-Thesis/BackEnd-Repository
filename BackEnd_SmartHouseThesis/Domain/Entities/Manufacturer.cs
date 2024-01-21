using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Device> Devices { get; set; }

        [ForeignKey(nameof(PackageId))]
        public Guid? PackageId { get; set; }
        public virtual Package Package { get; set; }

    }
}
