using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands
{
    public class EditDayOrderCommand : IRequest<Result>
    {
        public Guid DayOrderId { get; set; }
        public string? DayOrderTitle { get; set; }
    }
}
