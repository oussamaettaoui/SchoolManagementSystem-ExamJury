using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class JuryMemberRepository : Repository<JuryMember>, IJuryMemberRepository
    {
        private readonly AppDbContext _db;
        public JuryMemberRepository(AppDbContext db) : base(db){
            _db = db;
        }

        public async Task<List<JuryMember>> GetJuryMembersWithRoleAsync()
        {
            List<JuryMember> juryMembers = await _db.JuryMembers.AsNoTracking().Include(x => x.Role).ToListAsync();
            return juryMembers;
        }

        public async Task<JuryMember> GetJuryMemberWithRoleAsync(Expression<Func<JuryMember, bool>> filter)
        {
            JuryMember juryMember = await _db.JuryMembers.AsNoTracking().Where(filter).Include(x=>x.Role).FirstOrDefaultAsync();
            return juryMember;
        }
    }
}
