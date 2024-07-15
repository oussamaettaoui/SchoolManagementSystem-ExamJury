using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands
{
    public class AddMeetingCommand : IRequest<Result>
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string? Location { get; set; }
        public MeetingType Type { get; set; }
        public Guid JuryId { get; set; }
    }
}
