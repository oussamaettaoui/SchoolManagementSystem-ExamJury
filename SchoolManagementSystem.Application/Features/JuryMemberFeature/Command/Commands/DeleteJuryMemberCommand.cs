﻿using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands
{
    public class DeleteJuryMemberCommand : IRequest<Result>
    {
        public Guid JuryMemberId { get; set; }
        public DeleteJuryMemberCommand(Guid id)
        {
            JuryMemberId = id;
        }   
    }
}
