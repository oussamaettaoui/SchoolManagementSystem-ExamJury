using AutoMapper;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappers
{
    public class JuryMemberProfile : Profile
    {
        public JuryMemberProfile()
        {
            CreateMap<AddJuryMemberCommand, JuryMember>();
            CreateMap<EditJuryMemberCommand, JuryMember>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.JuryMemberId));
        }
    }
}
