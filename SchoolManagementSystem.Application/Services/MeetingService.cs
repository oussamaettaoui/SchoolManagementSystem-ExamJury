using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class MeetingService : IMeetingService
    {
        #region Props
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructor
        public MeetingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public async Task<List<Meeting>> GetMeetingListAsync()
        {
            List<Meeting> meetingList = await _unitOfWork.MeetingRepository.GetAllAsNoTracking();
            return meetingList;
        }
        public async Task<Meeting> GetMeetingByIdAsync(Guid id)
        {
            Meeting meeting = await _unitOfWork.MeetingRepository.GetAsNoTracking(x=>x.Id.Equals(id));
            return meeting;
        }
        public async Task<Result> AddMeetingAsync(Meeting meeting)
        {
            try
            {
                meeting.Id = Guid.NewGuid();
                await _unitOfWork.MeetingRepository.CreateAsync(meeting);
                await _unitOfWork.CommitAsync();
                return Result.Success;
            }
            catch(Exception ex)
            {
                return Result.Failure;
            }
        }
        public async Task<Result> UpdateMeetingAsync(Meeting meeting)
        {
            try
            {
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
        #endregion
    }
}
