using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public class SurveyMappingProfile : Profile
    {
        public SurveyMappingProfile() 
        {
            CreateMap<AssignStaffToSurvey, Survey>()
                .ForPath(des=> des.RequestId, act=> act.MapFrom(src => src.RequestId))
                .ForPath(des => des.StaffId, act => act.MapFrom(src => src.StaffId))
                .ReverseMap();

            CreateMap<SurveyUpdate, Survey>()
                .ForPath(des => des.Id, act => act.MapFrom(src => src.Id))
                .ForPath(des => des.Description, act => act.MapFrom(src => src.Description))
                .ForPath(des => des.RoomArea, act => act.MapFrom(src => src.RoomArea))
                .ForPath(des => des.RecommendPacket, act => act.MapFrom(src => src.RecommendPacket))
               .ForPath(des => des.RequestId, act => act.MapFrom(src => src.RequestId))
               .ForPath(des => des.StaffId, act => act.MapFrom(src => src.StaffId))
               .ReverseMap();

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));

        }
    }
}
