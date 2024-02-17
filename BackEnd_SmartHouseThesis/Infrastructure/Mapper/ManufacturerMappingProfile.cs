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
    public  class ManufacturerMappingProfile :Profile
    {
            public ManufacturerMappingProfile()
            {
            CreateMap<ManufactureResponse, Manufacturer>()
             .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
             .ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
             .ReverseMap();

            CreateMap<ManufacturerRequest, Manufacturer>()
             .ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
             .ReverseMap();

            CreateMap<ManufacturerUpdate, Manufacturer>()
             .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
             .ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
             .ForMember(des => des.ModificationDate, act => act.MapFrom(src => src.ModificationDate))
             .ReverseMap();

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
        }
    }
}
