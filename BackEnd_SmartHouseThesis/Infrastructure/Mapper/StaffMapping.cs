using AutoMapper;
using Domain.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class StaffMapping : Profile
    {
        public StaffMapping()
        {
            CreateMap<StaffResponse, Account>()
                .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
                .ForMember(des => des.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(des => des.Address, act => act.MapFrom(src => src.Address))
                .ForMember(des => des.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(des => des.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(des => des.Role.RoleName, act => act.MapFrom(src => src.RoleName));

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
        }
    }
}
