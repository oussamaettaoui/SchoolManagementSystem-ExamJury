using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Jury : Base
    {
        public string? JuryName { get; set; }
        public int SectorId { get; set; }
        public List<JuryMember>? JuryMembers { get; set; }
        public Guid MeetingId { get; set; }
        public Meeting? Meeting { get; set; }
    }
}
