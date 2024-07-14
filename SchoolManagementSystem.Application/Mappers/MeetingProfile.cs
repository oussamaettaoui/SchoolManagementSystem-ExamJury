using AutoMapper;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappers
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile() 
        {
            CreateMap<AddMeetingCommand, Meeting>();
            CreateMap<UpdateMeetingCommand, Meeting>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MeetingId));
            CreateMap<Meeting, MeetingDto>().ForMember(dest => dest.MeetingId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
