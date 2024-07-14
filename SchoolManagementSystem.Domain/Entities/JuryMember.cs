using System.Text.Json.Serialization;
using SchoolManagementSystem.Domain.Common;

namespace SchoolManagementSystem.Domain.Entities
{
    public class JuryMember : Base
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public int YearOfExperience { get; set; }
        public string? LatestDiploma { get; set; }
        public string? ProfileImg { get; set; }
        public Guid RoleId { get; set; }
        public JuryMemberRole? Role { get; set; }
        public Guid JuryId { get; set; }
        [JsonIgnore]
        public Jury? Jury { get; set; }
    }
}
