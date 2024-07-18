using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Domain.Dtos.DayOrderDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands
{

    public class DeleteDayOrderCommand : IRequest<Result>
    {
        public Guid DayOrderId { get; set; }
        public DeleteDayOrderCommand(Guid id)
        {
            DayOrderId = id;
        }

    }
}

