using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
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
             .ForMember(des => des.LastName, act => act.MapFrom(src => src.LastName))
             .ReverseMap();

           /* CreateMap<AccountInfoResponse, Account>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
                .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
                .ForMember(des => des.Address, act => act.MapFrom(src => src.Address))
                .ForMember(des => des.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(des => des.LastName, act => act.MapFrom(src => src.LastName))
                .ForPath(des => des.Role.RoleName, act => act.MapFrom(src => src.RoleName))
                .ReverseMap();*/

            CreateMap<AccountResponse, Account>()
                .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
                //.ForMember(des => des.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(des => des.Address, act => act.MapFrom(src => src.Address))
                .ForMember(des => des.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(des => des.LastName, act => act.MapFrom(src => src.LastName))
                .ReverseMap();


            CreateMap<LoginRequest, Account>()
                .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
                .ForMember(des => des.Password, act => act.MapFrom(src => src.Password))
                .ReverseMap();


            CreateMap<Account, Owner>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
                .ForMember(des => des.RoleName, act => act.MapFrom(src => src.Role.RoleName))
                .ReverseMap();

            CreateMap<Account, Customer>()
               .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
               .ForMember(des => des.RoleName, act => act.MapFrom(src => src.Role.RoleName))
               .ReverseMap();

            CreateMap<Account, Staff>()
              .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
              .ForMember(des => des.RoleName, act => act.MapFrom(src => src.Role.RoleName))
              .ReverseMap();

            CreateMap<Account, Teller>()
              .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
              .ForMember(des => des.RoleName, act => act.MapFrom(src => src.Role.RoleName))
              .ReverseMap();

            CreateMap<AccountUpdate, Account>()
                .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
                .ForMember(des => des.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(des => des.Address, act => act.MapFrom(src => src.Address))
                .ForMember(des => des.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(des => des.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(des => des.ModificationDate, act => act.MapFrom(src => src.ModificationDate))
                .ReverseMap();

            CreateMap<Guid, string>().ConstructUsing(x =>x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
            
            
        }
    }
}
