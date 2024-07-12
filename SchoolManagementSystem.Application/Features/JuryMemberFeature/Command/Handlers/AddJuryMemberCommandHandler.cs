using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers
{
    public class AddJuryMemberCommandHandler : IRequestHandler<AddJuryMemberCommand, string>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public AddJuryMemberCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddJuryMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
<<<<<<< HEAD
                string result = await _uos.MeetingService.AddJuryMemberAsync(_mapper.Map<JuryMember>(request),request.ImgFile,request.Role);
=======
                string result = await _uos.JuryMemberService.AddJuryMemberAsync(_mapper.Map<JuryMember>(request),request.ImgFile);
>>>>>>> 12cac6bedaf3967337d569e66dfe177cae7333cc
                if (result == "Success")
                {
                    return "Jury Member Added Successfully";
                }
                return "Error During Adding";
            }
            catch (Exception ex)
            {
                throw new Exception("FaildInAdd handler"+ ex.ToString());
            }
        }
    }
}
