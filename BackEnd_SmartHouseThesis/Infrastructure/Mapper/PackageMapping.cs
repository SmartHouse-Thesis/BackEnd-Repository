using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class PackageMapping : Profile
    {
        public PackageMapping()
        {
            CreateMap<PackageRequest, Package>()
             .ForMember(des => des.PackageName, act => act.MapFrom(src => src.PackageName))
             .ForMember(des => des.Description, act => act.MapFrom(src => src.Description))
             .ForMember(des => des.Price, act => act.MapFrom(src => src.Price))
             .ForMember(des => des.PromotionPrice, act => act.MapFrom(src => src.PromotionPrice));

            CreateMap<PackageOwnerResponse, Package>()
                .ForMember(des => des.PackageName, act => act.MapFrom(src => src.PackageName))
                .ForMember(des => des.Description, act => act.MapFrom(src => src.Description))
                .ForMember(des => des.Price, act => act.MapFrom(src => src.Price))
                .ForMember(des => des.Image.Data, act => act.Condition(src => src.ImageData != null));

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
         }
    }

    }

