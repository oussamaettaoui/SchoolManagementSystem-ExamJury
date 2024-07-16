using System.Linq.Expressions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IRepositories
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
        Task<List<Meeting>> GetMeetingListWithJuryAsync();
        Task<Meeting> GetMeetingByIdWithJuryAsync(Expression<Func<Meeting, bool>> filter);
    }
}
