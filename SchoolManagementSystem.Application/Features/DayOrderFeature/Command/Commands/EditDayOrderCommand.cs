using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands
{
    public class EditDayOrderCommand : IRequest<Result>
    {
        public string? MyProperty { get; set; }
        public Guid DayOrderId { get; internal set; }
    }
}
