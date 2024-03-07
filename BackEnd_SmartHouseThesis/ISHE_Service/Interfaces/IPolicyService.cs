using ISHE_Data.Models.Requests.Post;
using ISHE_Data.Models.Requests.Put;
using ISHE_Data.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Service.Interfaces
{
    public interface IPolicyService
    {
        Task<PolicyViewModel> GetPolicy(Guid id);
        Task<PolicyViewModel> CreatePolicy(CreatePolicyModel model);
        Task<PolicyViewModel> UpdatePolicy(Guid id, UpdatePolicyModel model);
    }
}
