using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers
{
    public class DeleteJuryMemberCommandHandler : IRequestHandler<DeleteJuryMemberCommand, string>
    {
        private readonly IUnitOfService _uos;
        public DeleteJuryMemberCommandHandler(IUnitOfService uos)
        {
            _uos = uos;
        }
        public async Task<string> Handle(DeleteJuryMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                JuryMember juryMember = await _uos.JuryMemberService.GetJuryMemberByIdAsync(request.JuryMemberId);
                string result = await _uos.JuryMemberService.DeleteJuryMemberAsync(juryMember);
                if (result == "Success")
                {
                    return "Jury Member Deleted Successfully";
                }
                return "Error During Deleting";
            }
            catch (Exception ex)
            {
                throw new Exception("Error"+ex.ToString());
            }
        }
    }
}
