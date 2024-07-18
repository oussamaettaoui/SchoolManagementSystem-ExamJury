using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;

namespace SchoolManagementSystem.Application.UnitOfServices
{
    public class UnitOfService : IUnitOfService
    {
        public IJuryMemberService JuryMemberService { get; private set; }
        public IMeetingService MeetingService { get; private set; }
        public IJuryService JuryService { get; private set; }
        public IJuryMemberRoleService JuryMemberRoleService { get; private set; }
        public IDayOrderService DayOrderService { get; private set; }
        public IEmailService EmailService { get; private set; }
        public UnitOfService(IJuryMemberService juryMemberService, IMeetingService meetingService, IJuryService juryService, IJuryMemberRoleService juryMemberRoleService, IEmailService emailService, IDayOrderService dayOrderService)
        {
            MeetingService = meetingService;
            JuryMemberService = juryMemberService;
            JuryService = juryService;
            JuryMemberRoleService = juryMemberRoleService;
        }
    }
}
