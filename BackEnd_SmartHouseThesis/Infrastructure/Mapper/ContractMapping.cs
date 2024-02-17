using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public  class ContractMapping :Profile
    {
        public ContractMapping()
        {
            CreateMap<ContractRequest, Contract>()
             .ForMember(des => des.CustomerId, act => act.MapFrom(src => src.CustomerId))
             .ForMember(des => des.TellerId, act => act.MapFrom(src => src.TellerId))
             .ForMember(des => des.TotalCost, act => act.MapFrom(src => src.TotalCost))
             .ForMember(des => des.Description, act => act.MapFrom(src => src.Description))
             .ForPath(des => des.StartPlanDate, act => act.MapFrom(src=> src.StartPlanDate))
             .ForPath(des => des.EndPlanDate, act => act.MapFrom(src => src.EndPlanDate))
             .ForPath(des => des.Packages, act => act.MapFrom(src => src.Packages))
             .ReverseMap();

            CreateMap<ContractResponse, Contract>()
             .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
             .ForPath(des => des.Customer.Account.LastName, act => act.MapFrom(src => src.CustomerName !=null))
             .ForMember(des => des.Description, act => act.MapFrom(src => src.Description))
             .ForMember(des => des.TotalCost, act => act.MapFrom(src => src.TotalCost))
             .ForPath(des => des.StartPlanDate, act => act.MapFrom(src => src.StartPlanDate))
             .ForPath(des => des.EndPlanDate, act => act.MapFrom(src => src.EndPlanDate))
             .ForPath(des => des.Packages, act => act.MapFrom(src => src.Packages))
             .ReverseMap();

        CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
        }
    }
}
