using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Dtos.JuryDtos
{
    public class JuryDto
    {
        public Guid JuryId { get; set; }
        public string? JuryName { get; set; }
        public Guid SectorId { get; set; }
        public Status Status { get; set; }
    }
}
