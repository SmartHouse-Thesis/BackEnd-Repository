using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class PromotionMapping : Profile
    {
        public PromotionMapping()
        {
            CreateMap<PromotionRequest, Promotion>()
            .ForMember(des => des.Discount, act => act.MapFrom(src => src.Discount))
            .ForMember(des => des.StartDate, act => act.MapFrom(src => src.StartDate))
            .ForMember(des => des.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
            .ForMember(des => des.Description, act => act.MapFrom(src => src.Description))
            .ReverseMap();

            CreateMap<PromotionResponse, Promotion>()
            .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
            .ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
            .ForMember(des => des.Description, act => act.MapFrom(src => src.Description))
            .ForMember(des => des.Discount, act => act.MapFrom(src => src.Discount))
            .ForMember(des => des.StartDate, act => act.MapFrom(src => src.StartDate))
            .ForMember(des => des.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(des => des.CreationDate, act => act.MapFrom(src => src.CreationDate))
            .ReverseMap();

            CreateMap<PromotionUpdate, Promotion>()
           .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
           .ForMember(des => des.Discount, act => act.MapFrom(src => src.Discount))
           .ForMember(des => des.StartDate, act => act.MapFrom(src => src.StartDate))
           .ForMember(des => des.EndDate, act => act.MapFrom(src => src.EndDate))
           .ReverseMap();

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));

        }
    }
}
