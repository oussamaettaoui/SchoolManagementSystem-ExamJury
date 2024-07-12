using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.MeetingFeature.Command.Commands
{
    public class AddMeetingCommand : IRequest<string>
    {
        public int Id { get; set; }

        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public string location { get; set; }
        public MeetingType type { get; set; }
        public Guid JuryId { get; set; }
        public Jury? Jury { get; set; }
    }
}
