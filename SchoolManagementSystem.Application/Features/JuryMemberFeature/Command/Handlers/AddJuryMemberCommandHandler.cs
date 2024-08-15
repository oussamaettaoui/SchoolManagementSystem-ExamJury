using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Commands;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Command.Handlers
{
    public class AddJuryMemberCommandHandler : IRequestHandler<AddJuryMemberCommand, Result>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public AddJuryMemberCommandHandler(IUnitOfService uos, IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddJuryMemberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result result = await _uos.JuryMemberService.AddJuryMemberAsync(_mapper.Map<JuryMember>(request),request.ImgFile);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Result.Failure;
            }
        }
    }
}
