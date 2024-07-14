using AutoMapper;
using SchoolManagementSystem.Domain.Dtos.JuryDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappers
{
    public class JuryProfile : Profile
    {
        public JuryProfile()
        {
            CreateMap<Jury, JuryDto>().ForMember(dest=>dest.JuryId,opt => opt.MapFrom(src=> src.Id));
        }
    }
}
