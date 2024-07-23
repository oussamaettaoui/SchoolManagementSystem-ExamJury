using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class MeetingRepository : Repository<Meeting>, IMeetingRepository
    {
        private readonly AppDbContext _db;
         public MeetingRepository(AppDbContext db) : base(db) { 
            _db = db;
         }
        public async Task<List<Meeting>> GetMeetingListWithJuryAsync()
        {
            List<Meeting> meetings = await _db.Meeting.AsNoTracking().Include(x => x.Jury).ToListAsync();
            return meetings;
        }
        public async Task<Meeting> GetMeetingByIdWithJuryAsync(Expression<Func<Meeting, bool>> filter)
        {
            Meeting meeting = await _db.Meeting.AsNoTracking().Where(filter).Include(x => x.DayOrderModels).Include(x => x.Jury).ThenInclude(x=>x.JuryMembers).ThenInclude(x=>x.Role).FirstOrDefaultAsync();
            return meeting;
        }
    }
}
