using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.IServices
{
    public interface IMeetingService
    {
        Task<List<Meeting>> GetMeetingAsync();
        Task<Meeting> GetMeetingByIdAsync(Guid id);
        Task<string> AddMeetingAsync(JuryMember juryMember);
        Task<string> UpdateMeetingAsync(JuryMember juryMember);
        Task<string> UpdateMeetingAsync(Meeting meeting);
        Task<Meeting> GetMeetingByIdAsync(object meetingId);
        Task<string> AddMeetingAsync(Meeting meeting);
    }
}
