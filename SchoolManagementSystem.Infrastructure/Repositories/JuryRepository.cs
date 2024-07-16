using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class JuryRepository : Repository<Jury>, IJuryRepository
    {
        private readonly AppDbContext _db;
        public JuryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        


    }
}
