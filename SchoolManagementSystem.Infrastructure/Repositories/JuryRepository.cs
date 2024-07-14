using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class JuryRepository : Repository<Jury>, IJuryRepository
    {
        public JuryRepository(AppDbContext db) : base(db)
        {
        }
    }
}
