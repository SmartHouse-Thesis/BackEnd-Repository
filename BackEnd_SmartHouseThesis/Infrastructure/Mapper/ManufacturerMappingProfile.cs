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
    public  class ManufacturerMappingProfile :Profile
    {
            public ManufacturerMappingProfile()
            {
            CreateMap<ManufactureResponse, Manufacturer>()
             .ForMember(des => des.Id, act => act.MapFrom(src => src.Id))
             .ForMember(des => des.Name, act => act.MapFrom(src => src.Name))
             .ReverseMap();
            }
    }
}
