using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.JuryDtos
{
    public class SingleJuryDto
    {
        public Guid JuryId { get; set; }
        public string? JuryName { get; set; }
        public Guid SectorId { get; set; }
        public List<JuryMemberDto>? JuryMembers { get; set; }
        public Status Status { get; set; }
    }
}
