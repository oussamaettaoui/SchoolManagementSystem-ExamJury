using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class DayOrderService : IDayOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DayOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<DayOrder>> GetDayOrderListAsync()
        {
            List<DayOrder> dayOrderList = await _unitOfWork.DayOrderRepository.GetAllAsNoTracking();
            return dayOrderList;
        }
        public async Task<DayOrder> GetDayOrderByIdAsync(Guid id)
        {
            try
            {
                DayOrder dayOrder = await _unitOfWork.DayOrderRepository.GetAsNoTracking(x => x.Id.Equals(id));
                return dayOrder;
            }
            catch(Exception ex)
            {
                throw new Exception("Error Message : "+ex.ToString());
            }
        }
        public async Task<Result> AddDayOrderAsync(DayOrder dayOrder)
        {
            try
            {
                dayOrder.Id = Guid.NewGuid();
                await _unitOfWork.DayOrderRepository.CreateAsync(dayOrder);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message : "+ex.ToString());
            }
        }
        public async Task<Result> EditDayOrderAsync(DayOrder dayOrder)
        {
            try
            {
                await _unitOfWork.DayOrderRepository.UpdateAsync(dayOrder);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
        public async Task<Result> DeleteDayOrderAsync(DayOrder dayOrder)
        {
            try
            {
                await _unitOfWork.DayOrderRepository.RemoveAsync(dayOrder);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
    }
}
