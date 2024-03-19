using ISHE_Data.Models.Requests.Post;

namespace ISHE_Data.Models.Requests.Put
{
    public class UpdateContractModel
    {
        public Guid? StaffId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Deposit { get; set; }
        public DateTime? StartPlanDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string? Status { get; set; }
        public List<Guid>? DevicePackages { get; set; } = new List<Guid>();

        public List<CreateContractDetailModel>? ContractDetails { get; set; }
    }
}
