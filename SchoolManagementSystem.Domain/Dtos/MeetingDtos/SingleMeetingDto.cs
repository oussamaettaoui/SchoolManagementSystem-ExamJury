using SchoolManagementSystem.Domain.Dtos.JuryDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.MeetingDtos
{
    public class SingleMeetingDto
    {
        public Guid MeetingId { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Location { get; set; }
        public MeetingType Type { get; set; }
        public SingleJuryDto? Jury { get; set; }
    }
}
