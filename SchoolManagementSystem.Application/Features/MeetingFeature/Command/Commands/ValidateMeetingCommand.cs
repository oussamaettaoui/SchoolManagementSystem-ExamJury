using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands
{
    public class ValidateMeetingCommand : IRequest<Result>
    {
        public Guid MeetingId { get; set; }

        public ValidateMeetingCommand(Guid meetingId)
        {
            MeetingId = meetingId;
        }
    }
}
