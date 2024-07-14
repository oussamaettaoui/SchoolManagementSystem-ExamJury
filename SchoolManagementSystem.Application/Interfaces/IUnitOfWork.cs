using SchoolManagementSystem.Application.IRepositories;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IJuryMemberRepository JuryMemberRepository { get; }
        IMeetingRepository MeetingRepository { get; }
        IJuryRepository JuryRepository { get; }
        IJuryMemberRoleRepository JuryMemberRoleRepository { get; }
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}
