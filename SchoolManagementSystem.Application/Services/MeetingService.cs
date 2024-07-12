using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Services
{
    public class MeetingService : IMeetingService
    {
        public Task<string> AddMeetingAsync(JuryMember juryMember)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddMeetingAsync(Meeting meeting)
        {
            throw new NotImplementedException();
        }

        public Task<List<Meeting>> GetMeetingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Meeting> GetMeetingByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Meeting> GetMeetingByIdAsync(object meetingId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateMeetingAsync(JuryMember juryMember)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateMeetingAsync(Meeting meeting)
        {
            throw new NotImplementedException();
        }
    }
}
