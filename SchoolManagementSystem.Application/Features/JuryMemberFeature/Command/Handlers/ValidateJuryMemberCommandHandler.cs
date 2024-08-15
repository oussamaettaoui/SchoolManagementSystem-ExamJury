using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers
{
    public class ValidateJuryMemberCommandHandler : IRequestHandler<ValidateJuryMemberCommand, Result>

    {
        private readonly IUnitOfService unitOfService;
        public ValidateJuryMemberCommandHandler(IUnitOfService unitOfService)
        {
            this.unitOfService = unitOfService;
        }
        public async Task<Result> Handle(ValidateJuryMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                JuryMember juryMember = await unitOfService.JuryMemberService.GetJuryMemberByIdAsync(request.JuryMemberId);
                if (juryMember is null)
                {
                    return Result.NotFound;
                }
                Result res = await unitOfService.JuryMemberService.ValidateJuryMemberAsync(juryMember);
                if (res == Result.Success)
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
