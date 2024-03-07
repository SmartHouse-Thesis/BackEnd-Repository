using ISHE_Data.Models.Requests.Post;
using ISHE_Data.Models.Requests.Put;
using ISHE_Data.Models.Views;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Service.Interfaces
{
    public interface IOwnerService
    {
        Task<List<OwnerViewModel>> GetOwners();
        Task<OwnerViewModel> GetOwner(Guid id);
        Task<OwnerViewModel> CreateOwner(RegisterOwnerModel model);
        Task<OwnerViewModel> UpdateOwner(Guid id, UpdateOwnerModel model);
        Task<OwnerViewModel> UploadAvatar(Guid id, IFormFile image);
    }
}
