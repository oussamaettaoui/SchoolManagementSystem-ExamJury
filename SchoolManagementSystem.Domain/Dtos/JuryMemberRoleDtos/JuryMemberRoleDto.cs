using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos
{
    public class JuryMemberRoleDto
    {
        public Guid JuryMemberRoleId { get; set; }
        public string? Role { get; set; }
        public Status Status { get; set; }
    }
}
