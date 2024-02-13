using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public  class PolicyMapping :Profile
    {

        public PolicyMapping()
        {
            CreateMap<PolicyRequest, Policy>()
            .ForMember(des => des.Type, act => act.MapFrom(src => src.Type))
            .ForMember(des => des.Content, act => act.MapFrom(src => src.Content));

            CreateMap<Guid, string>().ConstructUsing(x => x.ToString());
            CreateMap<string, Guid>().ConstructUsing(x => new Guid(x));
        }
       
    }
}
