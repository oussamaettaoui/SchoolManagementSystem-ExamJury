using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class MeetingService : IMeetingService
    {
        #region Props
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public MeetingService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor = null)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region Methods
        public async Task<List<Meeting>> GetMeetingListAsync()
        {
            List<Meeting> meetingList = await _unitOfWork.MeetingRepository.GetMeetingListWithJuryAsync();
            return meetingList;
        }
        public async Task<Meeting> GetMeetingByIdAsync(Guid id)
        {
            Meeting meeting = await _unitOfWork.MeetingRepository.GetMeetingByIdWithJuryAsync(x=>x.Id.Equals(id));
            return meeting;
        }
        public async Task<Result> AddMeetingAsync(Meeting meeting)
        {
            try
            {
                meeting.Id = Guid.NewGuid();
                ClaimsPrincipal? user = _httpContextAccessor.HttpContext?.User;
                string? userRole = user?.FindFirst(ClaimTypes.Role)?.Value;
                Status status = userRole switch
                {
                    "director" => Status.Valid,
                    "assistant" => Status.InProgress,
                    _ => Status.Invalid
                };
                foreach (var dayOrder in meeting.DayOrderModels)
                {
                    dayOrder.Id = Guid.NewGuid();
                }
                meeting.CreatedAt = DateTime.UtcNow;
                meeting.Status = status;
                await _unitOfWork.MeetingRepository.CreateAsync(meeting);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch(Exception ex)
            {
                throw new Exception("Error Message : "+ex.ToString());
            }
        }
        public async Task<Result> UpdateMeetingAsync(Meeting meeting)
        {
            try
            {
                meeting.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.MeetingRepository.UpdateAsync(meeting);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }

        }
        public async Task<Result> DeleteMeetingAsync(Meeting meeting)
        {
            try
            {
                await _unitOfWork.MeetingRepository.RemoveAsync(meeting);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }

        public async Task<Result> ValidateMeetingAsync(Meeting meeting)
        {
            try
            {
                meeting.Status = Status.Valid;
                meeting.ValidateAt = DateTime.UtcNow;
                await _unitOfWork.MeetingRepository.UpdateAsync(meeting);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch(Exception ex)
            {
                return Result.Failure;
            }
        }
        #endregion
    }
}
