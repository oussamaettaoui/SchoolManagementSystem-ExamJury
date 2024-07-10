using SchoolManagementSystem.Application.IRepositories;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IJuryMemberRepository JuryMemberRepository { get; }
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}
