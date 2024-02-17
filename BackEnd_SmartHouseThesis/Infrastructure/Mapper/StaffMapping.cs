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
                .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
                .ForPath(des => des.Email, act => act.MapFrom(src => src.Email))
                .ForPath(des => des.Phone, act => act.MapFrom(src => src.Phone))
                .ForPath(des => des.Address, act => act.MapFrom(src => src.Address))
                .ForPath(des => des.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForPath(des => des.LastName, act => act.MapFrom(src => src.LastName))
                .ForPath(des => des.Role.RoleName, act => act.MapFrom(src => src.RoleName))
                .ReverseMap();

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
        }
    }
}
