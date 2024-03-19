namespace ISHE_Data.Models.Requests.Post
{
    public class CreateContractDetailModel
    {
        public Guid SmartDeviceId { get; set; }
        public int Quantity { get; set; }

        public bool IsInstallation { get; set; }

    }
}
