using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;

namespace SchoolManagementSystem.Application.UnitOfServices
{
    public class UnitOfService : IUnitOfService
    {
        public IJuryMemberService MeetingService { get; private set; }
        public UnitOfService(IJuryMemberService juryMemberService)
        {
            MeetingService = juryMemberService;
        }
    }
}
