using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Handlers
{
    public class GetJuryMemberByIdQueryHandler : IRequestHandler<GetJuryMemberByIdQuery, JuryMemberDto>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public GetJuryMemberByIdQueryHandler(IMapper mapper, IUnitOfService uos)
        {
            _mapper = mapper;
            _uos = uos;
        }
        public async Task<JuryMemberDto> Handle(GetJuryMemberByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                JuryMember juryMember = await _uos.JuryMemberService.GetJuryMemberByIdAsync(request.JuryMemberId);
                return _mapper.Map<JuryMemberDto>(juryMember);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Handler : " + ex.ToString());
            }
        }
    }
}