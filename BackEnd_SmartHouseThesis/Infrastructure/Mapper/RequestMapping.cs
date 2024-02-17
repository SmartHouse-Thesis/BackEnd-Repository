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
    public class RequestMapping : Profile
    {
        public RequestMapping() {
            CreateMap<RequestSurveyResponse, Request>()
                .ForPath(des => des.Id, act => act.MapFrom(src => src.Id))
                .ForPath(des => des.Customer.Account.LastName, act => act.MapFrom(src => src.CustomerName))
                .ForPath(des => des.Customer.Account.Address, act => act.MapFrom(src => src.Address))
                .ForPath(des => des.Customer.Account.Phone, act => act.MapFrom(src => src.Phone !=null))
                .ForPath(des => des.RequestDate, act => act.MapFrom(src => src.RequestDate))
                .ForPath(des => des.Status, act => act.MapFrom(src => src.Status != null))
                .ReverseMap();

            CreateMap<SurveyRequest, Request>()
                .ForPath(des => des.Description, act => act.MapFrom(src => src.Description!= null))
                .ForPath(des => des.CustomerId, act => act.MapFrom(src => src.CustomerId))
                .ForPath(des => des.RequestDate, act => act.MapFrom(src => src.RequestDate))
                .ForPath(des => des.Status, act => act.MapFrom(src => src.Status != null))
                .ReverseMap();

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
        }
    }
}
