using SchoolManagementSystem.Application.IServices;

namespace SchoolManagementSystem.Application.UnitOfServices.Abstractions
{
    public interface IUnitOfService
    {
        IJuryMemberService juryMemberService { get; }
        IMeetingService MeetingService { get; }

    }
}
