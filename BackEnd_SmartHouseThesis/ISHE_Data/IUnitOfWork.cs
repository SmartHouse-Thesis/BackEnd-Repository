using ISHE_Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data
{
    public interface IUnitOfWork
    {
        public IAcceptanceRepository Acceptance { get; }
        public IAccountRepository Account { get; }
        public ICustomerAccountRepository CustomerAccount { get; }
        public IOwnerAccountRepository OwnerAccount { get; }
        public IRoleRepository Role { get; }
        public IStaffAccountRepository StaffAccount { get; }
        public ITellerAccountRepository TellerAccount { get; }
        public ISmartDeviceRepository SmartDevice { get; }
        public IImageRepository Image { get; }
        public IManufacturerRepository Manufacturer { get; }
        public IPromotionRepository Promotion { get; }
        public IDevicePackageRepository DevicePackage { get; }
        public ISurveyRequestRepository SurveyRequest { get; }
        public ISurveyRepository Survey { get; }
        public IContractRepository Contract { get; }
        public IContractDetailRepository ContractDetail { get; }
        public IDevicePackageUsageRepository DevicePackageUsage { get; }
        public IPaymentRepository Payment { get; }
        public ISmartDevicePackageRepository SmartDevicePackage { get; }
        public IFeedbackDevicePackageRepository FeedbackDevicePackage { get; }

        Task<int> SaveChanges();
        IDbContextTransaction Transaction();
    }
}
