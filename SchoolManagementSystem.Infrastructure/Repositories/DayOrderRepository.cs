using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class DayOrderRepository : Repository<DayOrder>, IDayOrderRepository
    {
        public DayOrderRepository(AppDbContext db) : base(db)
        {
        }
    }
}
