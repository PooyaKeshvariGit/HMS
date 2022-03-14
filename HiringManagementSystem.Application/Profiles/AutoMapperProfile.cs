using AutoMapper;
using HiringManagementSystem.Application.Dtos;
using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Aggregations.TagAggregate;

namespace HiringManagementSystem.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        #region [-Ctor-]

        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap(); //Person Flow
            CreateMap<Tag, TagDto>().ReverseMap(); //Tag Flow
            CreateMap<Person, CreatePersonDto>().ReverseMap(); //create Person Flow
            CreateMap<Tag, CreateTagDto>().ReverseMap(); //create Tag Flow
            CreateMap<UpdatePersonDto, Person>(); //update Person Flow
        }

        #endregion
    }
}
