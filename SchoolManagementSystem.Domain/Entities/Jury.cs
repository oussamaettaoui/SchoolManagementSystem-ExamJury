using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Jury : Base
    {
        public string? JuryName { get; set; }
        public Guid SectorId { get; set; }
        public List<JuryMember>? JuryMembers { get; set; }
    }
}
