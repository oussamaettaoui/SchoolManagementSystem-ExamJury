using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IJuryMemberRoleService
    {
        Task<List<JuryMemberRole>> GetJuryMemberRoleListAsync();
        Task<JuryMemberRole> GetJuryMemberRoleByIdAsync(Guid id);
        Task<Result> AddJuryMemberRoleAsync(JuryMemberRole juryMemberRole);
        Task<Result> EditJuryMemberRoleAsync(JuryMemberRole juryMemberRole);
        Task<Result> DeleteJuryMemberRoleAsync(JuryMemberRole juryMemberRole);
    }
}
