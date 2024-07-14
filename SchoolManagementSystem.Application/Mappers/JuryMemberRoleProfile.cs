using AutoMapper;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappers
{
    public class JuryMemberRoleProfile : Profile
    {
        public JuryMemberRoleProfile()
        {
            CreateMap<JuryMemberRole,JuryMemberRoleDto>().ForMember(dest=>dest.JuryMemberRoleId,opt=>opt.MapFrom(src=>src.Id));
        }
    }
}
