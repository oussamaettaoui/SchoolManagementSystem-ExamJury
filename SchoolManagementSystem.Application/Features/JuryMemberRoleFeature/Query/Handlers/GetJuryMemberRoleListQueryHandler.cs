using AutoMapper;
using MediatR;
using SchoolManagementSystem.Application.Features.JuryMemberRoleFeature.Query.Queries;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;
using SchoolManagementSystem.Domain.Dtos.JuryMemberRoleDtos;
using SchoolManagementSystem.Domain.Dtos.MeetingDtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Features.JuryMemberRoleFeature.Query.Handlers
{
    public class GetJuryMemberRoleListQueryHandler : IRequestHandler<GetJuryMemberRoleListQuery, List<JuryMemberRoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfService _unitOfService;
        public GetJuryMemberRoleListQueryHandler(IMapper mapper,IUnitOfService unitOfService)
        {
            _mapper = mapper;
            _unitOfService = unitOfService;
        }
        public async Task<List<JuryMemberRoleDto>> Handle(GetJuryMemberRoleListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<JuryMemberRole> roles = await _unitOfService.JuryMemberRoleService.GetJuryMemberRoleListAsync();
                return _mapper.Map<List<JuryMemberRoleDto>>(roles);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
