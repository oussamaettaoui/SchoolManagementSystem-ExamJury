using System.ComponentModel.DataAnnotations;
using MediatR;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands
{
    public class ValidateJuryMemberCommand :  IRequest<Result>
    {
        public Guid JuryMemberId { get; set; }
        public ValidateJuryMemberCommand(Guid id)
        {
            JuryMemberId = id;
        }
    }
}
