using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.MeetingDtos
{
    public class MeetingDto
    {
        public Guid MeetingId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string? Location { get; set; }
        public MeetingType Type { get; set; }
        public Guid JuryId { get; set; }
    }
}
