using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers
{
    public class EditJuryMemberCommandHandler : IRequestHandler<EditJuryMemberCommand, string>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public EditJuryMemberCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }
        public async Task<string> Handle(EditJuryMemberCommand request, CancellationToken cancellationToken)
        {
            JuryMember juryMember = await _uos.JuryMemberService.GetJuryMemberByIdAsync(request.JuryMemberId);
            if (juryMember == null)
            {
                return "Freelance Not Found";
            }
            _mapper.Map(request, juryMember);
            string result = await _uos.JuryMemberService.EditJuryMemberAsync(juryMember, request.ImgFile, request.Role);
            if (result == "Success")
            {
                return "Jury Member Updated Successfully";
            }
            return "Error Updating Deleting";
        }
    }
}
