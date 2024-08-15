using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers
{
    public class EditJuryMemberCommandHandler : IRequestHandler<EditJuryMemberCommand, Result>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public EditJuryMemberCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }
        public async Task<Result> Handle(EditJuryMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                JuryMember juryMember = await _uos.JuryMemberService.GetJuryMemberByIdAsync(request.JuryMemberId);
                if (juryMember is null)
                {
                    return Result.NotFound;
                }
                _mapper.Map(request, juryMember);

                Result result = await _uos.JuryMemberService.EditJuryMemberAsync(juryMember, request.ImgFile);
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
