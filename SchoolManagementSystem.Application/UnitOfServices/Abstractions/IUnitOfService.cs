﻿using SchoolManagementSystem.Application.IServices;

namespace SchoolManagementSystem.Application.UnitOfServices.Abstractions
{
    public interface IUnitOfService
    {
        IJuryMemberService JuryMemberService { get; }
        IMeetingService MeetingService { get; }
        IJuryService JuryService { get; }
        IJuryMemberRoleService JuryMemberRoleService { get; }
        IDayOrderService DayOrderService { get; }
        IEmailService EmailService { get; }

    }
}
