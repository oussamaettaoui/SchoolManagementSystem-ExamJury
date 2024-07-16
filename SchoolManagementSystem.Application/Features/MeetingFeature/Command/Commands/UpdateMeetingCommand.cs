using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands
{
    public class UpdateMeetingCommand : IRequest<Result>
    {
        public Guid MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Location { get; set; }
        public MeetingType Type { get; set; }
        public Guid JuryId { get; set; }
    }
}
