using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IMeetingService
    {
        Task<List<Meeting>> GetMeetingListAsync();
        Task<Meeting> GetMeetingByIdAsync(Guid id);
        Task<Result> AddMeetingAsync(Meeting meeting);
        Task<Result> UpdateMeetingAsync(Meeting meeting);
        Task<Result> DeleteMeetingAsync(Meeting meeting);
    }
}
