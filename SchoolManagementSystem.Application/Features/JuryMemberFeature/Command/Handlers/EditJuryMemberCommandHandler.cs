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
            JuryMember juryMember = await _uos.MeetingService.GetJuryMemberByIdAsync(request.JuryMemberId);
            if (juryMember == null)
            {
                return "Jury Member Not Found";
            }
            _mapper.Map(request, juryMember);
<<<<<<< HEAD
            string result = await _uos.MeetingService.EditJuryMemberAsync(juryMember, request.ImgFile, request.Role);
=======
            string result = await _uos.JuryMemberService.EditJuryMemberAsync(juryMember, request.ImgFile);
>>>>>>> 12cac6bedaf3967337d569e66dfe177cae7333cc
            if (result == "Success")
            {
                return "Jury Member Updated Successfully";
            }
            return "Error Updating Deleting";
        }
    }
}
