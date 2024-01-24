using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.DTOs.Request;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile() 
        {
            CreateMap<RegisterRequest, Account>()
             .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
             .ForMember(des => des.Phone, act => act.MapFrom(src => src.Phone))
             .ForMember(des => des.Password, act => act.MapFrom(src => src.Password))
             .ForMember(des => des.Address, act => act.MapFrom(src => src.Address))
             .ForMember(des => des.FirstName, act => act.MapFrom(src => src.FirstName))
             .ForMember(des => des.LastName, act => act.MapFrom(src => src.LastName));

            CreateMap<Account, Owner>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
                .ForMember(des => des.RoleName, act => act.MapFrom(src => src.Role.RoleName));

            CreateMap<AccountUpdate, Account>()
                .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
                .ForMember(des => des.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(des => des.Address, act => act.MapFrom(src => src.Address))
                .ForMember(des => des.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(des => des.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(des => des.ModificationDate, act => act.MapFrom(src => src.ModificationDate));

        CreateMap<Guid, string>().ConstructUsing(x =>x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
            
            
        }
    }
}
