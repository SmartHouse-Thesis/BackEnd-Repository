using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Constract :BaseEntity
    {
        public string? Title { get; set; } 
        public string? Description { get; set; }
        public decimal? TotalCost { get; set; }
        public int? Status { get; set; }
        
        public string? ImageFile { get; set; }


    }
}
