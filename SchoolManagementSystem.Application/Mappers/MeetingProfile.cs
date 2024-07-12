using AutoMapper;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Mappers
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile() 
        {
            CreateMap<AddMeetingCommand, Meeting>();
            CreateMap<UpdateMeetingCommand, Meeting>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MeetingId));
        }
    }
}
