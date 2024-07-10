using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class JuryMemberRepository : Repository<JuryMember>, IJuryMemberRepository
    {
        public JuryMemberRepository(AppDbContext db) : base(db){}
    }
}
