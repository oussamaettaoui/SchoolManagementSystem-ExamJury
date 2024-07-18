using MediatR;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands
{
    public class DeleteJuryMemberCommand : IRequest<string>
    {
        public Guid JuryMemberId { get; set; }
        public DeleteJuryMemberCommand(Guid id)
        {
            JuryMemberId = id;
        }   
    }
}
