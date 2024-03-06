using AutoMapper;
using ISHE_Data.Entities;
using ISHE_Data.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Role, RoleViewModel>();

            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.RoleName, otp => otp.MapFrom(acc => acc.Role.RoleName))
                .ForMember(dest => dest.FullName, otp => otp.MapFrom(acc => acc.OwnerAccount != null ? acc.OwnerAccount.FullName :
                                                         (acc.StaffAccount != null ? acc.StaffAccount.FullName :
                                                         (acc.TellerAccount != null ? acc.TellerAccount.FullName :
                                                         (acc.CustomerAccount != null ? acc.CustomerAccount.FullName : string.Empty)))))
                .ForMember(dest => dest.Email, otp => otp.MapFrom(acc => acc.OwnerAccount != null ? acc.OwnerAccount.Email :
                                                         (acc.StaffAccount != null ? acc.StaffAccount.Email :
                                                         (acc.TellerAccount != null ? acc.TellerAccount.Email :
                                                         (acc.CustomerAccount != null ? acc.CustomerAccount.Email : string.Empty)))))
                .ForMember(dest => dest.Avatar, otp => otp.MapFrom(acc => acc.OwnerAccount != null ? acc.OwnerAccount.Avatar :
                                         (acc.StaffAccount != null ? acc.StaffAccount.Avatar :
                                         (acc.TellerAccount != null ? acc.TellerAccount.Avatar :
                                         (acc.CustomerAccount != null ? acc.CustomerAccount.Avatar : string.Empty)))));

            CreateMap<OwnerAccount, OwnerViewModel>()
                .ForMember(dest => dest.PhoneNumber, otp => otp.MapFrom(acc => acc.Account.PhoneNumber))
                .ForMember(dest => dest.RoleName, otp => otp.MapFrom(acc => acc.Account.Role.RoleName))
                .ForMember(dest => dest.Status, otp => otp.MapFrom(acc => acc.Account.Status))
                .ForMember(dest => dest.CreateAt, otp => otp.MapFrom(acc => acc.Account.CreateAt));

            CreateMap<StaffAccount, StaffViewModel>()
                .ForMember(dest => dest.PhoneNumber, otp => otp.MapFrom(acc => acc.Account.PhoneNumber))
                .ForMember(dest => dest.RoleName, otp => otp.MapFrom(acc => acc.Account.Role.RoleName))
                .ForMember(dest => dest.Status, otp => otp.MapFrom(acc => acc.Account.Status))
                .ForMember(dest => dest.CreateAt, otp => otp.MapFrom(acc => acc.Account.CreateAt));

            CreateMap<CustomerAccount, CustomerViewModel>()
                .ForMember(dest => dest.PhoneNumber, otp => otp.MapFrom(acc => acc.Account.PhoneNumber))
                .ForMember(dest => dest.RoleName, otp => otp.MapFrom(acc => acc.Account.Role.RoleName))
                .ForMember(dest => dest.Status, otp => otp.MapFrom(acc => acc.Account.Status))
                .ForMember(dest => dest.CreateAt, otp => otp.MapFrom(acc => acc.Account.CreateAt));

            CreateMap<Image, ImageViewModel>();
            CreateMap<Manufacturer, ManufacturerViewModel>();
            CreateMap<SmartDevice, SmartDeviceDetailViewModel>();
            CreateMap<SmartDevice, SmartDeviceViewModel>()
                .ForMember(dest => dest.Image, otp => otp.MapFrom(src => src.Images.FirstOrDefault()!.Url));
            CreateMap<Promotion, PromotionViewModel>();
            CreateMap<Promotion, PromotionDetailViewModel>();
            CreateMap<DevicePackage, DevicePackageViewModel>();
            CreateMap<DevicePackage, DevicePackageDetailViewModel>();
            CreateMap<Policy, PolicyViewModel>();
        }
    }
}
