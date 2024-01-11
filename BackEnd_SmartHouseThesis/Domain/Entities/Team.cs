using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team :BaseEntity
    {
        public Guid? StaffId { get; set; }
        public Guid? StaffLeadId { get; set; }
        public ICollection<Staff> Staffs { get; set; } 
    }
}
