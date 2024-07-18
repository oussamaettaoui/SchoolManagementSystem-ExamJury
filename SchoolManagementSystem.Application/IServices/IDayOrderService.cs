using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IDayOrderService
    {
        Task<List<DayOrder>> GetMeetingListAsync();
        Task<DayOrder> GetMeetingByIdAsync(Guid id);
        Task<Result> AddMeetingAsync(DayOrder dayOrder);
        Task<Result> UpdateMeetingAsync(DayOrder dayOrder);
        Task<Result> DeleteMeetingAsync(DayOrder dayOrder);
    }
}
