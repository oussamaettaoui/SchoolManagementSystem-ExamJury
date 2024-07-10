using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.JuryMemberDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberFeature.Query.Handlers
{
    public class GetJuryMemberListQueryHandler : IRequestHandler<GetJuryMemberListQuery,List<JuryMemberDto>>
    {
        private readonly IUnitOfService _uos;
        private readonly IMapper _mapper;
        public GetJuryMemberListQueryHandler(IUnitOfService uos,IMapper mapper)
        {
            _uos = uos;
            _mapper = mapper;
        }
        public async Task<List<JuryMemberDto>> Handle(GetJuryMemberListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<JuryMember> juryMembers = await _uos.JuryMemberService.GetJuryMemberListAsync();
                return _mapper.Map<List<JuryMemberDto>>(juryMembers);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Handler");
            }
        }
    }
}
