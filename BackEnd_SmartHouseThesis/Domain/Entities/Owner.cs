using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Owner : BaseEntity
    {
        /*// [ForeignKey(nameof(AccountId))]
         public Guid? AccountId { get; set; } */
        public virtual Account Account { get; set; }
        public string? RoleName { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<Package> Packages { get; set; }
        public ICollection<Promotion> Promotions { get; set; }
        public ICollection<Revenue> Revenues { get; set; }
        public ICollection<Policy> Policies { get; set; }
    }
}
