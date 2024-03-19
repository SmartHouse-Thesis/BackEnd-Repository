using ISHE_Data.Models.Requests.Post;

namespace ISHE_Service.Interfaces
{
    public interface IPaymentService
    {
        Task ProcessCashPayment(CreatePaymentModel model);
        Task<dynamic> ProcessZalopayPayment(CreatePaymentModel model);
        Task<dynamic> IsValidCallback(dynamic cbdata);
    }
}
