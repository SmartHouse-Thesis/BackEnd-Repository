using ISHE_Utility.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Filters
{
    public class PromotionFilterModel
    {
        public string? Name { get; set; }
        public PromotionStatus? Status { get; set; }
    }
}
