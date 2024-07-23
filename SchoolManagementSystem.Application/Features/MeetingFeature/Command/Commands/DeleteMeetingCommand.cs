using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands
{
    public class DeleteMeetingCommand : IRequest<Result>
    {
        public Guid MeetingId { get; set; }
        public DeleteMeetingCommand(Guid id)
        {
            MeetingId = id;
        }
    }
}
