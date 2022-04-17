using AutoMapper;
using SAPP.Test.Contracts.Dtos;
using SAPP.Test.Domain.Entities.Test;

namespace SAPP.Test.Services
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
