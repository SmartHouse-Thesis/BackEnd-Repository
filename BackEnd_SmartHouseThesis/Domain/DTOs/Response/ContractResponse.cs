using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public  class ContractResponse
    {
        public Guid? Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? StartPlanDate { get; set; } // ngày lắp đặt
        public DateTime? EndPlanDate { get; set; } 
        public ICollection<Package> Packages { get; set; }
    }
}
