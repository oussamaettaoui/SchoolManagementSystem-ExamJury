using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class JuryMemberRoleRepository : Repository<JuryMemberRole>, IJuryMemberRoleRepository
    {
        public JuryMemberRoleRepository(AppDbContext db) : base(db)
        {
        }
    }
}
