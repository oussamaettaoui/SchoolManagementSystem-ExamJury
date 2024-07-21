using AutoMapper;
using SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappers
{
    public class DayOrderProfile : Profile
    {
        public DayOrderProfile()
        {
            CreateMap<AddDayOrderCommand, DayOrder>();
            CreateMap<EditDayOrderCommand, DayOrder>().ForMember(dest => dest.Id,opt=>opt.MapFrom(src=>src.DayOrderId));
            CreateMap<DayOrder,DayOrderDto>().ForMember(dest => dest.DayOrderId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
