using ISHE_Data.Models.Requests.Filters;
using ISHE_Data.Models.Requests.Get;
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
    public interface IPromotionService
    {
        Task<ListViewModel<PromotionViewModel>> GetPromotions(PromotionFilterModel filter, PaginationRequestModel pagination);
        Task<PromotionDetailViewModel> GetPromotion(Guid id);
        Task<PromotionDetailViewModel> CreatePromotion(CreatePromotionModel model);
        Task<PromotionDetailViewModel> UpdatePromotion(Guid id, UpdatePromotionModel model);
    }
}
