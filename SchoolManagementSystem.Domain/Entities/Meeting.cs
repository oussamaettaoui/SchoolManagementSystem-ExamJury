using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Meeting : Base
    {
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Location { get; set; }
        public MeetingType Type { get; set; }
        public Guid JuryId { get; set; }
        public Jury? Jury { get; set; }
    }
}
