using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.DayOrderFeature.Command.Commands
{
    public class AddDayOrderCommand : IRequest<Result>
    {
        public string? MyProperty { get; set; }
    }
}
