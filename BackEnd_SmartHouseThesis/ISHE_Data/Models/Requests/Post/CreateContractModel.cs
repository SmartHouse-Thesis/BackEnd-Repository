namespace ISHE_Data.Models.Requests.Post
{
    public class CreateContractModel
    {
        public Guid SurveyId { get; set; }
        public Guid TellerId { get; set; }
        public Guid StaffId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Deposit { get; set; }
        public string StartPlanDate { get; set; } = null!;
        
        public List<Guid> DevicePackages { get; set; } = new List<Guid>();
        public List<CreateContractDetailModel> ContractDetails { get; set; } = new List<CreateContractDetailModel>();
    }
}
