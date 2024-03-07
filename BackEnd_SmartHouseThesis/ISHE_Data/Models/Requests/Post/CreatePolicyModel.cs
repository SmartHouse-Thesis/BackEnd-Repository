using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Post
{
    public class CreatePolicyModel
    {
        public Guid DevicePackageId { get; set; }
        public string Type { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
