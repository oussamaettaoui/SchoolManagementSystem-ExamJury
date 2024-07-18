using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IDayOrderService
    {
        Task<List<DayOrder>> GetDayOrderListAsync();
        Task<DayOrder> GetDayOrderByIdAsync(Guid id);
        Task<Result> AddDayOrderAsync(DayOrder dayOrder);
        Task<Result> EditDayOrderAsync(DayOrder dayOrder);
        Task<Result> DeleteDayOrderAsync(DayOrder dayOrder);
    }
}
