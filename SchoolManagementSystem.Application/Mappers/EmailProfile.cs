using AutoMapper;
using SchoolManagementSystem.Application.Features.EmailFeature.Command.Commands;
using SchoolManagementSystem.Domain.Dtos.EmailDtos;

namespace SchoolManagementSystem.Application.Mappers
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<SendEmailCommand,EmailDto>();
        }
    }
}
