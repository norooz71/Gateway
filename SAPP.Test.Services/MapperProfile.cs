using AutoMapper;
using SAPP.Gateway.Domain.Entities.Test;
using SAPP.Gateway.Services.Abstractions.Dtos;
using SAPP.Gateway.Services.Abstractions.Dtos.Test;

namespace SAPP.Gateway.Services
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<TestParent, TestParentDto>().ReverseMap();
            
            CreateMap<TestChild, TestChildDto>().ReverseMap();


        }

    }
}
