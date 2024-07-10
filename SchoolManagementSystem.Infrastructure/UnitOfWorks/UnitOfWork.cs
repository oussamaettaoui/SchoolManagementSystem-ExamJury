using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public IJuryMemberRepository JuryMemberRepository { get; private set;}
        public UnitOfWork(AppDbContext db , IJuryMemberRepository juryMemberRepository)
        {
            _db = db;
            JuryMemberRepository = juryMemberRepository;
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
