using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Account :BaseEntity 
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //
        [ForeignKey(nameof(RoleId))]
        public Guid? RoleId { get; set; }
        public virtual Role Role { get; set; }
        /// <summary>
        /// /////////////////////////////// 
        /// </summary>
        public virtual Staff Staff { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual Teller Teller { get; set; }
        //

        public ICollection<Survey> Surveys { get; set; }  
    }
}
