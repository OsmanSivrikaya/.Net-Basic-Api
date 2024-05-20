using AutoMapper;
using Case.Dtos;
using Case.Entity;

namespace Case.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Demand, DemandCreateDto>().ReverseMap();
        }
    }
}
