using System.Linq.Expressions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IRepositories
{
    public interface IJuryMemberRepository : IRepository<JuryMember>
    {
        Task<List<JuryMember>> GetJuryMembersWithRoleAsync();
        Task<JuryMember> GetJuryMemberWithRoleAsync(Expression<Func<JuryMember, bool>> filter);
    }
}
