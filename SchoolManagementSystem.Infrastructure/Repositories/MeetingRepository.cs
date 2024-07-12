using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.IRepositories;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class MeetingRepository : Repository<Meeting>, IMeetingRepository
    {
         public MeetingRepository(AppDbContext db) : base(db) { }
    }
}
