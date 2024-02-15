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
    public class RequestMapping : Profile
    {
        public RequestMapping() {
            CreateMap<RequestResponse, Request>()
                .ForPath(des => des.Customer.Account.LastName, act => act.MapFrom(src => src.Name))
                .ForPath(des => des.Customer.Account.Address, act => act.MapFrom(src => src.Address))
                .ForPath(des => des.RequestDate, act => act.MapFrom(src => src.RequestDate));
        }
    }
}
