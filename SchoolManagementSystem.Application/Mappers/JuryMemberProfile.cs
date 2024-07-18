using AutoMapper;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappers
{
    public class JuryMemberProfile : Profile
    {
        public JuryMemberProfile()
        {
            CreateMap<AddJuryMemberCommand, JuryMember>();





            CreateMap<EditJuryMemberCommand, JuryMember>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.JuryMemberId));
            CreateMap<JuryMember, JuryMemberDto>().ForMember(dest => dest.JuryMemberId, opt => opt.MapFrom(src => src.Id)).ForMember(dest=>dest.Role,opt=>opt.MapFrom(src=>src.Role));
            CreateMap<JuryMemberRole, JuryMemberRoleDto>().ForMember(dest => dest.JuryMemberRoleId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
