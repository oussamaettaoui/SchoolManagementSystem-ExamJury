using AutoMapper;
using SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands;
using SchoolManagementSystem.Domain.Dtos.DayOrderModelDtos;
using SchoolManagementSystem.Domain.Dtos.JuryDtos;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappers
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile() 
        {
            CreateMap<AddMeetingCommand, Meeting>().ForMember(dest => dest.DayOrderModels, opt => opt.MapFrom(src=>src.AddDayOrderModels.Select(dom=> new DayOrderModel
            {
                Id = dom.DayOrderId,
                DayOrderTitle = dom.DayOrderTitle,
                DocumentPath = dom.DocumentPath
            })));
            //
            CreateMap<UpdateMeetingCommand, Meeting>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MeetingId));
            //
            CreateMap<Meeting, MeetingDto>().ForMember(dest => dest.MeetingId, opt => opt.MapFrom(src => src.Id)).ForMember(dest=>dest.Jury,opt=>opt.MapFrom(src=>src.Jury));
            //
            CreateMap<Meeting, SingleMeetingDto>().ForMember(dest => dest.MeetingId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.Jury, opt => opt.MapFrom(src => src.Jury)).ForMember(dest=>dest.DayOrderModels,opt=>opt.MapFrom(src=>src.DayOrderModels));

            //
            CreateMap<Jury, JuryDto>().ForMember(dest => dest.JuryId, opt => opt.MapFrom(src => src.Id));
            CreateMap<DayOrderModel,AddDayOrderModel>().ForMember(dest=>dest.DayOrderId,opt=>opt.MapFrom(src=>src.Id)).ReverseMap();
            //
            CreateMap<Jury, SingleJuryDto>().ForMember(dest => dest.JuryId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.JuryMembers, opt => opt.MapFrom(src => src.JuryMembers)); 
        }
    }
}
