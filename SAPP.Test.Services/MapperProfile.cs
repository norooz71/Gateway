using AutoMapper;
using SAPP.Gateway.Contracts.Dtos;
using SAPP.Gateway.Domain.Entities.Test;

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
