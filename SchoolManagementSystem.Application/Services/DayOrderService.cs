using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class DayOrderService : IDayOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobService _blobService;
        public DayOrderService(IUnitOfWork unitOfWork, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _blobService = blobService;
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
        public async Task<Result> AddDayOrderAsync(DayOrder dayOrder,IFormFile DocumentFile)
        {
            try
            {
                dayOrder.Id = Guid.NewGuid();
                if (DocumentFile != null)
                {
                    string docPath = await _blobService.UploadAsync(dayOrder.Id, DocumentFile);
                    dayOrder.DocumentPath = docPath;
                }
                else
                {
                    dayOrder.DocumentPath = "string";
                }
                await _unitOfWork.DayOrderRepository.CreateAsync(dayOrder);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message : "+ex.ToString());
            }
        }
        public async Task<Result> EditDayOrderAsync(DayOrder dayOrder, IFormFile DocumentFile)
        {
            try
            {
                if (!string.IsNullOrEmpty(dayOrder.DocumentPath))
                {
                    _blobService.DeleteAsync(dayOrder.Id.ToString());
                    string docPath = await _blobService.UploadAsync(dayOrder.Id, DocumentFile);
                    dayOrder.DocumentPath = docPath;
                }
                else
                {
                    dayOrder.DocumentPath = "string";
                }
                dayOrder.UpdatedAt = DateTime.UtcNow;
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
                if (!string.IsNullOrEmpty(dayOrder.DocumentPath))
                {
                    _blobService.DeleteAsync(dayOrder.Id.ToString());
                }
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
