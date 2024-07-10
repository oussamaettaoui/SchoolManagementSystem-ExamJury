using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.JuryMemberDtos
{
    public class JuryMemberDto
    {
        public Guid JuryMemberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public int YearOfExperience { get; set; }
        public string? LatestDiploma { get; set; }
        public string? ProfileImg { get; set; }
        public JuryMemberRole Role { get; set; }
    }
}
