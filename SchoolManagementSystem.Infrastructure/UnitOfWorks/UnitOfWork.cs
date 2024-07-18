using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IJuryMemberRepository JuryMemberRepository { get; private set;}

        public IMeetingRepository MeetingRepository { get; private set; }

        public IJuryRepository JuryRepository { get; private set; }

        public IJuryMemberRoleRepository JuryMemberRoleRepository { get; private set; }

        public IDayOrderRepository DayOrderRepository { get; private set; }

        public UnitOfWork(AppDbContext db , IJuryMemberRepository juryMemberRepository, IMeetingRepository meetingRepository, IJuryRepository juryRepository, IJuryMemberRoleRepository juryMemberRoleRepository, IDayOrderRepository dayOrderRepository)
        {
            _db = db;
            JuryMemberRepository = juryMemberRepository;
            MeetingRepository = meetingRepository;
            JuryRepository = juryRepository;
            JuryMemberRoleRepository = juryMemberRoleRepository;
            DayOrderRepository = dayOrderRepository;
        }
        public void Commit()
        {
            _db.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Rollback()
        {
            _db.SaveChanges();
        }
        public async Task RollbackAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
