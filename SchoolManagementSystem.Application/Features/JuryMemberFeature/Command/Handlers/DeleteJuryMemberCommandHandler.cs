﻿using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers
{
    public class DeleteJuryMemberCommandHandler : IRequestHandler<DeleteJuryMemberCommand, Result>
    {
        private readonly IUnitOfService _uos;
        public DeleteJuryMemberCommandHandler(IUnitOfService uos)
        {
            _uos = uos;
        }
        public async Task<Result> Handle(DeleteJuryMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                JuryMember juryMember = await _uos.JuryMemberService.GetJuryMemberByIdAsync(request.JuryMemberId);
                Result result = await _uos.JuryMemberService.DeleteJuryMemberAsync(juryMember);
                if (result == Result.Success)
                {
                    return Result.Success;
                }
                return Result.Failure;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Handler : {ex.ToString()}");
            }
        }
    }
}
